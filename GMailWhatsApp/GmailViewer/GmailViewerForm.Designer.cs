namespace GmailViewer
{
    partial class GmailViewerForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.signInButton = new System.Windows.Forms.Button();
            this.loginTextBox = new System.Windows.Forms.TextBox();
            this.gmailLabel = new System.Windows.Forms.Label();
            this.connectionStatusTextBox = new System.Windows.Forms.RichTextBox();
            this.amountLabel = new System.Windows.Forms.Label();
            this.emailAmountComboBox = new System.Windows.Forms.ComboBox();
            this.SaveMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mSGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.signoutButton = new System.Windows.Forms.Button();
            this.downloadAllButton = new System.Windows.Forms.Button();
            this.folderComboBox = new System.Windows.Forms.ComboBox();
            this.folderLabel = new System.Windows.Forms.Label();
            this.mailView = new GmailViewer.MailView();
            this.fromColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.subjectColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.recipientColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.messageColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.htmlColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dateColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statusColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fileView = new System.Windows.Forms.ListView();
            this.Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Size = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Path = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SaveMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // signInButton
            // 
            this.signInButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.signInButton.Location = new System.Drawing.Point(929, 11);
            this.signInButton.Margin = new System.Windows.Forms.Padding(4);
            this.signInButton.Name = "signInButton";
            this.signInButton.Size = new System.Drawing.Size(100, 28);
            this.signInButton.TabIndex = 1;
            this.signInButton.Text = "Sign in";
            this.signInButton.UseVisualStyleBackColor = true;
            this.signInButton.Click += new System.EventHandler(this.SignInButtonClick);
            // 
            // loginTextBox
            // 
            this.loginTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.loginTextBox.Enabled = false;
            this.loginTextBox.Location = new System.Drawing.Point(68, 12);
            this.loginTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.loginTextBox.Name = "loginTextBox";
            this.loginTextBox.Size = new System.Drawing.Size(199, 15);
            this.loginTextBox.TabIndex = 7;
            // 
            // gmailLabel
            // 
            this.gmailLabel.AutoSize = true;
            this.gmailLabel.Location = new System.Drawing.Point(16, 12);
            this.gmailLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gmailLabel.Name = "gmailLabel";
            this.gmailLabel.Size = new System.Drawing.Size(54, 17);
            this.gmailLabel.TabIndex = 8;
            this.gmailLabel.Text = "Google";
            // 
            // connectionStatusTextBox
            // 
            this.connectionStatusTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.connectionStatusTextBox.Enabled = false;
            this.connectionStatusTextBox.Location = new System.Drawing.Point(275, 12);
            this.connectionStatusTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.connectionStatusTextBox.Name = "connectionStatusTextBox";
            this.connectionStatusTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.connectionStatusTextBox.Size = new System.Drawing.Size(283, 49);
            this.connectionStatusTextBox.TabIndex = 9;
            this.connectionStatusTextBox.Text = "";
            // 
            // amountLabel
            // 
            this.amountLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.amountLabel.AutoSize = true;
            this.amountLabel.Location = new System.Drawing.Point(789, 391);
            this.amountLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.amountLabel.Name = "amountLabel";
            this.amountLabel.Size = new System.Drawing.Size(68, 17);
            this.amountLabel.TabIndex = 11;
            this.amountLabel.Text = "Show last";
            this.amountLabel.Visible = false;
            // 
            // emailAmountComboBox
            // 
            this.emailAmountComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.emailAmountComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.emailAmountComboBox.FormattingEnabled = true;
            this.emailAmountComboBox.Items.AddRange(new object[] {
            "10",
            "25",
            "100",
            "00"});
            this.emailAmountComboBox.Location = new System.Drawing.Point(868, 388);
            this.emailAmountComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.emailAmountComboBox.Name = "emailAmountComboBox";
            this.emailAmountComboBox.Size = new System.Drawing.Size(160, 24);
            this.emailAmountComboBox.TabIndex = 6;
            this.emailAmountComboBox.Visible = false;
            // 
            // SaveMenu
            // 
            this.SaveMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.SaveMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveAsToolStripMenuItem});
            this.SaveMenu.Name = "SaveMenu";
            this.SaveMenu.Size = new System.Drawing.Size(147, 30);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eMLToolStripMenuItem,
            this.mSGToolStripMenuItem});
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(146, 26);
            this.saveAsToolStripMenuItem.Text = "Save as ...";
            // 
            // eMLToolStripMenuItem
            // 
            this.eMLToolStripMenuItem.Name = "eMLToolStripMenuItem";
            this.eMLToolStripMenuItem.Size = new System.Drawing.Size(115, 26);
            this.eMLToolStripMenuItem.Text = "EML";
            this.eMLToolStripMenuItem.Click += new System.EventHandler(this.EMLToolStripMenuItem_Click);
            // 
            // mSGToolStripMenuItem
            // 
            this.mSGToolStripMenuItem.Name = "mSGToolStripMenuItem";
            this.mSGToolStripMenuItem.Size = new System.Drawing.Size(115, 26);
            this.mSGToolStripMenuItem.Text = "MSG";
            this.mSGToolStripMenuItem.Click += new System.EventHandler(this.MSGToolStripMenuItem_Click);
            // 
            // signoutButton
            // 
            this.signoutButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.signoutButton.Enabled = false;
            this.signoutButton.Location = new System.Drawing.Point(929, 39);
            this.signoutButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.signoutButton.Name = "signoutButton";
            this.signoutButton.Size = new System.Drawing.Size(100, 30);
            this.signoutButton.TabIndex = 4;
            this.signoutButton.Text = "Sign Out";
            this.signoutButton.UseVisualStyleBackColor = true;
            this.signoutButton.Click += new System.EventHandler(this.SignoutButton_Click);
            // 
            // downloadAllButton
            // 
            this.downloadAllButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.downloadAllButton.Enabled = false;
            this.downloadAllButton.Location = new System.Drawing.Point(795, 39);
            this.downloadAllButton.Margin = new System.Windows.Forms.Padding(4);
            this.downloadAllButton.Name = "downloadAllButton";
            this.downloadAllButton.Size = new System.Drawing.Size(128, 30);
            this.downloadAllButton.TabIndex = 3;
            this.downloadAllButton.Text = "Download All";
            this.downloadAllButton.UseVisualStyleBackColor = true;
            this.downloadAllButton.Visible = false;
            this.downloadAllButton.Click += new System.EventHandler(this.DownloadAllButton_Click);
            // 
            // folderComboBox
            // 
            this.folderComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.folderComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.folderComboBox.Location = new System.Drawing.Point(68, 36);
            this.folderComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.folderComboBox.Name = "folderComboBox";
            this.folderComboBox.Size = new System.Drawing.Size(197, 24);
            this.folderComboBox.TabIndex = 2;
            this.folderComboBox.Visible = false;
            // 
            // folderLabel
            // 
            this.folderLabel.AutoSize = true;
            this.folderLabel.Location = new System.Drawing.Point(16, 39);
            this.folderLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.folderLabel.Name = "folderLabel";
            this.folderLabel.Size = new System.Drawing.Size(48, 17);
            this.folderLabel.TabIndex = 12;
            this.folderLabel.Text = "Folder";
            this.folderLabel.Visible = false;
            // 
            // mailView
            // 
            this.mailView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mailView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.fromColumn,
            this.subjectColumn,
            this.recipientColumn,
            this.messageColumn,
            this.htmlColumn,
            this.dateColumn,
            this.statusColumn});
            this.mailView.FullRowSelect = true;
            this.mailView.GridLines = true;
            this.mailView.Location = new System.Drawing.Point(16, 69);
            this.mailView.Margin = new System.Windows.Forms.Padding(4);
            this.mailView.Name = "mailView";
            this.mailView.Size = new System.Drawing.Size(1012, 310);
            this.mailView.TabIndex = 5;
            this.mailView.UseCompatibleStateImageBehavior = false;
            this.mailView.View = System.Windows.Forms.View.Details;
            this.mailView.Visible = false;
            this.mailView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MailView_MouseDown);
            this.mailView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.MailViewMouseDoubleClick);
            // 
            // fromColumn
            // 
            this.fromColumn.Text = "From";
            this.fromColumn.Width = 100;
            // 
            // subjectColumn
            // 
            this.subjectColumn.Text = "Subject";
            // 
            // recipientColumn
            // 
            this.recipientColumn.Text = "Recipient";
            this.recipientColumn.Width = 100;
            // 
            // messageColumn
            // 
            this.messageColumn.Text = "Message";
            this.messageColumn.Width = 200;
            // 
            // htmlColumn
            // 
            this.htmlColumn.Text = "HTML";
            this.htmlColumn.Width = 150;
            // 
            // dateColumn
            // 
            this.dateColumn.Text = "Date";
            this.dateColumn.Width = 100;
            // 
            // statusColumn
            // 
            this.statusColumn.Text = "Status";
            this.statusColumn.Width = 59;
            // 
            // fileView
            // 
            this.fileView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fileView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Name,
            this.Size,
            this.Path});
            this.fileView.GridLines = true;
            this.fileView.Location = new System.Drawing.Point(19, 69);
            this.fileView.Name = "fileView";
            this.fileView.Size = new System.Drawing.Size(998, 295);
            this.fileView.TabIndex = 13;
            this.fileView.UseCompatibleStateImageBehavior = false;
            this.fileView.View = System.Windows.Forms.View.Details;
            this.fileView.Visible = false;
            // 
            // Name
            // 
            this.Name.Text = "Name";
            this.Name.Width = 145;
            // 
            // Size
            // 
            this.Size.Text = "Size";
            this.Size.Width = 71;
            // 
            // Path
            // 
            this.Path.Text = "Path";
            this.Path.Width = 777;
            // 
            // GmailViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 427);
            this.Controls.Add(this.fileView);
            this.Controls.Add(this.folderLabel);
            this.Controls.Add(this.folderComboBox);
            this.Controls.Add(this.downloadAllButton);
            this.Controls.Add(this.signoutButton);
            this.Controls.Add(this.emailAmountComboBox);
            this.Controls.Add(this.amountLabel);
            this.Controls.Add(this.connectionStatusTextBox);
            this.Controls.Add(this.gmailLabel);
            this.Controls.Add(this.loginTextBox);
            this.Controls.Add(this.signInButton);
            this.Controls.Add(this.mailView);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(841, 464);
            this.Name.Text = "GmailViewerForm";
            this.Text = "Gmail Viewer";
            this.SaveMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MailView mailView;
        private System.Windows.Forms.ColumnHeader fromColumn;
        private System.Windows.Forms.ColumnHeader subjectColumn;
        private System.Windows.Forms.ColumnHeader messageColumn;
        private System.Windows.Forms.ColumnHeader htmlColumn;
        private System.Windows.Forms.ColumnHeader dateColumn;
        private System.Windows.Forms.ColumnHeader statusColumn;
        private System.Windows.Forms.Button signInButton;
        private System.Windows.Forms.TextBox loginTextBox;
        private System.Windows.Forms.Label gmailLabel;
        private System.Windows.Forms.RichTextBox connectionStatusTextBox;
        private System.Windows.Forms.ColumnHeader recipientColumn;
        private System.Windows.Forms.Label amountLabel;
        private System.Windows.Forms.ComboBox emailAmountComboBox;
        private System.Windows.Forms.ContextMenuStrip SaveMenu;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eMLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mSGToolStripMenuItem;
        private System.Windows.Forms.Button signoutButton;
        private System.Windows.Forms.Button downloadAllButton;
        private System.Windows.Forms.ComboBox folderComboBox;
        private System.Windows.Forms.Label folderLabel;
        private System.Windows.Forms.ListView fileView;
        private System.Windows.Forms.ColumnHeader Name;
        private System.Windows.Forms.ColumnHeader Size;
        private System.Windows.Forms.ColumnHeader Path;
    }
}