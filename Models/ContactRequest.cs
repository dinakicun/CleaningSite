using System.ComponentModel.DataAnnotations;

namespace CleaningSite.Models
{
    public class ContactRequest
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Укажите ваше имя")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Укажите номер телефона")]
        public string Phone { get; set; } = string.Empty;
        public string? Comment { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
