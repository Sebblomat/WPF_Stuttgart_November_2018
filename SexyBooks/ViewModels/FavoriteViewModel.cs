using SexyBooks.Helpers;
using SexyBooks.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SexyBooks.ViewModels
{
    public class FavoriteViewModel : ModelBase
    {
        #region Properties

        private ObservableCollection<Buch> _bücher;
        public ObservableCollection<Buch> Bücher
        {
            get { return _bücher; }
            set { SetValue(ref _bücher, value); }
        }

        public DelegateCommand RemoveFavoriteCommand { get; set; }
        #endregion

        public FavoriteViewModel(ObservableCollection<Buch> bücher)
        {
            RemoveFavoriteCommand = new DelegateCommand(RemoveFavorite);
            Bücher = bücher;
        }

        public void RemoveFavorite(object obj)
        {
            if (obj is Buch buch)
            {
                FavoritenManager.Instance.EntferneBuchAusFavoriten(buch);
            }
        }
    }
}
