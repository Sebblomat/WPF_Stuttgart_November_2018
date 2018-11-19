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

namespace UserControl_BitPatternControl
{
    /// <summary>
    /// Interaction logic for BitPatternControl.xaml
    /// </summary>
    public partial class BitPatternControl : UserControl
    {
        public enum BitGrößen { _8 = 8, _16 = 16, _32 = 32 }

        public BitPatternControl()
        {
            InitializeComponent();
            spCheckboxen.AddHandler(CheckBox.ClickEvent, new RoutedEventHandler(UpdateValue), true);
        }

        private void UpdateValue(object sender, RoutedEventArgs e)
        {
            string binaryString = string.Empty;
            foreach (var item in spCheckboxen.Children)
            {
                if(item is CheckBox box)
                {
                    if (box.IsChecked == true)
                    {
                        binaryString += '1';
                    }
                    else
                        binaryString += '0';
                }
            }
            Value = Convert.ToInt32(binaryString, 2);
        }

        private BitGrößen _bits = BitGrößen._8;
        public BitGrößen Bits
        {
            get { return _bits; }
            set
            {
                _bits = value;
                RefreshCheckboxen();
            }
        }


        //Dependency Property
        //Erzeugung mit Snippet: propdp        
        public int Value
        {
            get { return (int)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(int), typeof(BitPatternControl), new PropertyMetadata(0,ValueChangedHandler));

        private static void ValueChangedHandler(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if(d is BitPatternControl control)
            {
                if (e.NewValue == e.OldValue)
                    return;

                control.UpdateBitValues();
            }
        }

        private void UpdateBitValues()
        {

            if (Value > Math.Pow(2, (int)Bits))
            {
                this.Background = Brushes.Red;
                return;
            }
            else
                this.Background = Brushes.Transparent;

            string binary = Convert.ToString(Value, 2);

            if(spCheckboxen.Children.Count > binary.Length)
            {
                int fehlendeStellen = spCheckboxen.Children.Count - binary.Length;
                for (int i = 0; i < fehlendeStellen; i++)
                {
                    binary = '0' + binary;
                }
            }

            for (int i = 0; i < spCheckboxen.Children.Count; i++)
            {
                if(spCheckboxen.Children[i] is CheckBox box)
                {
                    box.IsChecked = binary[i] == '0' ? false : true;
                }
            }
        }

        private void RefreshCheckboxen()
        {
            int anzahl = (int)Bits;
            spCheckboxen.Children.Clear();
            for (int i = 0; i < anzahl; i++)
            {
                CheckBox box = new CheckBox();
                box.Tag = Math.Pow(2, i);
                spCheckboxen.Children.Add(box);
            }
        }
    }
}