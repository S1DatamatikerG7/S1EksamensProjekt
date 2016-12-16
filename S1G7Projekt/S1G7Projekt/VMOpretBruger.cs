﻿using System;
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
        private RelayCommand _relayCommandOpretBruger;
        private RelayCommand _relayCommandFjernBruger;
        private ObservableCollection<Bruger> _brugerListe;
        public string BrugerNavn { get; set; }
        public int ID { get; set; }

        public ObservableCollection<Bruger> BrugerListe
        {
            get { return _brugerListe; }
            set { _brugerListe = value; }
        }

        public RelayCommand RelayCommandOpretBruger
        {
            get { return _relayCommandOpretBruger; }
            set { _relayCommandOpretBruger = value; }
        }

        public RelayCommand RelayCommandFjernBruger
        {
            get { return _relayCommandFjernBruger; }
            set { _relayCommandFjernBruger = value; }
        }

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

            
            LoadBrugerListe();
            BrugerNavn = null;

        }

        public async void LoadBrugerListe()
        {
            _brugerListe = await FileHandler.LoadBrugerJsonAsync();
        }

        public void OpretBruger()
        {
            if (string.IsNullOrWhiteSpace(BrugerNavn))
            {
                throw new ArgumentException("Brugernavn mangler");
            }   
            BrugerListe.Add(new Bruger(ID, BrugerNavn)); OnPropertyChanged();
            FileHandler.SaveBrugerJsonAsync(_brugerListe);
            ID++;
        }       

        public void FjernBruger()
        {
            BrugerListe.RemoveAt(ID); OnPropertyChanged();
            FileHandler.SaveBrugerJsonAsync(_brugerListe);
        }   
    }
}
