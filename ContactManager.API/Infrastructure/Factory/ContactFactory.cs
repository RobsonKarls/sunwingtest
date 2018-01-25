using System;
using ContactManager.API.ViewModel;
using ContactManager.Domain.Model;

namespace ContactManager.API.Infrastructure.Factory
{
    public enum ContactType
    {
        Supplier,
        Costumer
    }
    public static class ContactFactory 
    {
        public static Person CreatePerson(ContactViewModel model)
        {
            switch (model.ContactType)
            {
                case ContactType.Costumer:
                    return new Costumer(model.FirstName,model.LastName,model.BirthDate,model.Email);
                    break;
                case ContactType.Supplier:
                    return  new Supplier(model.FirstName,model.LastName,model.Telephone);
                    break;
                default:
                    return null;
            }
        }
    }
}