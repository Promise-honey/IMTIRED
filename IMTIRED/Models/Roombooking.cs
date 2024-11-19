using System;
using System.Collections.Generic;

namespace IMTIRED.Models;

public partial class Roombooking
{
    public int BookingId { get; set; }

    public int CustomerId { get; set; }

    public int RoomId { get; set; }

    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public decimal? TotalPrice { get; set; } // Nullable type for TotalPrice

    public string? BookingStatus { get; set; } // Nullable type for BookingStatus

    public virtual Customer Customer { get; set; } = null!;

    public virtual Room Room { get; set; } = null!;
}
