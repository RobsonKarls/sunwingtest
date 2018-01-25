using System;

namespace ContactManager.Domain.Model
{
    public class Supplier : Person
    {
        public string Telephone { get; set; }
        
        public Supplier(){}

        public Supplier(string firstName, string lastName, string telephone)
        {
            Name = new Name(
                (!string.IsNullOrWhiteSpace(firstName))
                    ? firstName
                    : throw new ArgumentNullException("firstName cant be null"),
                (!string.IsNullOrWhiteSpace(lastName))
                    ? lastName
                    : throw new ArgumentNullException("lasttName cant be null")
            );
            Telephone  = !string.IsNullOrWhiteSpace(telephone) ? telephone : throw new ArgumentNullException("telephone cant be null");
        }
    }
}