using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Beales.Models
{
    public class Movie // movie class containing all the movie info that will be gathered
    {
        [Key]
        [Required]
        public int MovieID { get; set; }
        [Required]

        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; }
        public CategoryName? CategoryName { get; set; }

        [Required(ErrorMessage = "Title must be entered.")]
        public string Title { get; set; }

        [Required]
        [Range(1888, int.MaxValue, ErrorMessage = "Year must be at least 1888.")]
        public int Year { get; set; }

        public string? Director { get; set; }

        public string? Rating { get; set; }

        public bool? Edited { get; set; }

        public string? LentTo { get; set; }

        [Required(ErrorMessage = "Must select whether movie copied to Plex.")]
        public bool? CopiedToPlex { get; set; }

        [StringLength(25)]
        public string? Notes { get; set; }

    }
}
