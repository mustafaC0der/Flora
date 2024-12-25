using System.Linq;
using Flora.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Flora.Tests.UnitTests
{
    [TestClass]
    public class ViewModelTests
    {
        [TestMethod]
        public void SaveNote_AddsNoteToCollection()
        {
            var mainViewModel = new MainViewModel();
            mainViewModel.SelectedNote = new Note { Title = "Test", Content = "Content" };

            mainViewModel.SaveNoteCommand.Execute(null);

            Assert.AreEqual(1, mainViewModel.Notes.Count);
            Assert.AreEqual("Test", mainViewModel.Notes.First().Title);
        }
    }
}
