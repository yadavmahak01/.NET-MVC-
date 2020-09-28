using LoginFormMVC.Models;
using System.Linq;
using System.Web.Mvc;

namespace LoginFormMVC.Controllers
{
    public class LoginController : Controller
    {
        LoginDBEntities db = new LoginDBEntities(); 
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(user u)
        {
            if (ModelState.IsValid == true)
            {
                var credentials = db.users.Where(model => model.username == u.username && model.password==u.password).FirstOrDefault();
                if (credentials == null)
                {
                    ViewBag.ErrorMessage = "Login failed";
                    return View();
                }
                else
                {
                    Session["username"] = u.username;
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            //Destroy session
            Session.Abandon();
            return RedirectToAction("Index","Login");
        }
        public ActionResult Reset()
        {
            ModelState.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
}