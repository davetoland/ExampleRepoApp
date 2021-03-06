using System;

namespace ExampleRepoApp.BusinessLogic.Domain
{
    public class Owner : DomainObject
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}