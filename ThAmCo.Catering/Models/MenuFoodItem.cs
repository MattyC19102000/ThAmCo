using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ThAmCo.Catering.Data
{
    public class MenuFoodItem
    {
        // Composite key, holds all combinations of menus and food items
        public int MenuId { get; set; }
        public Menu Menu { get; set; }

        public int FoodItemId { get; set; }
        public FoodItem FoodItem { get; set; }
    }
}
