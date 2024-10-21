﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Gateway.Models;

public partial class Product
{
    [Key]
    public int ProductId { get; set; }

    [StringLength(100)]
    public string Name { get; set; } = null!;

    [StringLength(255)]
    public string? Description { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }

    public int Stock { get; set; }
}
