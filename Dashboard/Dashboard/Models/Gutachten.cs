using System;
using System.ComponentModel.DataAnnotations;

namespace Dashboard.Models
{
    public class Gutachten
    {
        public int Id { get; set; }

        public DateTime Erstelldatum { get; set; }

        [StringLength(255)]
        public string Kurztext { get; set; }

        public decimal Kosten { get; set; }

        public Gutachter Gutachter { get; set; }
    }
}