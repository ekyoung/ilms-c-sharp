using System;
using System.Data;
using System.Windows.Forms;
using System.IO;
using EthanYoung.PersonalWebsite.ImageManipulation;

namespace EthanYoung.PersonalWebsite.ImageIndexGenerator
{
    public partial class frmDataSetEditor : Form, Form1Presenter.IView
    {
        private readonly Form1Presenter _presenter;

        public frmDataSetEditor()
        {
            InitializeComponent();

            _presenter = new Form1Presenter(this, new ImageResizer(), new ImagePropertyFacade(), new FileIO());
        }

        private void frmDataSetEditor_Load(object sender, EventArgs e)
        {
        }

        public string IndexFileName { get; set; }

        public string ThumbnailFolderPath { get; set; }

        public ImagesDataSet Images
        {
            get { return (ImagesDataSet) _imagesBindingSource.DataSource; }
            set
            {
                _imagesBindingSource.DataSource = value;
                if (txtDescription.DataBindings.Count == 0)
                {
                    txtDescription.DataBindings.Add("Text", _imagesBindingSource, "Description");
                }
            }
        }

        private void newMenuItem_Click(object sender, EventArgs e)
        {
            if (dlgBrowseFolder.ShowDialog() == DialogResult.OK)
            {
                string rootFolderPath = dlgBrowseFolder.SelectedPath;

                bool resizeImages = MessageBox.Show("Do you want to generate web size and thumbnail size images?", "Resize Images?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;

                _presenter.LoadNewImagesFromFolder(rootFolderPath, resizeImages);
            }
        }

        private void openMenuItem_Click(object sender, EventArgs e)
        {
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                IndexFileName = dlgOpen.FileName;

                _presenter.LoadImagesFromIndexFile();
            }
        }

        private void saveMenuItem_Click(object sender, EventArgs e)
        {
            if (IndexFileName == null)
            {
                if (dlgSave.ShowDialog() == DialogResult.OK)
                {
                    IndexFileName = dlgSave.FileName;
                }
                else
                {
                    return;
                }
            }

            _presenter.Save();
        }

        private void saveAsMenuItem_Click(object sender, EventArgs e)
        {
            if (dlgSave.ShowDialog() == DialogResult.OK)
            {
                IndexFileName = dlgSave.FileName;
                _presenter.Save();
            }
        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void fileMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            saveMenuItem.Enabled = Images != null;
            saveAsMenuItem.Enabled = Images != null;
        }

        private void dgvImages_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvImages.CurrentRow != null && ThumbnailFolderPath != null)
            {
                var img = (ImagesDataSet.ImagesRow)((DataRowView)dgvImages.CurrentRow.DataBoundItem).Row;
                pbPreview.ImageLocation = Path.Combine(ThumbnailFolderPath, img.FileName);
            }
        }
    }
}