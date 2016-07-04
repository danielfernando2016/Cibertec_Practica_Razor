using System.Web.Mvc;
using WebDeveloper.DataAccess;
using WebDeveloper.ActionFilter;


namespace WebDeveloper.Controllers
{
    [LogActions]
    public class AddressTypeController : Controller
    {
        // GET: AddressType
        private AddressTypeData _addressType = new AddressTypeData();
        public ActionResult Index()
        {
            return View(_addressType.GetList());
        }
    }
}