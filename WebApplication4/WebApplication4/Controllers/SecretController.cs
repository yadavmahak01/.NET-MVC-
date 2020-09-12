using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication4.Controllers
{
    public class SecretController : Controller
    {
        [Authorize]
        //only authorized people will have the access, generally authorize the whole clas
        // GET: Secret

        /*[Authorize(Users="mahak")]-allows this user only.Get roles*/
        public ContentResult Secret()
        {
            return Content("THIS IS A SECRET");
        }

        [AllowAnonymous]//allow everyone to access
        public ContentResult Overt()
        {
            return Content("THIS IS NOT A SECRET");
        }
    }
}