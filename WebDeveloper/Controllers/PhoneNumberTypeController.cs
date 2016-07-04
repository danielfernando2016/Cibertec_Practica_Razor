
using System.Web.Mvc;
using WebDeveloper.DataAccess;
using WebDeveloper.Model;
using WebDeveloper.ActionFilter;
namespace WebDeveloper.Controllers
{
    [LogActions]
    public class PhoneNumberTypeController : Controller
    {
        // GET: PhoneNumberType
        private PhoneNumberTypeData _phoneNumberType = new PhoneNumberTypeData();
        public ActionResult Index()
        {
            return View(_phoneNumberType.GetList());
        }


        public ActionResult Create()
        {
            return View(new PhoneNumberType());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PhoneNumberType phoneNumberType)
        {
            //Primero
            if (ModelState.IsValid)
            {
                _phoneNumberType.Add(phoneNumberType);
                return RedirectToAction("Index");
            }
            return View();
        }

        //Edit
        public ActionResult Edit(int id)
        {


            var phoneNumberType = _phoneNumberType.GetPhoneNumberTypeById(id);
            if (phoneNumberType == null)
                RedirectToAction("Index");
            return View(phoneNumberType);

        }

        //Edit Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PhoneNumberType phoneNumberType)
        {
            //Primero
            if (ModelState.IsValid)
            {
                _phoneNumberType.Update(phoneNumberType);
                return RedirectToAction("Index");
            }
            return View();
        }


        //Delete
        public ActionResult Delete(int id)
        {


            var phoneNumberType = _phoneNumberType.GetPhoneNumberTypeById(id);
            if (phoneNumberType == null)
                RedirectToAction("Index");
            return View(phoneNumberType);

        }

        //Edit Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(PhoneNumberType phoneNumberType)
        {
            
            if (_phoneNumberType.Delete(phoneNumberType) > 0)
                return RedirectToAction("Index");

            return View();
        }

    }
}