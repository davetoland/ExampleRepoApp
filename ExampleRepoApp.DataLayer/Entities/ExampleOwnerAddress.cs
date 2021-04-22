using System.Collections.Generic;

namespace ExampleRepoApp.DataLayer.Entities
{
    public class ExampleOwnerAddress : DbEntity
    {
        public int HouseNumber { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string PostCode { get; set; }
        
        public virtual IEnumerable<ExampleOwner> Owners { get; set; }
    }
}