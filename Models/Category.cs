using System.ComponentModel.DataAnnotations;

namespace NoteApp.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CategoryType { get; set; }
        public int DisplayOrder { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;

    }
}
