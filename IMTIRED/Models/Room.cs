using System;
using System.Collections.Generic;

namespace IMTIRED.Models;

public partial class Room
{
    public int RoomId { get; set; }

    public int RoomNumber { get; set; }

    public string RoomType { get; set; } = null!;

    public int Capacity { get; set; }

    public decimal? PricePerNight { get; set; }

    public bool? IsAvailable { get; set; }

    public virtual ICollection<Roombooking> Roombookings { get; set; } = new List<Roombooking>();
}
