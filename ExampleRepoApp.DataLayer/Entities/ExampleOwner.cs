using System;
using System.Collections.Generic;

namespace ExampleRepoApp.DataLayer.Entities
{
    public class ExampleOwner : DbEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public DateTime DateOfBirth { get; set; }
        public long AddressId { get; set; }

        public virtual ExampleOwnerAddress Address { get; set; }
        public virtual IEnumerable<ExampleVehicle> Vehicles { get; set; }
    }
}