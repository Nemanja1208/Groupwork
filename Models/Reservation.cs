using System;
using System.Collections.Generic;

namespace Groupwork.Models;

public partial class Reservation
{
    public int ReservationId { get; set; }

    public int VehicleId { get; set; }

    public int LotId { get; set; }

    public DateOnly ReservationDate { get; set; }

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public virtual ParkingLot Lot { get; set; } = null!;

    public virtual Vehicle Vehicle { get; set; } = null!;
}
