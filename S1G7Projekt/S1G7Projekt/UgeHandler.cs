using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S1G7Projekt
{
    class UgeHandler
    {
        private static int Uge { get; set; }
        private static List<string> DagListe { get; set; }

        public UgeHandler()
        {
            Uge = 42;

            DagListe[0] = "Mandag";
            DagListe[1] = "Tirsdag";
            DagListe[2] = "Onsdag";
            DagListe[3] = "Torsdag";
        }

        public static int GetNaesteUge()
        {
            return Uge;
        }

        public static List<string> GetDagListe()
        {
            return DagListe;
        }
    }
}
