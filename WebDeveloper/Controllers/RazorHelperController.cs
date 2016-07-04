
using System.Linq;

using System.Web.Mvc;
using WebDeveloper.DataAccess;
using WebDeveloper.Model;

namespace WebDeveloper.Controllers
{
    public class RazorHelperController : Controller
    {
        // GET: RazorHelper
        private ContactTypeData _contactTypeData = new ContactTypeData();
        public ActionResult ContactTypeDetails()
        {
            
            return View(_contactTypeData.GetList());
        }

        //Edit
        public ActionResult Edit(int id)
        {


            var ContactType = _contactTypeData.GetContactTypeById(id);
            if (ContactType == null)
                RedirectToAction("ContactTypeDetails");
            return View(ContactType);

        }

        //Edit Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ContactType ContactType)
        {
            //Primero
            if (ModelState.IsValid)
            {
                _contactTypeData.Update(ContactType);
                return RedirectToAction("ContactTypeDetails");
            }
            return View();
        }

        private PersonData _personData = new PersonData();
        public ActionResult Person()
        {

            var iList = (from p in _personData.GetList()
                         orderby p.BusinessEntityID descending
                         select p).Take(100);
            return View(iList);

        }


        // GET: RazorHelper
        private AddressData _addressData = new AddressData();
        public ActionResult AddressDetails()
        {
            //var iList = (from p in _addressData.GetList()
            //                              orderby p.AddressID descending
            //                              select p.City).Distinct();



            var iList = (from p in _addressData.GetList()
                          orderby p.AddressID descending
                          select p).Take(100);


            //_addressDetail =
            //       (from o in queryA
            //        orderby o.AddressID
            //        select o.City).Distinct();


            return View(iList);
        }

        //Edit
        public ActionResult EditAddress(int id)
        {


            var Address = _addressData.GetAddressById(id);
            if (Address == null)
                RedirectToAction("AddressDetails");
            return View(Address);

        }

        //Edit Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditAddress(Address Address)
        {
            //Primero
            if (ModelState.IsValid)
            {
                _addressData.Update(Address);
                return RedirectToAction("AddressDetails");
            }
            return View();
        }





    }
}