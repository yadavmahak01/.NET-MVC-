using Mvc.Models;
using System.Collections.Generic;
using System.Net.Http;


using System.Web.Mvc;

namespace Mvc.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {


            IEnumerable<mvcCustomerModel> custList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Customer").Result;
            custList = response.Content.ReadAsAsync<IEnumerable<mvcCustomerModel>>().Result;

            return View(custList);
        }
        public ActionResult AddOrEdit(int id = 0)  
        {
            if(id==0)
            return View(new mvcCustomerModel());
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Customer/"+id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcCustomerModel>().Result);
            }

        }
        [HttpPost]
        public ActionResult AddOrEdit(mvcCustomerModel cust)
        {
            if (cust.CustomerId == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Customer", cust).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Customer/"+cust.CustomerId, cust).Result;
                TempData["SuccessMessage"] = "Updated Successfully";
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {

            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Customer/"+id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}