using System;
using System.Collections.Generic;

namespace Identity.Domain;

public partial class UserDatum
{
    public int IdUser { get; set; }

    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public string Phone { get; set; } = null!;
}
