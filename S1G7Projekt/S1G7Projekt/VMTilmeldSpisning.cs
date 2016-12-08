using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Devices.Bluetooth.Advertisement;
using NoteModelOpg33;

namespace S1G7Projekt
{
    class VMTilmeldSpisning
    {

        public String Dag { get; set; }


        public int SelectedHus { get; set; }

        public int AntalVoksne { get; set; }
        public int AntalBorn7_15 { get; set; }
        public int AntalBorn3_6 { get; set; }
        public int AntalBornU3 { get; set; }




        public List<String> HusNr { get; set; }
        public Dictionary<String, List<string>> InfoDictionary;
        public List<String> InputInfo;


        private RelayCommand _relayCommandGem;

        public RelayCommand RelayCommandGem
        {
            get { return _relayCommandGem; }
            set { _relayCommandGem = value; }
        }


        public VMTilmeldSpisning()
        {
            HusNr = FileHandler.getHusListe();
            SelectedHus = 0;
            InfoDictionary = new Dictionary<string, List<string>>();
            InputInfo = new List<string>();




            _relayCommandGem = new RelayCommand(GemTilmelding);
        }

        public void GemTilmelding()
        {
            if (Dag != null || HusNr != null)
            {
                if (AntalVoksne != 0 || AntalBorn7_15 != 0 || AntalBorn3_6 != 0 || AntalBornU3 != 0)
                {
                    InputInfo.Add($"{Dag}");
                    InputInfo.Add($"{AntalVoksne}");
                    InputInfo.Add($"{AntalBorn7_15}");
                    InputInfo.Add($"{AntalBorn3_6}");
                    InputInfo.Add($"{AntalBornU3}");

                    InfoDictionary.Add(HusNr[SelectedHus], InputInfo);


                    FileHandler.Tilmelding(InfoDictionary);
                }
                else
                {
                    //TODO: Exception
                }
            }
        }


        public Dictionary<string, List<string>> LoadTilmelding()
        {
            //TODO: Load

            return null;
        }
    }
}
