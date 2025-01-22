using System;
using System.Collections.Generic;

namespace Groupwork.Models;

public partial class ParkingLot
{
    public int LotId { get; set; }

    public string Name { get; set; } = null!;

    public string Location { get; set; } = null!;

    public int Capacity { get; set; }

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
