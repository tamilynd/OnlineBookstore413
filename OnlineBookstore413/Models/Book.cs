using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookstore413.Models
{
    public class Book
    {
        [Required]
        [Key]
        public int BookId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string AuthorFirst { get; set; }

        [Required]
        public string AuthorLast { get; set; }

        public string AuthorMiddle { get; set; }

        [Required]
        public string Publisher { get; set; }

        //ISBN with regex validation
        [Required]
        [RegularExpression(@"^(\d{3}\-\d{10})$")]
        public string ISBN { get; set; }

        [Required]
        public string Classification { get; set; }

        [Required]
        public string Category { get; set; }

        //Price with Datatype validation
        [Required]
        [DataType(DataType.Currency)]
        public double Price { get; set; }

        [Required]
        public int Pages { get; set; }
    }
}

