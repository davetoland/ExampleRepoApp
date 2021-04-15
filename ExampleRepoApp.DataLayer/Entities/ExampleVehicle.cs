namespace ExampleRepoApp.DataLayer.Entities
{
    public class ExampleVehicle : DbEntity
    {
        public long? OwnerId { get; set; }
        public long VehicleTypeId { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        
        public virtual ExampleOwner Owner { get; set; }
        public virtual ExampleVehicleType VehicleType { get; set; }
    }
}