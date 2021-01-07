using System;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Caching;
using Crawling;

namespace FormsApp
{
    public partial class Form1 : Form
    {
        class Client : IClient
        {
            HttpClient _http = new HttpClient();
            public Task<string> GetAsync(string uri) => _http.GetStringAsync(uri);
        }

        public Form1()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            var descriptors = new SearchEngineFactory(new Cache.Factory(), new Client()).Engines;
            EngineCombo.Items.AddRange(descriptors);
            var descriptor = descriptors.First(engine => engine.Available);
            EngineCombo.SelectedItem = descriptor;
        }

        private void KeywordsText_Validating(object sender, CancelEventArgs e)
        {
            if (KeywordsText.Text.Length < 3)
            {
                e.Cancel = true;
                KeywordsText.Select(0, KeywordsText.Text.Length);
                ErrorProvider.SetError(KeywordsText, "Keywords must be at least 3 characters long");
            }
        }

        private void KeywordsText_Validated(object sender, EventArgs e)
        {
            ErrorProvider.SetError(KeywordsText, null);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private async void SearchButton_Click(object sender, EventArgs e)
        {
            SearchButton.Enabled = false;
            Progress.Visible = true;
            try
            {
                var descriptor = (ISearchEngineDescriptor)EngineCombo.SelectedItem;
                var engine = descriptor.Get();
                var result = await engine.SearchAsync(KeywordsText.Text, UrlText.Text);
                ResultText.Text = result;
            }
            catch(Exception x)
            {
                ResultText.Text = x.Message;
            }
            finally
            {
                Progress.Visible = false;
                SearchButton.Enabled = true;
            }
        }

        private void UrlText_Validating(object sender, CancelEventArgs e)
        {
            bool result = 
                Uri.TryCreate(UrlText.Text, UriKind.Absolute, out var uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
            if (!result) e.Cancel = true;
            UrlText.Select(0, UrlText.Text.Length);
            ErrorProvider.SetError(UrlText, "Invalid Url");
        }

        private void UrlText_Validated(object sender, EventArgs e)
        {
            ErrorProvider.SetError(UrlText, null);
        }
    }
}
