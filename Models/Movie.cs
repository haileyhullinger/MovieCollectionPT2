using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HaileyHullingerAssignment9.Models
{
    public class Movie
    {
        [Key]
        public int MovieID { get; set; }

        [Required]
        public string Category { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public string Rating { get; set; }
        [Required]
        public bool Edited { get; set; }
        [Required]
        public string Year { get; set; }

        public string LentTo { get; set; }
        [MaxLength(25)]
        public string Notes { get; set; }
    }
}
