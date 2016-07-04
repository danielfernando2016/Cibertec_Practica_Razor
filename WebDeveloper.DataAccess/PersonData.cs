
using System.Linq;
using WebDeveloper.Model;
namespace WebDeveloper.DataAccess
{
    public class PersonData : BaseDataAccess<Person>
    {

        public Person GetPersonById(int id)
        {
            using (var dbContext = new AdventureDbContext())
            {
                return dbContext.Person.FirstOrDefault(x => x.BusinessEntityID == id);
            }
        }
    }
}
