using System.ComponentModel.DataAnnotations;

namespace NoteApp.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Workout { get; set; }
        public int Participant { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;

    }
}
