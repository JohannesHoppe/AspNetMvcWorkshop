using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dashboard.Models
{
    public class Gutachter
    {
        public Gutachter()
        {
            Gutachten = new HashSet<Gutachten>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Vorname { get; set; }

        [Required]
        [StringLength(255)]
        public string Nachname { get; set; }

        [EmailAddress( ErrorMessage = "Format der E-Mail Adresse nicht korrekt.")]
        public string EMail { get; set; }

        public virtual ICollection<Gutachten> Gutachten { get; private set; } 
    }
}