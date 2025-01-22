using System;
using System.Collections.Generic;

namespace Groupwork.Models;

public partial class Vehicle
{
    public int VehicleId { get; set; }

    public string LicensePlate { get; set; } = null!;

    public string OwnerName { get; set; } = null!;

    public string VehicleType { get; set; } = null!;

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
