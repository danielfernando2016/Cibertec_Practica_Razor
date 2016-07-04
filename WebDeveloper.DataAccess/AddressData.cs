
using System.Linq;
using WebDeveloper.Model;

namespace WebDeveloper.DataAccess
{
    public class AddressData : BaseDataAccess<Address>
    {
        public Address GetAddressById(int id)
        {
            using (var dbContext = new AdventureDbContext())
            {
                return dbContext.Address.FirstOrDefault(x => x.AddressID == id);
            }
        }
    }
}
