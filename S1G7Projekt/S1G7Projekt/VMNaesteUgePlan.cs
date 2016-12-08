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
        public int UgeNr { get; set; }
        public List<string> JobTypeList { get; set; }
        public List<string> DagList { get; set; }
        public string Name { get; set; }

        public VMNaesteUgePlan()
        {
            _relayCommandTilfoejRedigereRet = new RelayCommand(TilfoejRedigereRet);
            _relayCommandTilfoejJob = new RelayCommand(TilfoejJob);
            _relayCommandFjernJob = new RelayCommand(FjernJob);

            _retJobBeskrivelser = new ObservableCollection<Job>();
            DagList = new List<string>();
            JobTypeList = new List<string>();
            RetTekstBox = null;
            Name = null;
            UgeNr = UgeHandler.GetNaesteUge;
        }

        public void TilfoejRedigereRet()
        {
            switch (DagList)
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
                //    break;
            }                               //TODO: exception handling og skrive til fil
        }

        public void TilfoejJob()
        {
            
        }

        public void FjernJob()
        {
            
        }

    }
}
