using System.ComponentModel.DataAnnotations;

namespace CasaCue.Models
{
    public class Guest
    {
        [Key] // Markiert die Id als Primärschlüssel
        public Guid Id { get; set; } // UUID wird automatisch generiert

        [Required]
        public string Name { get; set; } // Name des Gastes

        [Required]
        public int GroupSize { get; set; } // Gruppengröße

        [Required]
        public int QueuePosition { get; set; } // Position in der Warteliste
    }
}