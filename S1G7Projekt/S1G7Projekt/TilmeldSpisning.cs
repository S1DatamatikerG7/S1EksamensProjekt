using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S1G7Projekt
{
    class TilmeldSpisning
    {
        public int MaVoksen { get; set; }
        public int TiVoksen { get; set; }
        public int OnVoksen { get; set; }
        public int ToVoksen { get; set; }

        public int MaBorn7_15 { get; set; }
        public int TiBorn7_15 { get; set; }
        public int OnBorn7_15 { get; set; }
        public int ToBorn7_15 { get; set; }

        public int MaBorn3_6 { get; set; }
        public int TiBorn3_6 { get; set; }
        public int OnBorn3_6 { get; set; }
        public int ToBorn3_6 { get; set; }

        public int MaBorn2_0 { get; set; }
        public int TiBorn2_0 { get; set; }
        public int OnBorn2_0 { get; set; }
        public int ToBorn2_0 { get; set; }

        public TilmeldSpisning()
        {

        }

        public void GemTilmelding()
        {
            Filhandler.Tilmelding(MaVoksen, MaBorn7_15, MaBorn3_6, MaBorn2_0, TiVoksen, TiBorn7_15, TiBorn3_6, TiBorn2_0, OnVoksen, OnBorn7_15, OnBorn3_6, OnBorn2_0, ToVoksen, ToBorn7_15, ToBorn3_6, ToBorn2_0)
        }






    }
}
