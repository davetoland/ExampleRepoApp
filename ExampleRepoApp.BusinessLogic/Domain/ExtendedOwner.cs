using System.Collections.Generic;

namespace ExampleRepoApp.BusinessLogic.Domain
{
    // Avoid extended objects (which contain navigation properties) containing
    // further extended objects, potentially causing 'cartesian explosion' until
    // EF can support split queries for ProjectTo/Select:
    // https://github.com/dotnet/efcore/issues/21234
    // https://docs.microsoft.com/en-us/ef/core/querying/single-split-queries
    
    // Instead, if an extended version of a navigation property is required, 
    // separately call that from its Service using the Id of the regular object 
    // i.e. VehicleService.GetExtendedVehicle(Vehicles.ElementAt(0).Id)
    
    public class ExtendedOwner : Owner
    {
        public OwnerAddress Address { get; set; }
        public IEnumerable<Vehicle> Vehicles { get; set; }
    }
}