
using System.Linq;

using System.Web.Mvc;
using WebDeveloper.DataAccess;
using WebDeveloper.Model;
using WebDeveloper.ActionFilter;
namespace WebDeveloper.Controllers
{
    [LogActions]
    public class PersonController : Controller
    {
        // GET: Person
        private PersonData _personData = new PersonData();
        public ActionResult Index()
        {
            var iList = (from p in _personData.GetList()
                         orderby p.BusinessEntityID descending
                         select p).Take(100);
            return View(iList);
            
        }


        public ActionResult Create()
        {
            return View(new Person());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Person Person)
        {
            //Primero
            if (ModelState.IsValid)
            {
                _personData.Add(Person);
                return RedirectToAction("Index");
            }
            return View();
        }

        //Edit
        public ActionResult Edit(int id)
        {


            var Person = _personData.GetPersonById(id);
            if (Person == null)
                RedirectToAction("Index");
            return View(Person);

        }

        //Edit Post
        [HttpPost,ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Person Person)
        {
            //Primero
            if (ModelState.IsValid)
            {
                _personData.Update(Person);
                return RedirectToAction("Index");
            }
            return View();
        }


        //Delete
        public ActionResult Delete(int id)
        {


            var Person = _personData.GetPersonById(id);
            if (Person == null)
                RedirectToAction("Index");
            return View(Person);

        }

        //Delete Post
        [HttpPost, ValidateInput(false)]
        public ActionResult Delete(Person Person)
        {

            if (_personData.Delete(Person) > 0)
                return RedirectToAction("Index");

            return View();
        }
    }
}