using System;
using System.Collections.Generic;

namespace Identity.Domain;

public partial class User
{
    public int IdUser { get; set; }

    public int IdRolUser { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;
}
