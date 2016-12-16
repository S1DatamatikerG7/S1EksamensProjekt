using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls.Primitives;

namespace S1G7Projekt
{
    class VMOpretBruger : INotifyPropertyChanged
    {
        private RelayCommand _relayCommandOpretBruger;
        private RelayCommand _relayCommandFjernBruger;
        private ObservableCollection<Bruger> _brugerListe;
        public string BrugerNavn { get; set; }
        public int ID { get; set; }
        public int SelectedID { get; set; }

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
            BrugerListe = new ObservableCollection<Bruger>();
            
            LoadBrugerListe();
            BrugerNavn = null;

            ID = BrugerListe.Count;
        }

        public async void LoadBrugerListe()
        {
            ObservableCollection<Bruger> tempBrugers = await FileHandler.LoadBrugerJsonAsync();
            if (tempBrugers == null)
            {
                BrugerListe = new ObservableCollection<Bruger>();
            }
            else
            {
                foreach (Bruger bruger in tempBrugers)
                {
                    BrugerListe.Add(bruger);
                }
            }
        }

        public void OpretBruger()
        {
            if (string.IsNullOrWhiteSpace(BrugerNavn))
            {
                throw new ArgumentException("Brugernavn mangler");
            }   
            _brugerListe.Add(new Bruger(ID, BrugerNavn)); OnPropertyChanged();
            FileHandler.SaveBrugerJsonAsync(_brugerListe);
            ID++;
        }       

        public void FjernBruger()
        {
            if (SelectedID != -1)
            {
                BrugerListe.RemoveAt(SelectedID); OnPropertyChanged();
                FileHandler.SaveBrugerJsonAsync(_brugerListe);
            }
        }   
    }
}
