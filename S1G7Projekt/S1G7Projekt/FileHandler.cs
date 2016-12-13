using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Newtonsoft.Json;

namespace S1G7Projekt
{
    class FileHandler
    {
        private static string HusNrListeFile = "HusNrListe.json";
        private static string TilmeldspisningListeFile = "TilmeldSpisningListe.json";
        private static string BrugerListeFile = "BrugerListe.json";
        private static string MandagJobListeFile = "MandagJobListe.json";
        private static string TirsdagJobListeFile = "TirsdagJobListe.json";
        private static string OnsdagJobListeFile = "OnsdagJobListe.json";
        private static string TorsdagJobListeFile = "TorsdagJobListe.json";
        private static string RetListeFile = "RetListe.json";


        #region HusListe

        public static async void SaveHusNrListeJsonAsync(List<String> HusNr)
        {
            string HusNrAsJsonString = JsonConvert.SerializeObject(HusNr);
            SerializeNotesFileAsync(HusNrAsJsonString, HusNrListeFile);
        }

        public static async Task<List<String>> LoadHusNrListeJsonAsync()
        {
            string husNrsJsonString = await DeserializeNotesFileAsync(HusNrListeFile);
            return (List<String>)JsonConvert.DeserializeObject(husNrsJsonString, typeof(List<String>));
        }

        #endregion
        #region Tilmeldspisning

        public static async void SaveTilmeldingJsonAsync(Dictionary<string, List<string>> Tilmeldspisning)
        {
            string TilmeldAsJsonString = JsonConvert.SerializeObject(Tilmeldspisning);
            SerializeNotesFileAsync(TilmeldAsJsonString, TilmeldspisningListeFile);
        }

        public static async Task<List<String>> LoadTilmeldingJsonAsync()
        {
            string tilmeldingJsonString = await DeserializeNotesFileAsync(TilmeldspisningListeFile);
            return (Dictionary<string, List<string>>)JsonConvert.DeserializeObject(tilmeldingJsonString, typeof(Dictionary<string, List<string>>));
        }

        #endregion
        #region Bruger

        public static async void SaveBrugerJsonAsync(ObservableCollection<Bruger> Bruger)
        {
            string BrugerAsJsonString = JsonConvert.SerializeObject(Bruger);
            SerializeNotesFileAsync(BrugerAsJsonString, BrugerListeFile);
        }

        public static async Task<List<String>> LoadBrugerJsonAsync()
        {
            string BrugersJsonString = await DeserializeNotesFileAsync(BrugerListeFile);
            return (ObservableCollection<Bruger>)JsonConvert.DeserializeObject(BrugersJsonString, typeof(ObservableCollection<Bruger>));
        }

        #endregion
        #region MandagJobList

        public static async void SaveMandagJobListJsonAsync(List<string> MandagList)
        {
            string MandagListAsJsonString = JsonConvert.SerializeObject(MandagList);
            SerializeNotesFileAsync(MandagListAsJsonString, MandagJobListeFile);
        }

        public static async Task<List<string>> LoadMandagJobListJsonAsync()
        {
            string MandagJobListJsonString = await DeserializeNotesFileAsync(MandagJobListeFile);
            return (List<string>)JsonConvert.DeserializeObject(MandagJobListJsonString, typeof(List<string>));
        }

        #endregion
        #region TirsdagJobList

        public static async void SaveTirsdagJobListJsonAsync(List<string> TirsdagList)
        {
            string TirsdagListAsJsonString = JsonConvert.SerializeObject(TirsdagList);
            SerializeNotesFileAsync(TirsdagListAsJsonString, TirsdagJobListeFile);
        }

        public static async Task<List<string>> LoadTirsdagJobListJsonAsync()
        {
            string TirsdagJsonString = await DeserializeNotesFileAsync(TirsdagJobListeFile);
            return (List<string>)JsonConvert.DeserializeObject(TirsdagJsonString, typeof(List<string>));
        }

        #endregion
        #region OnsdagJobList

        public static async void SaveOnsdagJobListJsonAsync(List<string> OnsdagList)
        {
            string OnsdagListAsJsonString = JsonConvert.SerializeObject(OnsdagList);
            SerializeNotesFileAsync(OnsdagListAsJsonString, OnsdagJobListeFile);
        }

        public static async Task<List<string>> LoadOnsdagJobListJsonAsync()
        {
            string OnsdagJsonString = await DeserializeNotesFileAsync(OnsdagJobListeFile);
            return (List<string>)JsonConvert.DeserializeObject(OnsdagJsonString, typeof(List<string>));
        }

        #endregion
        #region TorsdagJobList

        public static async void SaveTorsdagJobListJsonAsync(List<string> TorsdagList)
        {
            string TorsdagListAsJsonString = JsonConvert.SerializeObject(TorsdagList);
            SerializeNotesFileAsync(TorsdagListAsJsonString, TorsdagJobListeFile);
        }

        public static async Task<List<string>> LoadTorsdagJobListJsonAsync()
        {
            string TorsdagJsonString = await DeserializeNotesFileAsync(TorsdagJobListeFile);
            return (List<string>)JsonConvert.DeserializeObject(TorsdagJsonString, typeof(List<string>));
        }

        #endregion
        #region RetJobList

        public static async void SaveRetListJsonAsync(List<string> RetList)
        {
            string RetListAsJsonString = JsonConvert.SerializeObject(RetList);
            SerializeNotesFileAsync(RetListAsJsonString, RetListeFile);
        }

        public static async Task<List<string>> LoadRetListJsonAsync()
        {
            string RetJsonString = await DeserializeNotesFileAsync(RetListeFile);
            return (List<string>)JsonConvert.DeserializeObject(RetJsonString, typeof(List<string>));
        }

        #endregion

        #region Serialization

        public static async void SerializeNotesFileAsync(string noteString, string fileName)
        {
            StorageFile localFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(localFile, noteString);
        }

        public static async Task<string> DeserializeNotesFileAsync(string fileName)
        {
            StorageFile localFile = await ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
            return await FileIO.ReadTextAsync(localFile);
        }

        #endregion

        


        //public static async void SaveNoteAsJsonAsync(ObservableCollection<Login> notes)
        //{
        //    string NoteAsJsonString = JsonConvert.SerializeObject(notes);
        //    SerializeNotesFileAsync(NoteAsJsonString, jsonFileName);
        //}

        //public static async Task<ObservableCollection<NoteModel>> LoadNoteFromJsonAsync()
        //{
        //    string notesJsonString = await DeserializeNotesFileAsync(jsonFileName);
        //    return (ObservableCollection<NoteModel>)JsonConvert.DeserializeObject(notesJsonString, typeof(ObservableCollection<NoteModel>));
        //}

        //public static async void SerializeNotesFileAsync(string noteString, string fileName)
        //{
        //    StorageFile localFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
        //    await FileIO.WriteTextAsync(localFile, noteString);
        //}

        //public static async Task<string> DeserializeNotesFileAsync(string fileName)
        //{
        //    StorageFile localFile = await ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
        //    return await FileIO.ReadTextAsync(localFile);
        //}
    }
}
