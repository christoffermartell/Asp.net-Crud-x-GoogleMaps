using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Web_Exercise___Consid.Models.Entities;

namespace Web_Exercise___Consid.Models.Dtos
{
    public class CompanyDto
    {
  
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int OrganizationNumber { get; set; }
        public string? Notes { get; set; }
        public virtual ICollection<Store>? Stores { get; set; }


    }
}
