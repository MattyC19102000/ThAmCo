using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ThAmCo.Catering.Data
{
    public class Menu
    {

        // Blank Constructor for Menu
        public Menu()
        {

        }

       // Constructor takes in param menuName, builds menu from name
        public Menu(string menuName) : this()
        {
            MenuName = menuName;
        }
        // Primary Key 
        public int MenuId { get; set; }

        // None Null String Name
        [Required]
        public string MenuName { get; set; }

        // Reference to all food items on the menu
        public ICollection<MenuFoodItem> MenuFoodItems { get; set; }
    }
}
