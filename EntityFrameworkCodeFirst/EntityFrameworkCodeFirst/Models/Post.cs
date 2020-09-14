using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntityFrameworkCodeFirst.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string PostDate { get; set; }

        //Each Post should have 1 blogId 
        public int BlogId { get; set; }
        public virtual Blog Blog { get; set; }

    }
}