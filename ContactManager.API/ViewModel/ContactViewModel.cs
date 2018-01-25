using System;
using ContactManager.API.Infrastructure.Factory;

namespace ContactManager.API.ViewModel
{
    public class ContactViewModel
    {
        public Int64 Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ContactType ContactType { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}