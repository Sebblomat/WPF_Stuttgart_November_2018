using System.Collections.ObjectModel;

namespace Städte_DataTemplates
{
    public class ViewModel
    {
        //Die Daten, an die man sich binden möchte, müssen immer Properties sein!
        //Klassenvariablen funktionieren nicht!
        public string UserName { get; set; } = "Alex";

        public ObservableCollection<Stadt> Städte { get; set; } = new ObservableCollection<Stadt>();

        //Standardkonstruktor ist sinnvoll, damit man das ViewModel notfalls auch im XAML initialiseren kann
        public ViewModel()
        {

        }

        public ViewModel(ObservableCollection<Stadt> stadt)
        {
            Städte = stadt;
        }


        public void MacheAlleStädteZuKreisstädten()
        {
            foreach (var item in Städte)
            {
                item.KreisStadt = true;
            }
        }

        public void RemoveElement(Stadt zuEntfernendeStadt)
        {
            Städte.Remove(zuEntfernendeStadt);
        }
    }
}
