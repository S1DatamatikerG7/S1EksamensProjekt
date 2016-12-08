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
        private ObservableCollection<Ret> _retJobBeskrivelser;

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        public ObservableCollection<Ret> RetJob_Beskrivelser
        {
            get { return _retJobBeskrivelser; }
            set { _retJobBeskrivelser = value; }
        }

        public string Mandag { get; set; }
        public string Tirsdag { get; set; }
        public string Onsdag { get; set; }
        public string Torsdag { get; set; }
        public int Uge { get; set; }

        public næsteuge()
        {
            _retJobBeskrivelser = new ObservableCollection<Ret>();
            Mandag = "Mandag";
            Tirsdag = "Tirsdag";
            Onsdag = "Onsdag";
            Torsdag = "Torsdag";
            Uge = UgeHandler.GetNaesteUge;
        }
    }
}
