
namespace FormsApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.KeywordsText = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.EngineCombo = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.UrlText = new System.Windows.Forms.TextBox();
            this.SearchButton = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.ResultText = new System.Windows.Forms.TextBox();
            this.ErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.Progress = new System.Windows.Forms.ProgressBar();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.KeywordsText);
            this.groupBox1.Location = new System.Drawing.Point(39, 113);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(728, 68);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Keywords";
            // 
            // KeywordsText
            // 
            this.KeywordsText.Location = new System.Drawing.Point(27, 26);
            this.KeywordsText.Name = "KeywordsText";
            this.KeywordsText.Size = new System.Drawing.Size(680, 27);
            this.KeywordsText.TabIndex = 1;
            this.KeywordsText.Text = "e-settlements";
            this.KeywordsText.Validating += new System.ComponentModel.CancelEventHandler(this.KeywordsText_Validating);
            this.KeywordsText.Validated += new System.EventHandler(this.KeywordsText_Validated);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.EngineCombo);
            this.groupBox2.Location = new System.Drawing.Point(39, 33);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(728, 68);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Engine";
            // 
            // EngineCombo
            // 
            this.EngineCombo.CausesValidation = false;
            this.EngineCombo.FormattingEnabled = true;
            this.EngineCombo.Location = new System.Drawing.Point(27, 26);
            this.EngineCombo.Name = "EngineCombo";
            this.EngineCombo.Size = new System.Drawing.Size(680, 28);
            this.EngineCombo.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.UrlText);
            this.groupBox3.Location = new System.Drawing.Point(39, 190);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(728, 68);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Url";
            // 
            // UrlText
            // 
            this.UrlText.Location = new System.Drawing.Point(27, 26);
            this.UrlText.Name = "UrlText";
            this.UrlText.Size = new System.Drawing.Size(680, 27);
            this.UrlText.TabIndex = 2;
            this.UrlText.Text = "https://www.sympli.com.au";
            this.UrlText.Validating += new System.ComponentModel.CancelEventHandler(this.UrlText_Validating);
            this.UrlText.Validated += new System.EventHandler(this.UrlText_Validated);
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(39, 275);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(728, 27);
            this.SearchButton.TabIndex = 3;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.ResultText);
            this.groupBox4.Location = new System.Drawing.Point(39, 324);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(728, 103);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Result";
            // 
            // ResultText
            // 
            this.ResultText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ResultText.Location = new System.Drawing.Point(6, 26);
            this.ResultText.Multiline = true;
            this.ResultText.Name = "ResultText";
            this.ResultText.ReadOnly = true;
            this.ResultText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ResultText.Size = new System.Drawing.Size(716, 58);
            this.ResultText.TabIndex = 4;
            this.ResultText.TabStop = false;
            // 
            // ErrorProvider
            // 
            this.ErrorProvider.ContainerControl = this;
            // 
            // Progress
            // 
            this.Progress.Location = new System.Drawing.Point(39, 264);
            this.Progress.MarqueeAnimationSpeed = 10;
            this.Progress.Name = "Progress";
            this.Progress.Size = new System.Drawing.Size(728, 54);
            this.Progress.Step = 5;
            this.Progress.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.Progress.TabIndex = 5;
            this.Progress.Value = 50;
            this.Progress.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Progress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(30);
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search on the Web";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox KeywordsText;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox EngineCombo;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox UrlText;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox ResultText;
        private System.Windows.Forms.ErrorProvider ErrorProvider;
        private System.Windows.Forms.ProgressBar Progress;
    }
}

