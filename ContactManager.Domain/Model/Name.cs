using System.Collections.Generic;
using ContactManager.Domain.SeedOfWork;

namespace ContactManager.Domain.Model
{
    public class Name : ValueObject
    {
        public string First { get; private set; }
        public string  Last { get; private set; }

        public Name(string firstName, string lastName)
        {
            First = firstName;
            Last = lastName;
        }
        
        public Name(){}

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return First;
            yield return Last;
        }
    }
}