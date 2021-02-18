using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookstore413.Models
{
    //Class derived from IBookStorerepository
    public class EFBookstoreRepository : IBookstoreRepository
    {
        private Bookstore1DBContext _context;

        //Constructor
        public EFBookstoreRepository (Bookstore1DBContext context)
        {
            _context = context;
        }

        public IQueryable<Book> Books => _context.Books;
    }
}
