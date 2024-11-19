using System;
using System.Collections.Generic;

namespace IMTIRED.Models
{
    public partial class Room
    {
        public int RoomId { get; set; }

        public string RoomNumber { get; set; } = null!;  // Room number as string

        public string RoomType { get; set; } = null!;  // Type of room (e.g., "Single", "Double")

        public int Capacity { get; set; }  // Room capacity (number of people it can accommodate)

        public decimal? PricePerNight { get; set; }  // Price per night (nullable)

        public bool? IsAvailable { get; set; }  // Room availability (nullable)

        // Navigation property for room bookings
        public virtual ICollection<Roombooking> Roombookings { get; set; } = new List<Roombooking>();
    }
}
