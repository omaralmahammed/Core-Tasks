﻿using System;
using System.Collections.Generic;

namespace Day4.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int? UserId { get; set; }

    public DateTime? OrderDate { get; set; }

    public virtual User? User { get; set; }
}
