using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Städte_DataTemplates
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Hole Daten aus DB
            var städte = HoleStädteAusDB();
            ViewModel model = new ViewModel(städte);
            model.UserName = tbUserName.Text;

            StädteWindow window = new StädteWindow(model);
            window.ShowDialog();
        }

        private ObservableCollection<Stadt> HoleStädteAusDB()
        {
            return new ObservableCollection<Stadt>()
            {
                new Stadt("Stuttgart", true, Stadt.Stadtgrößen.Großstadt, "https://cdn1.stuttgarter-nachrichten.de/media.media.ffc33fb6-d21a-4a9b-936f-cba281a1228d.normalized.jpg"),
                new Stadt("Heidelberg", false, Stadt.Stadtgrößen.Kleinstadt, "https://www.rnz.de/cms_media/module_img/547/273569_2_org_Weihnachtsmarkt_Universtitaetsplatz_Heidelberg_Marketing_GmbH_Foto_Jan_Becke.jpg"),
                new Stadt("Tokyo", true, Stadt.Stadtgrößen.Metropolis, "https://tokyotreat.cdn.prismic.io/tokyotreat/d7041cd531a667946d64e993eaf71c4aa022a8a4_111.jpg")
            };
        }

    }
}
