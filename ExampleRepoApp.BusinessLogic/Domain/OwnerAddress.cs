using System.Collections.Generic;

namespace ExampleRepoApp.BusinessLogic.Domain
{
    public class OwnerAddress : DomainObject
    {
        public int HouseNumber { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string PostCode { get; set; }
    }
}