using System.ComponentModel.DataAnnotations;

namespace NoteApp.Models
{
    public class Note
    {
        [Key]
        public int Id { get; set; }
        public string NoteTitle { get; set; }
        public string NoteText { get; set; }
        public string Day { get; set; }
    }
}
