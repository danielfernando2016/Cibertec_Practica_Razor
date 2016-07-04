using System;
using System.Collections.Generic;
using System.Linq;
using WebDeveloper.Model;

namespace WebDeveloper.DataAccess
{
    public class PhoneNumberTypeData : BaseDataAccess<PhoneNumberType>
    {
       
        public PhoneNumberType GetPhoneNumberTypeById(int id)
        {
            using (var dbContext = new AdventureDbContext())
            {
                return dbContext.PhoneNumberType.FirstOrDefault(x => x.PhoneNumberTypeID == id);
            }
        }
            

    }
}
