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
    class VMOpretBruger : INotifyPropertyChanged
    {
        public string BrugerNavn { get; set; }
        public string KodeOrd { get; set; }
        public int ID { get; set; }
        public ObservableCollection<Bruger> BrugerListe { get; set; }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        public VMOpretBruger()
        {
            _relayCommandOpretBruger = new RelayCommand(OpretBruger);
            _relayCommandFjernBruger = new RelayCommand(FjernBruger);
        }

        public void OpretBruger()
        {
            ID += ID;
            BrugerListe.Add(new Bruger(ID, BrugerNavn, KodeOrd));
        }

        public void FjernBruger()
        {
            BrugerListe.RemoveAt(ID);
        }
    }
}
