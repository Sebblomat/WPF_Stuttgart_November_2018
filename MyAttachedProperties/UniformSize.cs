using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace SpecialStackPanel
{
    public class UniformSize : DependencyObject
    {
        public static bool GetUnfiformChildren(DependencyObject obj)
        {
            return (bool)obj.GetValue(UnfiformChildrenProperty);
        }

        public static void SetUnfiformChildren(DependencyObject obj, bool value)
        {
            obj.SetValue(UnfiformChildrenProperty, value);
        }

        // Using a DependencyProperty as the backing store for UnfiformChildren.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UnfiformChildrenProperty =
            DependencyProperty.RegisterAttached("UnfiformChildren", typeof(bool), typeof(UniformSize), new PropertyMetadata(false, new PropertyChangedCallback(Changed)));

        private static void Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue != e.OldValue && (bool)e.NewValue == true)
            {
                if (d is StackPanel panel)
                {
                    panel.LayoutUpdated += (sen, args) =>
                    {

                        //Maximale Breite berechnen bei Orientation Horizontal
                        if (panel.Orientation == Orientation.Horizontal)
                        {
                            List<double> actualWidths = new List<double>();
                            foreach (var item in panel.Children)
                            {
                                if (item is FrameworkElement element)
                                {
                                    actualWidths.Add(element.ActualWidth);
                                }
                            }
                            double maxActualWidth = actualWidths.Max();
                            foreach (var item in panel.Children)
                            {
                                if (item is FrameworkElement element)
                                {
                                    element.Width = maxActualWidth;
                                }
                            }
                        }
                        //Maximale Höhe berechnen bei Orientation Vertical
                        else if (panel.Orientation == Orientation.Vertical)
                        {
                            List<double> actualHeights = new List<double>();
                            foreach (var item in panel.Children)
                            {
                                if (item is FrameworkElement element)
                                {
                                    actualHeights.Add(element.ActualHeight);
                                }
                            }
                            double maxActualHeight = actualHeights.Max();
                            foreach (var item in panel.Children)
                            {
                                if (item is FrameworkElement element)
                                {
                                    element.Height = maxActualHeight;
                                }
                            }
                        }
                    };
                }
            }
        }
    }
}