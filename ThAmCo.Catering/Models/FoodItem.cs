using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ThAmCo.Catering.Data
{
    public class FoodItem
    {
        // Blank constructor for fooditem
        public FoodItem()
        {

        }
        // Constructor takes in params description and price to build FoodItem
        public FoodItem(string description, float unitprice) : this()
        {
            Description = description;
            UnitPrice = unitprice;
        }
        // Primary Key
        public int FoodItemId { get; set; }

        // None Null string item description
        [Required]
        public string Description { get; set; }

        // None Null float price information
        [Required]
        public float UnitPrice { get; set; }
    }
}
