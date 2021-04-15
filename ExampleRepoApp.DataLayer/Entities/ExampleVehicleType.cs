using System.Collections.Generic;

namespace ExampleRepoApp.DataLayer.Entities
{
    public class ExampleVehicleType : DbEntity
    {
        public string Name { get; set; }
        
        public virtual IEnumerable<ExampleVehicle> Vehicles { get; }
    }
}