using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Städte_DataTemplates
{
    public class Stadt : INotifyPropertyChanged
    {
        public enum Stadtgrößen { Kaff, Dorf, Kleinstadt, Großstadt, Metropolis }

        //Snippet: propfull
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
            }
        }

        private bool _kreisstadt;
        public bool KreisStadt
        {
            get { return _kreisstadt; }
            set
            {
                _kreisstadt = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(KreisStadt)));
            }
        }

        private Stadtgrößen _größe;
        public Stadtgrößen Größe
        {
            get { return _größe; }
            set { _größe = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Größe)));
            }
        }

        private static List<Stadtgrößen> _möglicheStadtgrößen = new List<Stadtgrößen>()
        {
            Stadtgrößen.Kaff,
            Stadtgrößen.Dorf,
            Stadtgrößen.Kleinstadt,
            Stadtgrößen.Großstadt,
            Stadtgrößen.Metropolis
        };


        public List<Stadtgrößen> MöglicheStadtgrößem
        {
            get
            {
                return _möglicheStadtgrößen;
            }
        }


        private string _foto;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Foto
        {
            get { return _foto; }
            set { _foto = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Foto)));
            }
        }


        public Stadt()
        {

        }

        public Stadt(string name, bool kreisstadt, Stadtgrößen größe, string foto)
        {
            Name = name;
            KreisStadt = kreisstadt;
            Größe = größe;
            Foto = foto;
        }

    }
}
