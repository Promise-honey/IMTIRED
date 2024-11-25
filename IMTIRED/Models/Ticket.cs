using System;
using System.Collections.Generic;
namespace IMTIRED.Models
{
    public partial class Ticket
    {
        public int TicketId { get; set; }
        public int AttractionId { get; set; }
        public int TicketbookingId { get; set; }
        public string TicketType { get; set; } = null!; // Add this
        public decimal Price { get; set; } // Add this
        public int Quantity { get; set; } // Add this
        public virtual Attraction Attraction { get; set; } = null!;
        public virtual Ticketbooking Ticketbooking { get; set; } = null!;
    }
}

public class TicketItem
{
    public string TicketType { get; set; } = null!;
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}