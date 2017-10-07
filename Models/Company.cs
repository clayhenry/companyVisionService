using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StockVisionConsole.Models
{

    public class Company
    {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public string Symbol { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Logo { get; set; }
        public string Country { get; set; }
        
    }
    
}