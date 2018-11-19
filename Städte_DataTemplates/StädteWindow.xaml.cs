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
using System.Windows.Shapes;

namespace Städte_DataTemplates
{
    /// <summary>
    /// Interaction logic for StädteWindow.xaml
    /// </summary>
    public partial class StädteWindow : Window
    {
        public StädteWindow(ViewModel model)
        {
            InitializeComponent();
            //DataContext für das Window wird gesetzt
            this.DataContext = model;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(this.DataContext is ViewModel model)
            {
                model.MacheAlleStädteZuKreisstädten();
            }
        }

        private void Löschen_Button_Click(object sender, RoutedEventArgs e)
        {
            if (listboxStädte.SelectedItem == null)
                return;

            if (this.DataContext is ViewModel model)
            {
                model.RemoveElement((Stadt)listboxStädte.SelectedItem);
            }
        }
    }
}