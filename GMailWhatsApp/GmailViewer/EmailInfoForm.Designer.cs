namespace GmailViewer
{
    partial class EmailInfoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.infoTextsplitContainer = new System.Windows.Forms.SplitContainer();
            this.toTextBox = new System.Windows.Forms.TextBox();
            this.toLabel = new System.Windows.Forms.Label();
            this.fromTextBox = new System.Windows.Forms.TextBox();
            this.fromLabel = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            ((System.ComponentModel.ISupportInitialize)(this.infoTextsplitContainer)).BeginInit();
            this.infoTextsplitContainer.Panel1.SuspendLayout();
            this.infoTextsplitContainer.Panel2.SuspendLayout();
            this.infoTextsplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // infoTextsplitContainer
            // 
            this.infoTextsplitContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.infoTextsplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.infoTextsplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.infoTextsplitContainer.Location = new System.Drawing.Point(0, 0);
            this.infoTextsplitContainer.Name = "infoTextsplitContainer";
            this.infoTextsplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // infoTextsplitContainer.Panel1
            // 
            this.infoTextsplitContainer.Panel1.Controls.Add(this.toTextBox);
            this.infoTextsplitContainer.Panel1.Controls.Add(this.toLabel);
            this.infoTextsplitContainer.Panel1.Controls.Add(this.fromTextBox);
            this.infoTextsplitContainer.Panel1.Controls.Add(this.fromLabel);
            // 
            // infoTextsplitContainer.Panel2
            // 
            this.infoTextsplitContainer.Panel2.Controls.Add(this.splitContainer2);
            this.infoTextsplitContainer.Size = new System.Drawing.Size(730, 491);
            this.infoTextsplitContainer.SplitterDistance = 94;
            this.infoTextsplitContainer.TabIndex = 0;
            // 
            // toTextBox
            // 
            this.toTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toTextBox.Location = new System.Drawing.Point(46, 39);
            this.toTextBox.Multiline = true;
            this.toTextBox.Name = "toTextBox";
            this.toTextBox.ReadOnly = true;
            this.toTextBox.Size = new System.Drawing.Size(670, 48);
            this.toTextBox.TabIndex = 3;
            // 
            // toLabel
            // 
            this.toLabel.AutoSize = true;
            this.toLabel.Location = new System.Drawing.Point(10, 42);
            this.toLabel.Name = "toLabel";
            this.toLabel.Size = new System.Drawing.Size(23, 13);
            this.toLabel.TabIndex = 2;
            this.toLabel.Text = "To:";
            // 
            // fromTextBox
            // 
            this.fromTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fromTextBox.Location = new System.Drawing.Point(46, 10);
            this.fromTextBox.Name = "fromTextBox";
            this.fromTextBox.ReadOnly = true;
            this.fromTextBox.Size = new System.Drawing.Size(670, 20);
            this.fromTextBox.TabIndex = 1;
            // 
            // fromLabel
            // 
            this.fromLabel.AutoSize = true;
            this.fromLabel.Location = new System.Drawing.Point(10, 13);
            this.fromLabel.Name = "fromLabel";
            this.fromLabel.Size = new System.Drawing.Size(33, 13);
            this.fromLabel.TabIndex = 0;
            this.fromLabel.Text = "From:";
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.emailTextBox);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.webBrowser);
            this.splitContainer2.Size = new System.Drawing.Size(730, 393);
            this.splitContainer2.SplitterDistance = 243;
            this.splitContainer2.TabIndex = 0;
            // 
            // emailTextBox
            // 
            this.emailTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.emailTextBox.Location = new System.Drawing.Point(0, 0);
            this.emailTextBox.Multiline = true;
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.ReadOnly = true;
            this.emailTextBox.Size = new System.Drawing.Size(239, 389);
            this.emailTextBox.TabIndex = 0;
            // 
            // webBrowser
            // 
            this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser.Location = new System.Drawing.Point(0, 0);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(479, 389);
            this.webBrowser.TabIndex = 0;
            // 
            // EmailInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 491);
            this.Controls.Add(this.infoTextsplitContainer);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(679, 495);
            this.Name = "EmailInfoForm";
            this.Text = "Email";
            this.infoTextsplitContainer.Panel1.ResumeLayout(false);
            this.infoTextsplitContainer.Panel1.PerformLayout();
            this.infoTextsplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.infoTextsplitContainer)).EndInit();
            this.infoTextsplitContainer.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.SplitContainer infoTextsplitContainer;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.TextBox toTextBox;
        private System.Windows.Forms.Label toLabel;
        private System.Windows.Forms.TextBox fromTextBox;
        private System.Windows.Forms.Label fromLabel;
    }
}