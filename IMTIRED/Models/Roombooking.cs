using System;
using System.Collections.Generic;

namespace IMTIRED.Models;

public partial class Roombooking
{
    public int BookingId { get; set; }

    public int CustomerId { get; set; }

    public int RoomId { get; set; }

    public DateOnly? CheckInDate { get; set; }   // Change from non-nullable to nullable
    public DateOnly? CheckOutDate { get; set; }  // Change from non-nullable to nullable


    public decimal? TotalPrice { get; set; }

    public string? BookingStatus { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual Room Room { get; set; } = null!;
}
