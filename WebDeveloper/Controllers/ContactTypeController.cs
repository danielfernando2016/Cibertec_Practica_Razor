
using System.Web.Mvc;
using WebDeveloper.DataAccess;
using WebDeveloper.Model;
using WebDeveloper.ActionFilter;

namespace WebDeveloper.Controllers
{
    [LogActions]
    public class ContactTypeController : Controller
    {
        // GET: ContactType
        private ContactTypeData _contactTypeData = new ContactTypeData();
        public ActionResult Index()
        {
            return View(_contactTypeData.GetList());
        }


        public ActionResult Create()
        {
            return View(new ContactType());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ContactType ContactType)
        {
            //Primero
            if (ModelState.IsValid)
            {
                _contactTypeData.Add(ContactType);
                return RedirectToAction("Index");
            }
            return View();
        }

        //Edit
        public ActionResult Edit(int id)
        {


            var ContactType = _contactTypeData.GetContactTypeById(id);
            if (ContactType == null)
                RedirectToAction("Index");
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
                return RedirectToAction("Index");
            }
            return View();
        }


        //Delete
        public ActionResult Delete(int id)
        {


            var ContactType = _contactTypeData.GetContactTypeById(id);
            if (ContactType == null)
                RedirectToAction("Index");
            return View(ContactType);

        }

        //Edit Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ContactType ContactType)
        {

            if (_contactTypeData.Delete(ContactType) > 0)
                return RedirectToAction("Index");

            return View();
        }
    }
}