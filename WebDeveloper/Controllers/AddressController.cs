using System.Linq;
using System.Web.Mvc;
using WebDeveloper.DataAccess;
using WebDeveloper.Model;
using WebDeveloper.ActionFilter;


namespace WebDeveloper.Controllers
{
    [LogActions]
    [RoutePrefix("Address")]
    public class AddressController : Controller
    {
        // GET: Address
        private AddressData _addressData = new AddressData();
        public ActionResult Index()
        {
            
            //return View(_addressData.GetList());
            var iList = (from p in _addressData.GetList()
                         orderby p.AddressID descending
                         select p).Take(100);
            return View(iList);
        }

        [Route("Address/Create")]
        public ActionResult Create()
        {
            return View(new Address());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Address Address)
        {
            //Primero
            if (ModelState.IsValid)
            {
                _addressData.Add(Address);
                return RedirectToAction("Index");
            }
            return View();
        }

        //Edit
        [Route("Address/Edit")]
        public ActionResult Edit(int id)
        {


            var Address = _addressData.GetAddressById(id);
            if (Address == null)
                RedirectToAction("Index");
            return View(Address);

        }

        //Edit Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Address Address)
        {
            //Primero
            if (ModelState.IsValid)
            {
                _addressData.Update(Address);
                return RedirectToAction("Index");
            }
            return View();
        }


        //Delete
        public ActionResult Delete(int id)
        {


            var Address = _addressData.GetAddressById(id);
            if (Address == null)
                RedirectToAction("Index");
            return View(Address);

        }

        //Edit Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Address Address)
        {

            if (_addressData.Delete(Address) > 0)
                return RedirectToAction("Index");

            return View();
        }
       

    }
}