using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Models
{
    public class Book
    {
        public int BookId { get; set; }

        [Required]
        [MaxLength(256)]
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublishedOn { get; set; }

        [MaxLength(64)]
        public string Publisher { get; set; }
        public decimal Price { get; set; }

        [MaxLength(512)]
        public string ImageUrl { get; set; }
        public bool SoftDeleted { get; set; }

        //Relationships
        public PriceOffer Promotion { get; set; }
        public IList<Review> Reviews { get; set; }
        public IList<BookAuthor> AuthorsLink { get; set; }
    }                                                                                                              
}
