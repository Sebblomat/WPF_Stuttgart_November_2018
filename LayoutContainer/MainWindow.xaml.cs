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

namespace LayoutContainer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string _haarfarbe = "keine";

        public MainWindow()
        {
            InitializeComponent();
            cbGeschlecht.Items.Add(Geschlechter.Männlich);
            cbGeschlecht.Items.Add(Geschlechter.Weiblich);
            cbGeschlecht.Items.Add(Geschlechter.Sonstiges);
            cbGeschlecht.SelectedItem = Geschlechter.Männlich;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = tbName.Text;
            //Referenztypen (class) und Wertetypen (struct)
            //? steht für Nullable-Typen: http://www.tutorialsteacher.com/csharp/csharp-nullable-types
            DateTime? geburtsdatum = datepicker.SelectedDate;

            Geschlechter geschlecht = (Geschlechter)cbGeschlecht.SelectedItem;

            //Interpolated Strings
            MessageBox.Show($"Person namens {name} ({geschlecht}), geboren am {geburtsdatum:d}, Haarfarbe: {_haarfarbe}");
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if(e.OriginalSource is RadioButton rb)
            {
                _haarfarbe = rb.Content.ToString();
            }
            
        }
    }

    public enum Geschlechter { Männlich, Weiblich, Sonstiges };
}
