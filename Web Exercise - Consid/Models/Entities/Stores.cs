using System.ComponentModel.DataAnnotations.Schema;

namespace Web_Exercise___Consid.Models.Entities
{
    [Table("Stores")]
    public class Stores
    {
        [Column(TypeName = "uniqueidentifier")]
        public Guid Id { get; set; }
        [Column(TypeName = "uniqueidentifier")]
        public Guid CompanyId { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }
        [Column(TypeName = "nvarchar(512)")]
        public string Adress { get; set; }
        [Column(TypeName = "nvarchar(512)")]
        public string City { get; set; }
        [Column(TypeName = "nvarchar(16)")]
        public string Zip { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Country { get; set; }
        [Column(TypeName = "nvarchar(15)")]
        public string Longitude { get; set; }
        [Column(TypeName = "nvarchar(15)")]
        public string Latitude { get; set; }

        public virtual Companies Companies { get; set; }


    }
}
