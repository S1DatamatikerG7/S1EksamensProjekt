using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace S1G7Projekt
{
    class VMNaesteUgePlan : INotifyPropertyChanged
    {
        private ObservableCollection<Job> _retJobBeskrivelser;
        private RelayCommand _relayCommandTilfoejRedigereRet;
        private RelayCommand _relayCommandTilfoejJob;
        private RelayCommand _relayCommandFjernJob;

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        public ObservableCollection<Job> RetJob_Beskrivelser
        {
            get { return _retJobBeskrivelser; }
            set { _retJobBeskrivelser = value; }
        }

        public RelayCommand RelayCommandTilfoejRedigereRet
        {
            get { return _relayCommandTilfoejRedigereRet; }
            set { _relayCommandTilfoejRedigereRet = value; }
        }

        public RelayCommand RelayCommandTilfoejJob
        {
            get { return _relayCommandTilfoejJob; }
            set { _relayCommandTilfoejJob = value; }
        }

        public RelayCommand RelayCommandFjernJob
        {
            get { return _relayCommandFjernJob; }
            set { _relayCommandFjernJob = value; }
        }

        public string RetTekstBox { get; set; }
        public string RetMandag { get; set; }
        public string RetTirsdag { get; set; }
        public string RetOnsdag { get; set; }
        public string RetTorsdag { get; set; }

        public List<string> RetList { get; set; }
        public List<string> MandagList { get; set; }
        public List<string> TirsdagList { get; set; }
        public List<string> OnsdagList { get; set; }
        public List<string> TorsdagList { get; set; }

        public int UgeNr { get; set; }
        public List<string> JobTypeList { get; set; }
        public List<string> DagList { get; set; }
        public string Navn { get; set; }
        public int SelectedDag { get; set; }
        public int SelectedJobType { get; set; }
        public int SelectedItem { get; set; }


        public VMNaesteUgePlan()
        {
            _relayCommandTilfoejRedigereRet = new RelayCommand(TilfoejRedigereRet);
            _relayCommandTilfoejJob = new RelayCommand(TilfoejJob);
            _relayCommandFjernJob = new RelayCommand(FjernJob);

            _retJobBeskrivelser = new ObservableCollection<Job>();
            DagList = new List<string>();
            JobTypeList = new List<string>();

            LoadAlt();

            SelectedItem = -1;

            RetTekstBox = null;
            Navn = null;
            UgeNr = UgeHandler.GetNaesteUge();

            RetMandag = RetList[0];
            RetTirsdag = RetList[1];
            RetOnsdag = RetList[2];
            RetTorsdag = RetList[3];
        }
        
        public async void LoadAlt()
        {
            RetList = await FileHandler.LoadRetListJsonAsync();
            MandagList = await FileHandler.LoadMandagJobListJsonAsync();
            TirsdagList = await FileHandler.LoadTirsdagJobListJsonAsync();
            OnsdagList = await FileHandler.LoadOnsdagJobListJsonAsync();
            TorsdagList = await FileHandler.LoadTorsdagJobListJsonAsync();

        }

        public void TilfoejRedigereRet()
        {
            switch (DagList[SelectedDag])
            {
                case "Mandag":
                    RetMandag = RetTekstBox;
                    break;
                case "Tirsdag":
                    RetTirsdag = RetTekstBox;
                    break;
                case "Onsdag":
                    RetOnsdag = RetTekstBox;
                    break;
                case "Torsdag":
                    RetTorsdag = RetTekstBox;
                    break;
                //default:
                //    throw new ArgumentException("Vælg Dag");
                //    break;
            }
            RetList[0] = RetMandag;
            RetList[1] = RetTirsdag;
            RetList[2] = RetOnsdag;
            RetList[3] = RetTorsdag;
            FileHandler.SaveRetListJsonAsync(RetList);
        }

        public void TilfoejJob()
        {
            switch (DagList[SelectedDag])
            {
                case "Mandag":
                    MandagList.Add($"{ JobTypeList[SelectedJobType]}\n{Navn}");
                    break;
                case "Tirsdag":
                    TirsdagList.Add($"{ JobTypeList[SelectedJobType]}\n{Navn}");
                    break;
                case "Onsdag":
                    OnsdagList.Add($"{ JobTypeList[SelectedJobType]}\n{Navn}");
                    break;
                case "Torsdag":
                    TorsdagList.Add($"{ JobTypeList[SelectedJobType]}\n{Navn}");
                    break;
                //default:
                //    throw new ArgumentException("Vælg Dag");
                //    break;
            }
            FileHandler.SaveMandagJobListJsonAsync(MandagList);
            FileHandler.SaveTirsdagJobListJsonAsync(TirsdagList);
            FileHandler.SaveOnsdagJobListJsonAsync(OnsdagList);
            FileHandler.SaveTorsdagJobListJsonAsync(TorsdagList);
        }

        public void FjernJob()
        {
            switch (DagList[SelectedDag])
            {
                case "Mandag":
                    MandagList.RemoveAt(SelectedItem);
                    break;
                case "Tirsdag":
                    TirsdagList.RemoveAt(SelectedItem);
                    break;
                case "Onsdag":
                    OnsdagList.RemoveAt(SelectedItem);
                    break;
                case "Torsdag":
                    TorsdagList.RemoveAt(SelectedItem);
                    break;
                //default:
                //   throw new ArgumentException("Vælg Dag");
                //    break;
            }
            FileHandler.SaveMandagJobListJsonAsync(MandagList);
            FileHandler.SaveTirsdagJobListJsonAsync(TirsdagList);
            FileHandler.SaveOnsdagJobListJsonAsync(OnsdagList);
            FileHandler.SaveTorsdagJobListJsonAsync(TorsdagList);
        }
    }
}
