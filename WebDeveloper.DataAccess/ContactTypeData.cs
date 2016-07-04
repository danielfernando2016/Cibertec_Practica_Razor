
using System.Linq;
using WebDeveloper.Model;

namespace WebDeveloper.DataAccess
{
    public class ContactTypeData: BaseDataAccess<ContactType>
    {
        public ContactType GetContactTypeById(int id)
        {
            using (var dbContext = new AdventureDbContext())
            {
                return dbContext.ContactType.FirstOrDefault(x => x.ContactTypeID == id);
            }
        }
        
    }
}
