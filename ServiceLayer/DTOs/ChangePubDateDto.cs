using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ServiceLayer.DTOs
{
    public class ChangePubDateDto
    {
        public int BookId { get; set; } 
        public string Title { get; set; }  
        [DataType(DataType.Date)] 
        public DateTime PublishedOn { get; set; }
    }
}
