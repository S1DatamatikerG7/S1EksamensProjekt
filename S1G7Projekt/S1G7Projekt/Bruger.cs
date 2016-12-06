using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S1G7Projekt
{
    class Bruger
    {
        public int BrugerID { get; set; }
        public String HusNr { get; set; }
        public String Kodeord { get; set; }


        public Bruger()
        {
            
        }

        public Bruger(int brugerId, string husNr, string kodeord)
        {
            BrugerID = brugerId;
            HusNr = husNr;
            Kodeord = kodeord;
        }

    }
}
