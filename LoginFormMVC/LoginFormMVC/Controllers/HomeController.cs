using System.Web.Mvc;

namespace LoginFormMVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //user comes to this page without logging thn redirect to login page
            if (Session["username"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}