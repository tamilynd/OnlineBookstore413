using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookstore413.Models
{
    //Class derived from DbContext
    public class Bookstore1DBContext : DbContext
    {
        //constructor that receives dbcontext as a parameter
        public Bookstore1DBContext(DbContextOptions<Bookstore1DBContext> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }

    }
}
