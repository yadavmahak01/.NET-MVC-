using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntityFrameworkCodeFirst.Models
{
    public class Blog
    {

        //1-Many relationship each blog can have many posts

        public int BlogId { get; set; }
        public string Name { get; set; }
        public virtual List<Post> Posts { get; set; }

    }
}