using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.IO;

namespace WPFProject.Controls
{
    /// <summary>
    /// Interaction logic for ProjectFileBrowser.xaml
    /// </summary>
    public partial class ProjectFileBrowser : UserControl
    {
        public ProjectFileBrowser()
        {
            InitializeComponent();
            CORE.EventCore._OnProjectSubDirectoryChanged += _OnProjectSubDirectoryChanged;
            LoadData();
        }

        void _OnProjectSubDirectoryChanged(string parameter)
        {
            LoadData();
        }

        private void LoadData()
        {
            _stackFiles.Children.Clear();
            IEnumerable<string> list = null;
            try
            {
                list = Directory.EnumerateFiles(CORE.DataCore._CurrentProjectDirectory);
                foreach (string item in list)
                {
                    ProjectBrowserItem listItem = new ProjectBrowserItem();
                    listItem._Caption = CORE.DATA.GetSafeFileName(item);
                    // Load image dynamically
                    string path = System.IO.Path.Combine(Environment.CurrentDirectory, "Assets", "DefaultProject", CORE.DataCore._CurrentProjectSubDirectory, listItem._Caption + '.' + CORE.DATA.GetSafeFileExtension(item));
                    Uri uri = new Uri(path);
                    BitmapImage image = new BitmapImage(uri);
                    listItem._imgDetail.Source = image;

                    // This is so if a ProjectBrowserItem is already selected, it will correctly draw in the UI as being selected.
                    listItem.UpdateUI();

                    _stackFiles.Children.Add(listItem);
                }
            }
            catch (System.Exception ex)
            {
                return;
            }
        }
    }
}
