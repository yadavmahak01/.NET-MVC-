using EntityFrameworkCodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EntityFrameworkCodeFirst.Context
{
    //DbContext is the base class of entityframework
    public class BlogContext : DbContext
    {

        public BlogContext():base("conn")
        {

        }
        //Through dbset we can add queries to our db
        public DbSet<Blog> Blogs { get; set; }

        public DbSet<Post> Posts { get; set; }
    }
}