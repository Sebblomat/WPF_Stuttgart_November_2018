using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SexyBooks.Models
{
    public class BuchSucher
    {
        public static ObservableCollection<Buch> SucheBücher(string suchbegriff)
        {
            try
            {
                HttpClient client = new HttpClient();
                string json = client.GetStringAsync("https://www.googleapis.com/books/v1/volumes?q=" + suchbegriff).Result;

                //Json -> C# = Deserialisierung
                BuchErgebnis ergebnis = JsonConvert.DeserializeObject<BuchErgebnis>(json);

                ObservableCollection<Buch> bücher = new ObservableCollection<Buch>(ergebnis.items);
                return bücher;
            }
            catch (Exception exp)
            {
                //Nicht MVVM-Kompatibel!! Nur für Test-Zwecke
                MessageBox.Show(exp.Message);
                return new ObservableCollection<Buch>();
            }
        }
    }
}