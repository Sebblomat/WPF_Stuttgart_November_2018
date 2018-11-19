using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace HelloWorld
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        Random random = new Random();

        private void Main_Button_Click(object sender, RoutedEventArgs e)
        {
            
            mainGrid.Background = Brushes.Aqua;

            //Starte Thread der jede Sekunde einen neuen Button mit zufälliger Ausrichtung anzeigt
            Task.Factory.StartNew((Action)(() =>
            {
                Button neuerButton = null;
                for (int i = 0; i < 5; i++)
                {
                    this.Dispatcher.Invoke((Action)(() =>
                    {

                    neuerButton = new Button();
                        
                        neuerButton.HorizontalAlignment = (HorizontalAlignment)random.Next(0, 4);
                        neuerButton.VerticalAlignment = (VerticalAlignment)random.Next(0, 4);
                        neuerButton.Content = "Neuer Button";
                        //Dem Event-Delegaten eine Methode hinzufügen
                        neuerButton.Click += NeuerButton_Click;
                       
                        //ThicknessConverter converter = new ThicknessConverter();
                        //neuerButton.Margin = (Thickness)converter.ConvertFrom("10");
                        neuerButton.Margin = new Thickness(2, 5, 4, 10);
                        mainGrid.Children.Add(neuerButton);
                    }));
                    Thread.Sleep(1500);
                    this.Dispatcher.Invoke(() =>
                    {

                        mainGrid.Children.Remove(neuerButton);
                    });
                }
            }));

        }

        
        private void NeuerButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Gefangen!");
        }
    }
}