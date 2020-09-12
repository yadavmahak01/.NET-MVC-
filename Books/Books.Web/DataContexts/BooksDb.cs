using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Books.Entities;

namespace Books.Web.DataContexts
{
    public class BooksDb:DbContext
    {
        public BooksDb()
            : base("Default Connection")
        {
            Database.Log = sql => Debug.Write(sql); 
            //will display all the queries that gets executed
            //install gimpse to know wht is happening. async and gimpse dnt go hand in hand 
        }
        public DbSet<Book> Books { get; set; }//will map to a table(Book)
    }
}