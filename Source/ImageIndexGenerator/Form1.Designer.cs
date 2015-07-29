namespace EthanYoung.PersonalWebsite.ImageIndexGenerator
{
    partial class frmDataSetEditor
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
            this.components = new System.ComponentModel.Container();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._imagesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dgvImages = new System.Windows.Forms.DataGridView();
            this.fileNameTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titleTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateTakenTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hasThumbnailCheckboxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.hasFullSizeCheckboxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.dlgSave = new System.Windows.Forms.SaveFileDialog();
            this.dlgBrowseFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
            this.pbPreview = new System.Windows.Forms.PictureBox();
            this.mainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._imagesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvImages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(654, 24);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.Text = "menuStrip1";
            // 
            // fileMenuItem
            // 
            this.fileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newMenuItem,
            this.openMenuItem,
            this.saveMenuItem,
            this.saveAsMenuItem,
            this.exitMenuItem});
            this.fileMenuItem.Name = "fileMenuItem";
            this.fileMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileMenuItem.Text = "File";
            this.fileMenuItem.DropDownOpening += new System.EventHandler(this.fileMenuItem_DropDownOpening);
            // 
            // newMenuItem
            // 
            this.newMenuItem.Name = "newMenuItem";
            this.newMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newMenuItem.Text = "New";
            this.newMenuItem.Click += new System.EventHandler(this.newMenuItem_Click);
            // 
            // openMenuItem
            // 
            this.openMenuItem.Name = "openMenuItem";
            this.openMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openMenuItem.Text = "Open";
            this.openMenuItem.Click += new System.EventHandler(this.openMenuItem_Click);
            // 
            // saveMenuItem
            // 
            this.saveMenuItem.Name = "saveMenuItem";
            this.saveMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveMenuItem.Text = "Save";
            this.saveMenuItem.Click += new System.EventHandler(this.saveMenuItem_Click);
            // 
            // saveAsMenuItem
            // 
            this.saveAsMenuItem.Name = "saveAsMenuItem";
            this.saveAsMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveAsMenuItem.Text = "Save As";
            this.saveAsMenuItem.Click += new System.EventHandler(this.saveAsMenuItem_Click);
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitMenuItem.Text = "Exit";
            this.exitMenuItem.Click += new System.EventHandler(this.exitMenuItem_Click);
            // 
            // _imagesBindingSource
            // 
            this._imagesBindingSource.DataMember = "Images";
            // 
            // dgvImages
            // 
            this.dgvImages.AllowUserToAddRows = false;
            this.dgvImages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvImages.AutoGenerateColumns = false;
            this.dgvImages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvImages.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fileNameTextBoxColumn,
            this.titleTextBoxColumn,
            this.dateTakenTextBoxColumn,
            this.hasThumbnailCheckboxColumn,
            this.hasFullSizeCheckboxColumn});
            this.dgvImages.DataSource = this._imagesBindingSource;
            this.dgvImages.Location = new System.Drawing.Point(12, 36);
            this.dgvImages.Name = "dgvImages";
            this.dgvImages.Size = new System.Drawing.Size(630, 189);
            this.dgvImages.TabIndex = 1;
            this.dgvImages.SelectionChanged += new System.EventHandler(this.dgvImages_SelectionChanged);
            // 
            // fileNameTextBoxColumn
            // 
            this.fileNameTextBoxColumn.DataPropertyName = "filename";
            this.fileNameTextBoxColumn.HeaderText = "File Name";
            this.fileNameTextBoxColumn.Name = "fileNameTextBoxColumn";
            // 
            // titleTextBoxColumn
            // 
            this.titleTextBoxColumn.DataPropertyName = "Title";
            this.titleTextBoxColumn.HeaderText = "Title";
            this.titleTextBoxColumn.Name = "titleTextBoxColumn";
            // 
            // dateTakenTextBoxColumn
            // 
            this.dateTakenTextBoxColumn.DataPropertyName = "DateTaken";
            this.dateTakenTextBoxColumn.HeaderText = "Date Taken";
            this.dateTakenTextBoxColumn.Name = "dateTakenTextBoxColumn";
            // 
            // hasThumbnailCheckboxColumn
            // 
            this.hasThumbnailCheckboxColumn.DataPropertyName = "hasThumbnail";
            this.hasThumbnailCheckboxColumn.HeaderText = "Thumbnail";
            this.hasThumbnailCheckboxColumn.Name = "hasThumbnailCheckboxColumn";
            // 
            // hasFullSizeCheckboxColumn
            // 
            this.hasFullSizeCheckboxColumn.DataPropertyName = "hasFullSize";
            this.hasFullSizeCheckboxColumn.HeaderText = "Full Size";
            this.hasFullSizeCheckboxColumn.Name = "hasFullSizeCheckboxColumn";
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(12, 231);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(464, 160);
            this.txtDescription.TabIndex = 2;
            // 
            // dlgSave
            // 
            this.dlgSave.DefaultExt = "xml";
            this.dlgSave.Filter = "XML files (*.xml)|*.xml";
            // 
            // dlgBrowseFolder
            // 
            this.dlgBrowseFolder.ShowNewFolderButton = false;
            // 
            // dlgOpen
            // 
            this.dlgOpen.DefaultExt = "xml";
            this.dlgOpen.Filter = "XML files|*.xml";
            // 
            // pbPreview
            // 
            this.pbPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pbPreview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbPreview.Location = new System.Drawing.Point(482, 231);
            this.pbPreview.Name = "pbPreview";
            this.pbPreview.Size = new System.Drawing.Size(160, 160);
            this.pbPreview.TabIndex = 3;
            this.pbPreview.TabStop = false;
            // 
            // frmDataSetEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 403);
            this.Controls.Add(this.pbPreview);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.dgvImages);
            this.Controls.Add(this.mainMenu);
            this.MainMenuStrip = this.mainMenu;
            this.Name = "frmDataSetEditor";
            this.Text = "Image Index Generator";
            this.Load += new System.EventHandler(this.frmDataSetEditor_Load);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._imagesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvImages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        private System.Windows.Forms.BindingSource _imagesBindingSource;
        private System.Windows.Forms.DataGridView dgvImages;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.SaveFileDialog dlgSave;
        private System.Windows.Forms.FolderBrowserDialog dlgBrowseFolder;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileNameTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn titleTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateTakenTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn hasThumbnailCheckboxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn hasFullSizeCheckboxColumn;
        private System.Windows.Forms.OpenFileDialog dlgOpen;
        private System.Windows.Forms.PictureBox pbPreview;
    }
}

