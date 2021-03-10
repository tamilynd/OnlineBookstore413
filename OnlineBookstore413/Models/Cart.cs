using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookstore413.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();

        public virtual void AddItem (Book book, int quantity)
        {
            //check to see if this book is already in the cart
            CartLine line = Lines
                .Where(p => p.Book.BookId == book.BookId)
                .FirstOrDefault();

            //add new cartline if book is not already in cart
            if (line == null)
            {
                Lines.Add(new CartLine
                {
                    Book = book,
                    Quantity = quantity
                });
            }
            //increase quantity if book is already in cart
            else
            {
                line.Quantity += quantity;
            }
        }

        //remove a specific item from a cart
        public virtual void RemoveLine(Book book) {
            Lines.RemoveAll(x => x.Book.BookId == book.BookId);
         }
       

        //remove all items cart
        public virtual void Clear() => Lines.Clear();


        //compute sum
        public double ComputeTotalSum()
        {
            return Lines.Sum(e => e.Book.Price * e.Quantity);
        }

        //Bundle cart product information
        public class CartLine
        {
            public int CartLineID { get; set; }
            public Book Book { get; set; }
            public int Quantity { get; set; }
        }
    }
}
