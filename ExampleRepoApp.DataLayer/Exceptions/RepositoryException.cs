using System;

namespace ExampleRepoApp.DataLayer.Exceptions
{
    public class RepositoryException : Exception
    {
        public RepositoryException(string message) : base (message) { }
    }
}