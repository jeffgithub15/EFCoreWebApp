using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Models
{
    public class PriceOffer
    {
        public int PriceOfferId { get; set; }
        public decimal NewPrice { get; set; }
        public string PromotionalText { get; set; }

        //Relationships
        public int BookId { get; set; }
    }
}
