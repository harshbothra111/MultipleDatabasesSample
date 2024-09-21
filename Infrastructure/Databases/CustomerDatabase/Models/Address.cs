using System;
using System.Collections.Generic;

namespace Infrastructure.Databases.CustomerDatabase.Models;

public partial class Address
{
    public int AddressId { get; set; }

    public int CustomerId { get; set; }

    public string Street { get; set; } = null!;

    public string City { get; set; } = null!;

    public string State { get; set; } = null!;

    public string? PostalCode { get; set; }

    public string? Country { get; set; }

    public virtual Customer Customer { get; set; } = null!;
}
