using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using ContactManager.API.ViewModel;
using Dapper;

namespace ContactManager.API.Infrastructure.Queries
{
    public class ContactQueries : IContactQueries
    {
        private readonly string _connectionString;

        public ContactQueries(string constr)
        {
            _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));
        }
        
        public async Task<IEnumerable<ContactViewModel>> GetContactsAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var result = await connection.QueryAsync<ContactViewModel>(
                    @"SELECT 
                         N.First FirstName
                        ,N.Last LastName
                        ,CASE WHEN p.Discriminator = 'Costumer' THEN 1 ELSE 0 END ContactType
                        ,P.BirthDate BirthDate
                        ,P.Email Email
                        ,P.Telephone Telephone
                        ,P.Id Id
                    FROM dbo.Person P
                    INNER JOIN dbo.Name N ON P.Id = N.PersonId"
                );
                return result.AsList();
            }
        }
    }
}