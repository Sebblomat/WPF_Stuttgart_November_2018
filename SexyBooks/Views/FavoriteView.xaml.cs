using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Shapes;

namespace SexyBooks.Views
{
    /// <summary>
    /// Interaction logic for FavoriteView.xaml
    /// </summary>
    public partial class FavoriteView : Window
    {
        public FavoriteView()
        {
            InitializeComponent();
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Hyperlink link)
            {
                Process.Start(link.NavigateUri.AbsoluteUri);
            }
        }
    }
}
