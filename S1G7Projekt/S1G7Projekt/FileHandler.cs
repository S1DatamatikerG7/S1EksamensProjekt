using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S1G7Projekt
{
    class FileHandler
    {
        private static string LoginFileName = "Login.json";
        private static string BetalingsListeFileName = "BetalingsListe.json";
        private static string TilmeldSpisningFileName = "TilmeldSpisning.json";
        private static string NaesteUgeFileName = "NaesteUge.json";

        public static async void SaveNoteAsJsonAsync(ObservableCollection<Login> notes)
        {
            string NoteAsJsonString = JsonConvert.SerializeObject(notes);
            SerializeNotesFileAsync(NoteAsJsonString, jsonFileName);
        }

        public static async Task<ObservableCollection<NoteModel>> LoadNoteFromJsonAsync()
        {
            string notesJsonString = await DeserializeNotesFileAsync(jsonFileName);
            return (ObservableCollection<NoteModel>)JsonConvert.DeserializeObject(notesJsonString, typeof(ObservableCollection<NoteModel>));
        }

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
    }
}
