using System;
using ContactManager.Domain.SeedOfWork;

namespace ContactManager.Domain.Model
{
    public abstract class Person
    {
        public Name Name { get; set; }

        public Int64 Id { get; set; }
        
        public bool IsTransient()
        {
            return Id == default(Int64);
        }
        
        public Person() {}
    }
}