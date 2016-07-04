using System.Linq;
using WebDeveloper.Model;


namespace WebDeveloper.DataAccess
{
    public class AddressTypeData : BaseDataAccess<AddressType>
    {
        public AddressType GetAddressTypeById(int id)
        {
            using (var dbContext = new AdventureDbContext())
            {
                return dbContext.AddressType.FirstOrDefault(x => x.AddressTypeID == id);
            }
        }
    }
}
