using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace ThAmCo.Catering.Data
{
    public class FoodBooking
    {

        // Blank FoodBooking Constructor
        public FoodBooking()
        {

        }
        // Constructor with params number of guests, and client reference id, builds FoodBooking from these params
        public FoodBooking(int numberOfGuests, int clientReferenceId) : this()
        {
            NumberOfGuests = numberOfGuests;
            ClientReferenceId = clientReferenceId;
        }
        // Primary Key
        public int FoodBookingId { get; set; }
        // Foreign key from ThAmCo.Events
        public int ClientReferenceId { get; set; }
        // None null int amount of guests
        [Required]
        public int NumberOfGuests { get; set; }
        // Menu foriegn key
        public int MenuId { get; set; }
        //  reference to the menu that the key identifys
        public Menu Menu { get; set; }

    }
}
