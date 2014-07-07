using System.Data.SqlClient;
using Insight.Database;
using System.Configuration;

namespace PhenoCare.Repository
{
    public class ContactRepository:IContactRepository
    {
        public void SaveContact(Models.Contact contact)
        {
                var connection =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["PhenoCareDb"].ToString());

                connection.Execute("sp_AddContact", new { name = contact.Name, email = contact.Email, contact.Message });
        }
    }
}