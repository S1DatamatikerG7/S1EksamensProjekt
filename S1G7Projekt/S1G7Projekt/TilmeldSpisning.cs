using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S1G7Projekt
{
    class TilmeldSpisning
    {

        public String Dag { get; set; }

        public String HusNr { get; set; }

        public int AntalVoksne { get; set; }
        public int AntalBorn7_15 { get; set; }
        public int AntalBorn3_6 { get; set; }
        public int AntalBornU3 { get; set; }


        //public List<Bruger> BrugerListe;

        public TilmeldSpisning()
        {
            //BrugerListe = FileHandler.getBrugerListe
        }

        public void GemTilmelding()
        {
            if (Dag != null)
            {
                if (HusNr != null)
                {
                    if (AntalVoksne != 0 || AntalBorn7_15 != 0 || AntalBorn3_6 != 0 || AntalBornU3 != 0)
                    {
                        FileHandler.Tilmelding(Dag, HusNr, AntalVoksne, AntalBorn7_15, AntalBorn3_6, AntalBornU3);
                    }
                }
            }
        }
    }
}
