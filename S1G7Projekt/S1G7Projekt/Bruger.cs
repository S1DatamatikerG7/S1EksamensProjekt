using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace S1G7Projekt
{
    class Bruger
    {
        public int BrugerID { get; set; }
        public String BrugerNavn { get; set; }
        public ObservableCollection<Bruger> BrugerListe;


        public Bruger()
        {
            
        }

        public Bruger(int brugerId, string brugerNavn)
        {
            BrugerID = brugerId;
            BrugerNavn = brugerNavn;
            Load();
        }

          public async void Load()
        {
            BrugerListe = await FileHandler.LoadBrugerJsonAsync();
        }

        public override string ToString()
        {
            return BrugerNavn;
        }
    }
}
