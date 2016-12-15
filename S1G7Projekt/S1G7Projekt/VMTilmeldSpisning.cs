using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml;
using Windows.Devices.Bluetooth.Advertisement;
using Windows.UI.Xaml.Controls.Primitives;
using NoteModelOpg33;

namespace S1G7Projekt
{
    class VMTilmeldSpisning
    {
        public int SelectedDag { get; set; }
        public int SelectedHus { get; set; }

        public int AntalVoksne { get; set; }
        public int AntalBorn7_15 { get; set; }
        public int AntalBorn3_6 { get; set; }
        public int AntalBornU3 { get; set; }



        public List<String> Dag { get; set; }
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
            Load();
            
            InfoDictionary = new Dictionary<string, List<string>>();
            InputInfo = new List<string>();

            
            _relayCommandGem = new RelayCommand(GemTilmelding);
        }


        public async void Load()
        {
            HusNr = await FileHandler.LoadHusNrListeJsonAsync();
            Dag = await UgeHandler.getDagListe();
        }

        public void GemTilmelding()
        {
            try
            {
                if (SelectedHus != -1 && SelectedDag != -1)
                {
                        InputInfo.Clear();
                        InputInfo.Add($"{Dag[SelectedDag]}");
                        InputInfo.Add($"{AntalVoksne}");
                        InputInfo.Add($"{AntalBorn7_15}");
                        InputInfo.Add($"{AntalBorn3_6}");
                        InputInfo.Add($"{AntalBornU3}");

                        InfoDictionary.Clear();
                        InfoDictionary.Add(HusNr[SelectedHus], InputInfo);
                    
                        FileHandler.SaveTilmeldingJsonAsync(InfoDictionary);
                }
                else
                {
                    throw new ArgumentException();
                }
            }
            catch(ArgumentException)
            {
                throw new ArgumentException("Dag eller HusNR er ikke valgt");
            }
        }


        public async void LoadTilmelding()
        {
            if (SelectedHus != -1 & SelectedDag != -1)
            {
                Dictionary<String, List<String>> TempLoad = await FileHandler.LoadTilmeldingJsonAsync();

                foreach (KeyValuePair<string, List<string>> pair in TempLoad)
                {
                    if (pair.Key == HusNr[SelectedHus] && pair.Value[0] == Dag[SelectedDag])
                    {
                        AntalVoksne = int.Parse(pair.Value[1]);
                        AntalBorn7_15 = int.Parse(pair.Value[2]);
                        AntalBorn3_6 = int.Parse(pair.Value[3]);
                        AntalBornU3 = int.Parse(pair.Value[4]);
                    }
                }

            }
        }
    }
}
