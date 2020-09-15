using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc.Models
{
    public class mvcCustomerModel
    {
        public int CustomerId { get; set; }
        [Required(ErrorMessage ="This field is required")]
        public string Name { get; set; }
        public Nullable<int> Age { get; set; }
        public string Address { get; set; }
    }
}