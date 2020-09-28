using EFCodeFirst.Models;
using System.Linq;
using System.Web.Mvc;

namespace EFCodeFirst.Controllers
{
    public class HomeController : Controller
    {

        StudentContext db = new StudentContext();
        // GET: Home
        public ActionResult Index()
        {
            var data = db.Students.ToList();
            return View(data);
        }

        /*public ActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student s)
        {
            if(ModelState.IsValid==true){
            db.Students.Add(s);
            int a= db.SaveChanges();
            if (a > 0)
            {
                ViewBag.InsertMessage = "<script> alert('Data Inserted')</script>";
                ModelState.Clear();
            }
            else
            {
                ViewBag.InsertMessage = "<script> alert('Data Not Inserted')</script>";
            }
        }
            return View();
        }*/
    }
}