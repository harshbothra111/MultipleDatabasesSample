using System;
using System.Collections.Generic;

namespace Infrastructure.Databases.CustomerDatabase.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Phone { get; set; }

    public DateTime? CreatedDate { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();
}
