using EntityFrameworkDataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Services;

namespace EntityFrameworkDataBase.Controllers
{
    public class HomeController : Controller
    {
        DatabaseFirstEntities db = new DatabaseFirstEntities();

        // GET: Home
        public ActionResult Index()
        {
            var data = db.Students.ToList();
            return View(data);
        }

        public ActionResult Create()
        {

            return View();
        }
        //when create button will be clicked
        [HttpPost]
        public ActionResult Create(Student s)
        {
            if (ModelState.IsValid == true)
            {
                db.Students.Add(s);
                int a = db.SaveChanges();//1 if added otherwise 0
                if (a > 0)
                {
                    TempData["InsertMessgae"] = "<script>alert('Inserted!!!!!!!')</script>";
                    return RedirectToAction("Index");//will go back to Index page
                }
                else
                {
                    TempData["InsertMessgae"] = "<script>alert('Not Inserted!!!!!!!')</script>";
                }

            }
            
            return View();
        }
        public ActionResult Edit(int id)
        {

            var row = db.Students.Where(model => model.StudentId == id).FirstOrDefault();
            return View(row);

        }
        [HttpPost]//Will run when save button will be clicked
        public ActionResult Edit(Student s)
        {
            if (ModelState.IsValid == true)
            {
                db.Entry(s).State = System.Data.Entity.EntityState.Modified;
                int a = db.SaveChanges();//1 if added otherwise 0
                if (a > 0)
                {
                    TempData["UpdateMessgae"] = "<script>alert('SAVED!!!!!!!')</script>";
                    return RedirectToAction("Index");//will go back to Index page
                }
                else
                {
                    TempData["UpdateMessgae"] = "<script>alert('Not Saved!!!!!!!')</script>";
                }

            }

                return View();

        }
        public ActionResult Delete(int id)
        {
            if (id > 0)
            {
                var DeletedRow = db.Students.Where(model => model.StudentId == id).FirstOrDefault();
                //This will not ask for confirmation before deleting
                if (DeletedRow != null)
                {
                    db.Entry(DeletedRow).State = System.Data.Entity.EntityState.Deleted;
                    int b = db.SaveChanges();//1 if added otherwise 0
                    if (b > 0)
                    {
                        TempData["DeleteMessage"] = "<script>alert('DELETED!!!!!!!')</script>";
                        return RedirectToAction("Index");//will go back to Index page
                    }
                    else
                    {
                        TempData["DeleteMessage"] = "<script>alert('Not Deleted!!!!!!!')</script>";
                    }
                }
            }
            
            return View();
        }

        public ActionResult Details(int id)
        {
            var row = db.Students.Where(model => model.StudentId == id).FirstOrDefault();
            return View(row);
        }


    }
}