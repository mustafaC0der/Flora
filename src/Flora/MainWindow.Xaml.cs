using System.Collections.ObjectModel;
using System.Windows;

namespace Flora
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Note> Notes { get; set; } = new ObservableCollection<Note>();

        public MainWindow()
        {
            InitializeComponent();
            NotesList.ItemsSource = Notes;
        }

        private void SaveNote_Click(object sender, RoutedEventArgs e)
        {
            var selectedNote = (Note)NotesList.SelectedItem;
            if (selectedNote != null)
            {
                selectedNote.Title = NoteTitle.Text;
                selectedNote.Content = NoteContent.Text;
            }
            else
            {
                Notes.Add(new Note
                {
                    Title = NoteTitle.Text,
                    Content = NoteContent.Text
                });
            }
            NotesList.Items.Refresh();
        }

        private void NotesList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (NotesList.SelectedItem is Note selectedNote)
            {
                NoteTitle.Text = selectedNote.Title;
                NoteContent.Text = selectedNote.Content;
            }
            else
            {
                NoteTitle.Text = string.Empty;
                NoteContent.Text = string.Empty;
            }
        }
    }
}
