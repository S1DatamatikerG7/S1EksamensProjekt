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
    class VMUgePlan : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        public List<string> MandagList { get; set; }
        public List<string> TirsdagList { get; set; }
        public List<string> OnsdagList { get; set; }
        public List<string> TorsdagList { get; set; }
        public List<string> RetList { get; set; }
        public List<string> DagList { get; set; }
        public int UgeNr { get; set; }
        
        public VMUgePlan()
        {
            DagList = new List<string>();
            loadUgePlan();
        }

        public async void loadUgePlan()
        {
            RetList = await FileHandler.LoadRetListJsonAsync();
            MandagList = await FileHandler.LoadMandagJobListJsonAsync();
            TirsdagList = await FileHandler.LoadTirsdagJobListJsonAsync();
            OnsdagList = await FileHandler.LoadOnsdagJobListJsonAsync();
            TorsdagList = await FileHandler.LoadTorsdagJobListJsonAsync();
        }


    }
}
