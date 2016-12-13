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
        private static string TilmeldspisningListe = "BetalingsListe.json";
        private static string TilmeldSpisningFileName = "TilmeldSpisning.json";
        private static string NaesteUgeFileName = "NaesteUge.json";

        #region HusListe

        public static async void SaveHusNrListeJsonAsync(List<String> HusNr)
        {
            string HusNrAsJsonString = JsonConvert.SerializeObject(HusNr);
            SerializeNotesFileAsync(HusNrAsJsonString, HusNrListe);
        }

        public static async Task<List<String>> LoadHusNrListeJsonAsync()
        {
            string husNrsJsonString = await DeserializeNotesFileAsync(HusNrListe);
            return (List<String>)JsonConvert.DeserializeObject(husNrsJsonString, typeof(List<String>));
        }

        #endregion
        #region Tilmeldspisning

        public static async void SaveTilmeldingJsonAsync(Dictionary<string, List<string>> Tilmeldspisning)
        {
            string TilmeldAsJsonString = JsonConvert.SerializeObject(Tilmeldspisning);
            SerializeNotesFileAsync(TilmeldAsJsonString, TilmeldspisningListe);
        }

        public static async Task<List<String>> LoadTilmeldingJsonAsync()
        {
            string tilmeldingJsonString = await DeserializeNotesFileAsync(TilmeldspisningListe);
            return (Dictionary<string, List<string>>)JsonConvert.DeserializeObject(tilmeldingJsonString, typeof(Dictionary<string, List<string>>));
        }

        #endregion
        #region NOT DONE!

        public static async void SaveNoteAsJsonAsync(Dictionary<string, List<string>> Tilmeldspisning)
        {
            string TilmeldAsJsonString = JsonConvert.SerializeObject(Tilmeldspisning);
            SerializeNotesFileAsync(TilmeldAsJsonString, TilmeldspisningListe);
        }

        public static async Task<List<String>> LoadNoteFromJsonAsync()
        {
            string tilmeldingJsonString = await DeserializeNotesFileAsync(TilmeldspisningListe);
            return (Dictionary<string, List<string>>)JsonConvert.DeserializeObject(tilmeldingJsonString, typeof(Dictionary<string, List<string>>));
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
