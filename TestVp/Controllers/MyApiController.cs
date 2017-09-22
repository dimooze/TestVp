
using System.Linq;
using System.Web.Mvc;
using TestVp.Attributes;
using TestVp.Manager;

namespace TestVp.Controllers
{

    [CustomAuthorize]
    public class MyApiController : Controller
    {
        public JsonResult IsLoggedIn(string email)
        {
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}
