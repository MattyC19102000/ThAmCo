using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ThAmCo.Events.Data
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        /* 
         * List<T> has been replaced with ICollection<T> because List<T> does not support addition operations which is needed
         * to tally up the amount of bookings a single guest has
         */
        public ICollection<GuestBooking> Bookings { get; set; }
    }
}
