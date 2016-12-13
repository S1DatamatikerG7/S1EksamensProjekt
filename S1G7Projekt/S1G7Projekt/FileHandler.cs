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
        private static string HusNrListe = "HusNrListe.json";
        private static string BetalingsListeFileName = "BetalingsListe.json";
        private static string TilmeldSpisningFileName = "TilmeldSpisning.json";
        private static string NaesteUgeFileName = "NaesteUge.json";

        #region HusListe

        public static async void SaveHusNrListe(List<String> HusNr)
        {
            string NoteAsJsonString = JsonConvert.SerializeObject(HusNr);
            SerializeNotesFileAsync(NoteAsJsonString, HusNrListe);
        }

        public static async Task<List<String>> LoadHusNrListe()
        {
            string notesJsonString = await DeserializeNotesFileAsync(HusNrListe);
            return (List<String>)JsonConvert.DeserializeObject(notesJsonString, typeof(List<String>));
        }

        #endregion
        #region Dag

        public static async void SaveNoteAsJsonAsync(List<String> HusNr)
        {
            string NoteAsJsonString = JsonConvert.SerializeObject(HusNr);
            SerializeNotesFileAsync(NoteAsJsonString, HusNrListe);
        }

        public static async Task<List<String>> LoadNoteFromJsonAsync()
        {
            string notesJsonString = await DeserializeNotesFileAsync(HusNrListe);
            return (List<String>)JsonConvert.DeserializeObject(notesJsonString, typeof(List<String>));
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
