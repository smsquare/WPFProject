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
    /// Interaction logic for ProjectBrowserTabs.xaml
    /// </summary>
    public partial class ProjectBrowserTabs : UserControl
    {
        public ProjectBrowserTabs()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            IEnumerable<string> list = null;
            try
            {
                list = System.IO.Directory.EnumerateDirectories(CORE.DataCore._CurrentProjectRootDirectory);
            }
            catch (System.Exception ex)
            {
                return;
            }
            foreach (string item in list)
            {
                ProjectBrowserTab listItem = new ProjectBrowserTab();
                listItem._Caption = CORE.DATA.GetSafeFileName(item);
                _stackTabs.Children.Add(listItem);
                listItem.UpdateUI();
            }
        }
    }
}
