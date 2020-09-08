using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace KatanaIntro
{
    public class GrettingController:ApiController
    {
        public Greeting Get()
        {
            return new Greeting { Text = "Hello World" };
        }
    }
}
