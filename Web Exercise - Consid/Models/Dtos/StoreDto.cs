using Web_Exercise___Consid.Models.Entities;

namespace Web_Exercise___Consid.Models.Dtos
{
    public class StoreDto
    {

       
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public string? Longitude { get; set; }
        public string? Latitude { get; set; }
        public virtual Company? Companies { get; set; }
    }
}
