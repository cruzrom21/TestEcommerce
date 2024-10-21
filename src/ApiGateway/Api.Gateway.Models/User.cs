using System;
using System.Collections.Generic;

namespace Api.Gateway.Models;

public partial class User
{
    public int IdUser { get; set; }

    public int IdRolUser { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;
}
