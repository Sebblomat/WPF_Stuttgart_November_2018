using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SexyBooks.Models
{
    public class FavoritenManager
    {
        public static object dummy = 4;

        private static FavoritenManager _favoritenManager = null;

        public static FavoritenManager Instance
        {
            get
            {
                //Thread-Sicher
                lock (dummy)
                {
                    if (_favoritenManager == null)
                    {
                        _favoritenManager = new FavoritenManager();
                    }
                }
                return _favoritenManager;
            }
        }

        public ObservableCollection<Buch> Favoriten { get; set; }

        private FavoritenManager()
        {
            Favoriten = new ObservableCollection<Buch>();

            try
            {
                if (File.Exists(FILE_NAME))
                {
                    using (StreamReader reader = new StreamReader(FILE_NAME))
                    {
                        string json = reader.ReadToEnd();
                        Favoriten = JsonConvert.DeserializeObject<ObservableCollection<Buch>>(json);
                    }
                }
            }
            catch (Exception exp)
            {

            }
        }

        public bool FügeBuchAlsFavoritHinzu(Buch buch)
        {
            foreach (var item in Favoriten)
            {
                if (item.id == buch.id)
                {
                    return false;
                }
            }
            Favoriten.Add(buch);
            SpeicherFavoriten();
            return true;
        }

        public bool EntferneBuchAusFavoriten(Buch buch)
        {
            Buch zulöschendesBuch = null;
            foreach (var item in Favoriten)
            {
                if (item.id == buch.id)
                {
                    zulöschendesBuch = item;
                }
            }
            if (zulöschendesBuch != null)
            {
                Favoriten.Remove(zulöschendesBuch);
                SpeicherFavoriten();
                return true;
            }
            else
                return false;
        }

        public const string FILE_NAME = "favoriten.fv";

        private bool SpeicherFavoriten()
        {
            try
            {
                string json = JsonConvert.SerializeObject(Favoriten);
                using (StreamWriter writer = new StreamWriter(FILE_NAME))
                {
                    writer.Write(json);
                }
            }
            catch (Exception exp)
            {
                return false;
            }
            return true; 
        }

        public ObservableCollection<Buch> ZeigeBücherAn()
        {
            return Favoriten;
        }
    }
}
