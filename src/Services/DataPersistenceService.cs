using Flora.Models;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Flora.Services
{
    public class DataPersistenceService
    {
        private readonly string _notesFilePath = "notes.json";

        public void SaveNote(Note note)
        {
            var notes = LoadNotes();
            notes.Add(note);
            File.WriteAllText(_notesFilePath, JsonSerializer.Serialize(notes));
        }

        public List<Note> LoadNotes()
        {
            if (File.Exists(_notesFilePath))
            {
                var json = File.ReadAllText(_notesFilePath);
                return JsonSerializer.Deserialize<List<Note>>(json);
            }
            return new List<Note>();
        }

        public void DeleteNote(Note note)
        {
            var notes = LoadNotes();
            notes.Remove(note);
            File.WriteAllText(_notesFilePath, JsonSerializer.Serialize(notes));
        }
    }
}
