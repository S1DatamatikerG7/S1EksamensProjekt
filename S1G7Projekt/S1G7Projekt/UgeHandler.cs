using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S1G7Projekt
{
    class UgeHandler
    {
        public int Uge { get; set; }
        public List<string> DagListe { get; set; }

        public UgeHandler()
        {
            Uge = 42;

            DagListe[0] = "Mandag";
            DagListe[1] = "Tirsdag";
            DagListe[2] = "Onsdag";
            DagListe[3] = "Torsdag";
        }

        public int GetNaesteUge()
        {
            return Uge;
        }

        public List<string> GetDagListe()
        {
            return DagListe;
        }
    }
}
