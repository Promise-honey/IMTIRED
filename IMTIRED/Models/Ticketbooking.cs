using System;
using System.Collections.Generic;

namespace IMTIRED.Models;

public partial class Ticketbooking
{
    public int TicketbookingId { get; set; }
    public int CustomerId { get; set; }
    public DateOnly Date { get; set; }  // Date of visit
    public DateOnly DateBooked { get; set; }  // Booking date

    public virtual Customer Customer { get; set; } = null!;
    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
