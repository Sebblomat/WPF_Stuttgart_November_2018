using SpecialStackPanel;
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

namespace Lokalisierung
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            InitializeComponent();
            //Attached Properties per 
            //UniformSize.SetUnfiformChildren(stackpanel1, true);
            //Grid.SetRow(this, 2);
            //Canvas.SetTop(this, 4);
            //DockPanel.GetDock(this);
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (sender is Slider slider)
            {
                this.Resources["windowFontSize"] = slider.Value;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            sliderFontSize.Value = (double)this.Resources["windowFontSize"];
            sliderFontSize.ValueChanged += Slider_ValueChanged;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(sender is ComboBox cbox)
            {
                string language = ((ComboBoxItem)cbox.SelectedItem).Content.ToString();

                if(language == "Deutsch")
                {
                    //https://docs.microsoft.com/de-de/dotnet/framework/wpf/app-development/pack-uris-in-wpf
                    Application.Current.Resources.MergedDictionaries[0].Source = new Uri("pack://application:,,,/Languages/German.xaml");
                }
                else
                {
                    Application.Current.Resources.MergedDictionaries[0].Source = new Uri("pack://application:,,,/Languages/French.xaml");
                }
                new MainWindow().Show();
                this.Close();
            }
        }
    }
}