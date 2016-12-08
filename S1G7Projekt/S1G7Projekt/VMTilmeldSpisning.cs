using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Bluetooth.Advertisement;

namespace S1G7Projekt
{
    class VMTilmeldSpisning
    {

        public String Dag { get; set; }

        public String HusNr { get; set; }

        public int AntalVoksne { get; set; }
        public int AntalBorn7_15 { get; set; }
        public int AntalBorn3_6 { get; set; }
        public int AntalBornU3 { get; set; }

        public Dictionary<String, List<string>> InfoDictionary;
        public List<String> InputInfo;

        public VMTilmeldSpisning()
        {
            InfoDictionary = new Dictionary<string, List<string>>();
            InputInfo = new List<string>();
        }

        public void GemTilmelding()
        {


            if (Dag != null)
            {
                if (HusNr != null)
                {
                    if (AntalVoksne != 0 || AntalBorn7_15 != 0 || AntalBorn3_6 != 0 || AntalBornU3 != 0)
                    {
                        InputInfo.Add($"{Dag}");
                        InputInfo.Add($"{AntalVoksne}");
                        InputInfo.Add($"{AntalBorn7_15}");
                        InputInfo.Add($"{AntalBorn3_6}");
                        InputInfo.Add($"{AntalBornU3}");

                        InfoDictionary.Add(HusNr, InputInfo);


                        FileHandler.Tilmelding(InfoDictionary);
                    }
                }
            }
        }
    }
}
