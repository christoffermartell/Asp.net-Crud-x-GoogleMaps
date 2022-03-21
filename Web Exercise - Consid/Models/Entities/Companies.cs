using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_Exercise___Consid.Models.Entities
{
    [Table("Companies")]
    public class Companies
    {
        [Column(TypeName = "uniqueidentifier")]
        public Guid Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required(ErrorMessage = "Name is required")]
        [RegularExpression(@"^[a-zA-Z0-9\s]+$")]
        public string Name { get; set; }

        [RegularExpression(@"^-?[0-9][0-9,\.\s*]+$")]
        [Required]
        public int OrganizationNumber { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        [StringLength(500, MinimumLength = 0)]
        public string Notes { get; set; }

        public virtual ICollection<Stores> Stores { get; set; }

    }
}
