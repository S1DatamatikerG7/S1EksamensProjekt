using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using NoteModelOpg33;

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
        public int SelectedJob { get; set; }
        public int SelectedJobType { get; set; }

        public VMNaesteUgePlan()
        {
            _relayCommandTilfoejRedigereRet = new RelayCommand(TilfoejRedigereRet);
            _relayCommandTilfoejJob = new RelayCommand(TilfoejJob);
            _relayCommandFjernJob = new RelayCommand(FjernJob);

            _retJobBeskrivelser = new ObservableCollection<Job>();
            DagList = new List<string>();
            JobTypeList = new List<string>();

            LoadAlt();

            RetTekstBox = null;
            Navn = null;
            SelectedDag = null;
            UgeNr = UgeHandler.GetNaesteUge;

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
                default:
                    throw new ArgumentException("Vælg Dag");
                    break;
                    FileHandler.SaveRetListJsonAsync();
            }                               //TODO: skrive til fil
        }
                                            //TODO: for tilfoej og fjern skal laves færdigt og skrive til fil
        public void TilfoejJob()
        {
            switch (DagList[SelectedDag])
            {
                case "Mandag":
                    MandagList.Add();
                    break;
                case "Tirsdag":
                    TirsdagList.Add();
                    break;
                case "Onsdag":
                    OnsdagList.Add();
                    break;
                case "Torsdag":
                    TorsdagList.Add();
                    break;
                //default:
                //    throw new ArgumentException("Vælg Dag");
                //    break;
                    FileHandler.SaveMandagJobListJsonAsync(MandagList);
                    FileHandler.SaveTirsdagJobListJsonAsync(TirsdagList);
                    FileHandler.SaveOnsdagJobListJsonAsync(OnsdagList);
                    FileHandler.SaveTorsdagJobListJsonAsync(TorsdagList);
            }
        }

        public void FjernJob()
        {
            switch (DagList[SelectedDag])
            {
                case "Mandag":
                    MandagList.RemoveAt();
                    break;
                case "Tirsdag":
                    TirsdagList.RemoveAt();
                    break;
                case "Onsdag":
                    OnsdagList.RemoveAt();
                    break;
                case "Torsdag":
                    TorsdagList.RemoveAt();
                    break;
                //default:
                //   throw new ArgumentException("Vælg Dag");
                //    break;
                    FileHandler.SaveMandagJobListJsonAsync(MandagList);
                    FileHandler.SaveTirsdagJobListJsonAsync(TirsdagList);
                    FileHandler.SaveOnsdagJobListJsonAsync(OnsdagList);
                    FileHandler.SaveTorsdagJobListJsonAsync(TorsdagList);
            }
       }
    }
}
