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

namespace WPFProject.Controls
{
    /// <summary>
    /// Interaction logic for ProjectBrowserTab.xaml
    /// </summary>
    public partial class ProjectBrowserTab : UserControl
    {
        public string _Caption
        {
            get { return _lblCaption.Content as string; }
            set { _lblCaption.Content = value; }
        }

        public bool _Selected
        {
            // _selected is the user interface component in the XAML.
            get { return _selected.Opacity == 1.0; }
            set { _selected.Opacity = value ? 1.0 : 0.0; }
        }

        public void UpdateUI()
        {
            _Selected = (CORE.DataCore._SelectedProjectBrowserTab == _Caption);
        }

        public ProjectBrowserTab()
        {
            InitializeComponent();
            CORE.EventCore._OnSelectedProjectBrowserTabChanged += _OnSelectedProjectBrowserTabChanged;
            UpdateUI();
        }

        void _OnSelectedProjectBrowserTabChanged(string parameter)
        {
            UpdateUI();
        }

        private void OnMouseEnter(object sender, MouseEventArgs e)
        {
            _hover.Opacity = 1.0;
        }

        private void OnMouseLeave(object sender, MouseEventArgs e)
        {
            _hover.Opacity = 0.0;
        }

        private void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            CORE.DataCore._SelectedProjectBrowserTab = _Caption;
            CORE.EventCore.TriggerSelectedProjectBrowserTabChanged();

            CORE.DataCore._CurrentProjectSubDirectory = _Caption;
            CORE.EventCore.TriggerProjectSubDirectoryChanged();
        }
    }
}
