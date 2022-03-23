using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_Exercise___Consid.Models.Entities
{
    [Table("Stores")]
    public class Store
    {
        [Column(TypeName = "uniqueidentifier")]
        public Guid Id { get; set; }
        [Column(TypeName = "uniqueidentifier")]

        [Required]
        public Guid CompanyId { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [Required(ErrorMessage = "Name is required")]
        [RegularExpression(@"^[a-zA-Z0-9\s]+$")]
        public string Name { get; set; }
        [Column(TypeName = "nvarchar(512)")]

        [Required(ErrorMessage = "Adress is required")]
        [RegularExpression(@"^[a-zA-Z\s0-9]+$")]
        public string Adress { get; set; }
        [Column(TypeName = "nvarchar(512)")]

        [Required(ErrorMessage = "City is required")]
        [RegularExpression(@"^[a-zA-Z\s]+$")]
        public string City { get; set; }
        [Column(TypeName = "nvarchar(16)")]

        [RegularExpression(@"^-?[0-9][0-9,\.\s*]+$")]
        [Required(ErrorMessage = "Zipcode is required")]
        public string Zip { get; set; }
        [Column(TypeName = "nvarchar(50)")]

        [Required(ErrorMessage = "Country is required")]
        [RegularExpression(@"^[a-zA-Z\s]+$")]
        public string Country { get; set; }

        [Column(TypeName = "nvarchar(15)")]
        [RegularExpression(@"^-?[\.0-9][0-9,\.]+$")]
        public string? Longitude { get; set; }

        [Column(TypeName = "nvarchar(15)")]
        [RegularExpression(@"^-?[\.0-9][0-9,\.]+$")]
        public string? Latitude { get; set; }

        public virtual Company? Companies { get; set; }


    }
}
