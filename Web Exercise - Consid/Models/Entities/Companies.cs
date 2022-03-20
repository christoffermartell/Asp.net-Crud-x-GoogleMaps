using System.ComponentModel.DataAnnotations.Schema;

namespace Web_Exercise___Consid.Models.Entities
{
    [Table("Companies")]
    public class Companies
    {
        [Column(TypeName = "uniqueidentifier")]
        public Guid Id { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string Name { get; set; }

        public int OrganizationNumber { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string Notes { get; set; }

        public virtual ICollection<Stores> Stores { get; set; }

    }
}
