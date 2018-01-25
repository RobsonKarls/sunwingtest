using System;

namespace ContactManager.Domain.Model
{
    public class Costumer : Person
    {
        public string Email { get; set; }

        public DateTime? BirthDate { get; set; }
        
        public Costumer(){}

        public Costumer(string firstName, string lastName, DateTime? birthDate, string email)
        {
            Name = new Name(
                (!string.IsNullOrWhiteSpace(firstName))
                    ? firstName
                    : throw new ArgumentNullException("firstName cant be null"),
                (!string.IsNullOrWhiteSpace(lastName))
                    ? lastName
                    : throw new ArgumentNullException("lasttName cant be null")
                );
            
            BirthDate =  birthDate;
            Email = !string.IsNullOrWhiteSpace(email) ? email : throw new ArgumentNullException("email cant be null");
        }
    }
}