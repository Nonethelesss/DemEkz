using System;
using System.Collections.Generic;

namespace Ruziev.ISP19.Domain.Entities;

public partial class Material
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int CountInPack { get; set; }

    public string Unit { get; set; } = null!;

    public double? CountInStock { get; set; }

    public double MinCount { get; set; }

    public string? Description { get; set; }

    public decimal Cost { get; set; }

    public string? Image { get; set; }

    public int MaterialTypeId { get; set; }

    public virtual ICollection<MaterialCountHistory> MaterialCountHistories { get; } = new List<MaterialCountHistory>();

    public virtual MaterialType MaterialType { get; set; } = null!;

    public virtual ICollection<ProductMaterial> ProductMaterials { get; } = new List<ProductMaterial>();

    public virtual ICollection<Supplier> Suppliers { get; } = new List<Supplier>();
}
