using eTicket.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace eTicket.Models
{
    public class Cinema : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Cinema Logo")]
        [Required(ErrorMessage = "Cinema Logo is required")]
        public string Logo { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name should be between 3 to 50 chars")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }


        //Relationships

        public List<Movie> Movies { get; set; }
    }
}
