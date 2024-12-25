using Flora.Models;
using Flora.Helpers;
using Flora.Services;
using System.Collections.ObjectModel;
using System.Linq;

namespace Flora.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Note> Notes { get; set; } = new ObservableCollection<Note>();
        public ObservableCollection<Tag> Tags { get; set; } = new ObservableCollection<Tag>();
        private Note _selectedNote;
        private string _searchText;

        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                OnPropertyChanged(nameof(SearchText));
                SearchNotes();
            }
        }

        public Note SelectedNote
        {
            get => _selectedNote;
            set
            {
                _selectedNote = value;
                OnPropertyChanged(nameof(SelectedNote));
            }
        }

        public RelayCommand SaveNoteCommand { get; set; }
        public RelayCommand DeleteNoteCommand { get; set; }
        public RelayCommand UndoCommand { get; set; }
        public RelayCommand RedoCommand { get; set; }

        private readonly DataPersistenceService _dataPersistenceService;
        private readonly UndoRedoService _undoRedoService;

        public MainViewModel()
        {
            _dataPersistenceService = new DataPersistenceService();
            _undoRedoService = new UndoRedoService();

            SaveNoteCommand = new RelayCommand(SaveNote, CanSaveNote);
            DeleteNoteCommand = new RelayCommand(DeleteNote, CanDeleteNote);
            UndoCommand = new RelayCommand(Undo, CanUndo);
            RedoCommand = new RelayCommand(Redo, CanRedo);

            LoadNotes();
        }

        private void LoadNotes()
        {
            var notes = _dataPersistenceService.LoadNotes();
            foreach (var note in notes)
            {
                Notes.Add(note);
            }
        }

        private void SaveNote(object parameter)
        {
            if (SelectedNote != null)
            {
                _dataPersistenceService.SaveNote(SelectedNote);
                _undoRedoService.AddAction(new UndoRedoAction(() => _dataPersistenceService.DeleteNote(SelectedNote), () => _dataPersistenceService.SaveNote(SelectedNote)));
            }
        }

        private bool CanSaveNote(object parameter) => SelectedNote != null;

        private void DeleteNote(object parameter)
        {
            if (SelectedNote != null)
            {
                _dataPersistenceService.DeleteNote(SelectedNote);
                Notes.Remove(SelectedNote);
            }
        }

        private bool CanDeleteNote(object parameter) => SelectedNote != null;

        private void Undo(object parameter) => _undoRedoService.Undo();

        private bool CanUndo(object parameter) => _undoRedoService.CanUndo();

        private void Redo(object parameter) => _undoRedoService.Redo();

        private bool CanRedo(object parameter) => _undoRedoService.CanRedo();

        private void SearchNotes()
        {
            var filteredNotes = Notes.Where(note => note.Title.Contains(SearchText) || note.Content.Contains(SearchText)).ToList();
            Notes.Clear();
            foreach (var note in filteredNotes)
            {
                Notes.Add(note);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
