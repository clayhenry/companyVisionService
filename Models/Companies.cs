using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StockVisionConsole.Models
{ 
    public class Companies
    {
        [Key]
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Symbol { get; set; }
        public int Updated { get; set; }


    }
}