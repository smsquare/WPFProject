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
    /// Interaction logic for MaximizeButton.xaml
    /// </summary>
    public partial class MaximizeButton : UserControl
    {
        public MaximizeButton()
        {
            InitializeComponent();
        }

        private void OnMouseEnter(object sender, MouseEventArgs e)
        {
            this._imgHover.Opacity = 1;
        }

        private void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            this._imgPress.Opacity = 1;
        }

        private void OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            this._imgPress.Opacity = 0;
            if (Application.Current.MainWindow.WindowState != WindowState.Maximized)
            {
                Application.Current.MainWindow.WindowState = WindowState.Maximized;
            }
            else if (Application.Current.MainWindow.WindowState == WindowState.Maximized)
            {
                Application.Current.MainWindow.WindowState = WindowState.Normal;
            }
        }

        private void OnMouseLeave(object sender, MouseEventArgs e)
        {
            this._imgHover.Opacity = 0;
            this._imgPress.Opacity = 0;
        }
    }
}
