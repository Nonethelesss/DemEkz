using System;
using System.Collections.Generic;

namespace Ruziev.ISP19.Domain.Entities;

public partial class MaterialType
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public double DefectedPercent { get; set; }

    public virtual ICollection<Material> Materials { get; } = new List<Material>();
}
