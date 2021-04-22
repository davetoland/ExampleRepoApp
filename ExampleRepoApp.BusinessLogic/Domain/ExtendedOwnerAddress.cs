using System.Collections.Generic;

namespace ExampleRepoApp.BusinessLogic.Domain
{
    public class ExtendedOwnerAddress : OwnerAddress
    {
        public IEnumerable<Owner> Owners { get; set; }
    }
}