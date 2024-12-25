namespace Flora.Models
{
    public class Note
    {
        public string Title { get; set; }
        public string Content { get; set; }  // Still using plain text, can be enhanced for rich text
        public List<string> Tags { get; set; } = new List<string>();
    }
}
