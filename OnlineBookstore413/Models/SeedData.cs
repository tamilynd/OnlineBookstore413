using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookstore413.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder application)
        {
            Bookstore1DBContext context = application.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<Bookstore1DBContext>();

            //Migrate if there are migrations
            if(context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            //Seed the Database if it is empty
            if(!context.Books.Any())
            {
                context.Books.AddRange(
                    //Les Mis
                    new Book
                    {
                        Title = "Les Miserables",
                        AuthorFirst = "Victor",
                        AuthorLast = "Hugo",
                        Publisher = "Signet",
                        ISBN = "978-0451419439",
                        Classification = "Fiction",
                        Category = "Classic",
                        Price = 9.95,
                        Pages = 1488
                    },
                    //Team of Rivals
                    new Book
                    {
                        Title = "Team of Rivals",
                        AuthorFirst = "Doris",
                        AuthorMiddle = "Kearns",
                        AuthorLast = "Goodwin",
                        Publisher = "Simon & Schuster",
                        ISBN = "978-0743270755",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = 14.58,
                        Pages = 944
                    },
                    //The Snowball
                    new Book
                    {
                        Title = "The Snowball",
                        AuthorFirst = "Alice",
                        AuthorLast = "Schroeder",
                        Publisher = "Bantam",
                        ISBN = "978-0553384611",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = 21.54,
                        Pages = 832
                    },
                    //American Ulysses
                    new Book
                    {
                        Title = "American Ulysses",
                        AuthorFirst = "Ronald",
                        AuthorMiddle = "C.",
                        AuthorLast = "White",
                        Publisher = "Random House",
                        ISBN = "978-0812981254",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = 11.61,
                        Pages = 864
                    },
                    //Unbroken
                    new Book
                    {
                        Title = "Unbroken",
                        AuthorFirst = "Laura",
                        AuthorLast = "Hillenbrand",
                        Publisher = "Random House",
                        ISBN = "978-0812974492",
                        Classification = "Non-Fiction",
                        Category = "Historical",
                        Price = 13.33,
                        Pages = 528
                    },
                    //The Great Train Robbery
                    new Book
                    {
                        Title = "The Great Train Robbery",
                        AuthorFirst = "Michael",
                        AuthorLast = "Crichton",
                        Publisher = "Vintage",
                        ISBN = "978-0804171281",
                        Classification = "Fiction",
                        Category = "Historical Fiction",
                        Price = 15.95,
                        Pages = 288
                    },
                    //Deep Work
                    new Book
                    {
                        Title = "Deep Work",
                        AuthorFirst = "Cal",
                        AuthorLast = "Newport",
                        Publisher = "Grand Central Publishing",
                        ISBN = "978-1455586691",
                        Classification = "Non-Fiction",
                        Category = "Self-Help",
                        Price = 14.99,
                        Pages = 304
                    },
                    //It's Your Ship
                    new Book
                    {
                        Title = "It's Your Ship",
                        AuthorFirst = "Michael",
                        AuthorLast = "Abrashoff",
                        Publisher = "Grand Central Publishing",
                        ISBN = "978-1455523023",
                        Classification = "Non-Fiction",
                        Category = "Self-Help",
                        Price = 21.66,
                        Pages = 240
                    },
                    //The Virgin Way
                    new Book
                    {
                        Title = "The Virgin Way",
                        AuthorFirst = "Richard",
                        AuthorLast = "Branson",
                        Publisher = "Portfolio",
                        ISBN = "978-1591847984",
                        Classification = "Non-Fiction",
                        Category = "Business",
                        Price = 29.16,
                        Pages = 400
                    },
                    //Sycamore Row
                    new Book
                    {
                        Title = "Sycamore Row",
                        AuthorFirst = "John",
                        AuthorLast = "Grisham",
                        Publisher = "Bantam",
                        ISBN = "978-0553393613",
                        Classification = "Fiction",
                        Category = "Thrillers",
                        Price = 15.03,
                        Pages = 642
                    },
                    //My First Personal Addition: The Way of Kings
                    new Book
                    {
                        Title = "The Way of Kings",
                        AuthorFirst = "Brandon",
                        AuthorLast = "Sanderson",
                        Publisher = "Tor Books",
                        ISBN = "978-076537667",
                        Classification = "Fiction",
                        Category = "Fantasy",
                        Price = 14.79,
                        Pages = 1008
                    },
                    //My Second Personal addition: Naturally Tan
                    new Book
                    {
                        Title = "Naturally Tan",
                        AuthorFirst = "Tan",
                        AuthorLast = "France",
                        Publisher = "St. Martin's Press",
                        ISBN = "978-1250208668",
                        Classification = "Non-Fiction",
                        Category = "Autobiography",
                        Price = 27.99,
                        Pages = 267
                    },
                    //My Third Personal Addition: Edenbrooke
                    new Book
                    {
                        Title = "Edenbrooke",
                        AuthorFirst = "Julianne",
                        AuthorLast = "Donaldson",
                        Publisher = "Shadow Mountain",
                        ISBN = "978-1609089467",
                        Classification = "Fiction",
                        Category = "Romance",
                        Price = 13.89,
                        Pages = 264
                    }
                ) ;

                context.SaveChanges();
            }
        }
    }
}
