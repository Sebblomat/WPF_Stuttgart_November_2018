using SexyBooks.Helpers;
using SexyBooks.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SexyBooks.ViewModels
{
    public class ErgebnisViewModel : ModelBase
    {
        #region Properties

        private string _suchbegriff;
        public string Suchbegriff
        {
            get { return _suchbegriff; }
            set { SetValue(ref _suchbegriff, value); }
        }

        private ObservableCollection<Buch> _bücher;
        public ObservableCollection<Buch> Bücher
        {
            get { return _bücher; }
            set { SetValue(ref _bücher, value); }
        }

        public DelegateCommand AddFavoriteCommand { get; set; }
        #endregion

        public ErgebnisViewModel(ObservableCollection<Buch> bücher, string suchbegriff)
        {
            AddFavoriteCommand = new DelegateCommand(AddFavorite);
            Bücher = bücher;
            Suchbegriff = suchbegriff;
        }

        public ErgebnisViewModel()
        {

        }

        public void AddFavorite(object obj)
        {
            if (obj is Buch buch)
            {
                FavoritenManager.Instance.FügeBuchAlsFavoritHinzu(buch);
            }
        }
    }
}
