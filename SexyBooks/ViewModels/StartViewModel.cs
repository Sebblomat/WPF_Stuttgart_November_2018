using SexyBooks.Helpers;
using SexyBooks.Models;
using SexyBooks.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SexyBooks.ViewModels
{
    public class StartViewModel : ModelBase
    {
        //Eigenschaften
        private string _suchbegriff;
        public string Suchbegriff
        {
            get { return _suchbegriff; }
            set { SetValue(ref _suchbegriff, value); }
        }

        //Interaktionen (Commands)
        public DelegateCommand SucheCommand { get; set; }
        public DelegateCommand FavoritenCommand { get; set; }


        public StartViewModel()
        {
            SucheCommand = new DelegateCommand(SucheBuch, Suchbar);
            FavoritenCommand = new DelegateCommand(ZeigeFavoriten, FavoritenVorhanden);

            //Kurzvariante mit Lambda
            //SucheCommand = new DelegateCommand(p => MessageBox.Show("wird gesucht"), p => !string.IsNullOrWhiteSpace(Suchbegriff));
            //FavoritenCommand = new DelegateCommand(p => MessageBox.Show("Favoriten!"));
        }

        public bool Suchbar(object p)
        {
            return !string.IsNullOrWhiteSpace(Suchbegriff);
        }

        public void SucheBuch(object p)
        {
            var bücher = BuchSucher.SucheBücher(Suchbegriff);
            Suchbegriff = bücher.Count.ToString();

            ErgebnisView view = new ErgebnisView();
            view.DataContext = new ErgebnisViewModel(bücher, Suchbegriff);
            view.Show();
        }

        public void ZeigeFavoriten(object p)
        {
            var favoriten = FavoritenManager.Instance.ZeigeBücherAn();
            FavoriteView view = new FavoriteView();
            view.DataContext = new FavoriteViewModel(favoriten);
            view.ShowDialog();
        }

        public bool FavoritenVorhanden(object p)
        {
            return FavoritenManager.Instance.ZeigeBücherAn().Count > 0;
        }
    }
}