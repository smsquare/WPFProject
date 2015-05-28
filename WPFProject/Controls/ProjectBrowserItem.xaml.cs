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

using WPFProject.CORE;

namespace WPFProject.Controls
{
    /// <summary>
    /// Interaction logic for ProjectBrowserItem.xaml
    /// </summary>
    public partial class ProjectBrowserItem : UserControl
    {
        public string _Caption
        {
            get { return _lblCaption.Content as string; }
            set { _lblCaption.Content = value; }
        }

        public bool _Selected
        {
            get { return _itemSelect.Opacity == 1.0; }
            set { _itemSelect.Opacity = value ? 1.0 : 0.0; }
        }

        public void UpdateUI()
        {
            _Selected = (CORE.DataCore._SelectedProjectBrowserItem == CORE.DataCore._SelectedProjectBrowserTab + _Caption);
        }

        public ProjectBrowserItem()
        {
            InitializeComponent();
            CORE.EventCore._OnSelectedProjectBrowserItemChanged += _OnSelectedProjectBrowserItemChanged;
            UpdateUI();
        }

        void _OnSelectedProjectBrowserItemChanged(string parameter)
        {
            UpdateUI();
        }
        private void OnMouseEnter(object sender, MouseEventArgs e)
        {
            _itemHover.Opacity = 1.0;
        }

        private void OnMouseLeave(object sender, MouseEventArgs e)
        {
            _itemHover.Opacity = 0.0;
        }

        private void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            //TODO: Select item as currently selected browser item; Used to display this items info in property window.
            CORE.DataCore._SelectedProjectBrowserItem = CORE.DataCore._SelectedProjectBrowserTab + _Caption;
            CORE.EventCore.TriggerSelectedProjectBrowserItemChanged();
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            DataObject data = new DataObject();
            GameObject obj = new GameObject();
            obj.name = _Caption;
        }
    }
}
