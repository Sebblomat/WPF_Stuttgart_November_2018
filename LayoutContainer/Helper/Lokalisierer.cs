using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayoutContainer.Helper
{
    class Lokalisierer
    {
        public enum Sprachen {Deutsch, Englisch }

        public string  Value { get; set; }
        public Sprachen Sprache { get; set; }


        public override string ToString()
        {
            if(Sprache == Sprachen.Deutsch)
            {
                return $"\"{Value}\" in Deutsch";
            }
            else
                return $"\"{Value}\" in Englisch";
        }
    }
}
