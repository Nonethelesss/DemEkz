using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ruziev.ISP19.Domain.Entities;

public partial class Product
{
    private string? _image = null;
    private decimal _minCostForAgent;

    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int? ProductTypeId { get; set; }

    public string ArticleNumber { get; set; } = null!;

    public string? Description { get; set; }

    public string? Image { get => _image; set => _image = value; }

    public int? ProductionPersonCount { get; set; }

    public int? ProductionWorkshopNumber { get; set; }

    public decimal MinCostForAgent
    {
        get => _minCostForAgent;
        set => _minCostForAgent = value;
    }

    public virtual ICollection<ProductCostHistory> ProductCostHistories { get; } = new List<ProductCostHistory>();

    public virtual ICollection<ProductMaterial> ProductMaterials { get; } = new List<ProductMaterial>();

    public virtual ICollection<ProductSale> ProductSales { get; } = new List<ProductSale>();

    public virtual ProductType? ProductType { get; set; }

    [NotMapped]
    public string ImagePath
    {
        get => (_image == string.Empty) || (_image == null)
            ? $"..\\Resources\\box.png"
            : $"..\\Resources{_image}";
        set => _image = value;
    }
    /*[NotMapped]
    public string Name
    {
        get
        {
            var productTypeTitle = (ProductType == null) ? "Тип" : ProductType.Title;
            return $"{productTypeTitle} | {Title}";
        }
    }*/

    [NotMapped]
    public string Article
    {
        get
        {
            return $"Артикул: {ArticleNumber}";
        }
    }

    [NotMapped]
    public string NameType
    {
        get
        {
            return $"Тип продукта: {ProductType.Title} | Наименование продукта: {Title}";
        }
    }

    [NotMapped]
    public decimal Cost
    {
        get
        {
            if (ProductMaterials.Count == 0)
                return _minCostForAgent;
            decimal cost = 0;
            foreach (var pm in ProductMaterials)
                cost += Math.Ceiling((decimal)pm.Count) * pm.Material.Cost;
            return cost;
        }
    }
    [NotMapped]
    public string CostName
    {
        get
        {
            return $"Цена: {Cost}";
        }
    }
    [NotMapped]
    public string Materials
    {
        get
        {
            if (ProductMaterials.Count == 0)
                return "Материалов нет.";
            
            StringBuilder sb = new StringBuilder();
            sb.Append("Материалы: ");

            foreach (var pm in ProductMaterials)
                sb.Append($"{pm.Material.Title}, ");

            sb.Remove(sb.Length - 2, 2);
            return sb.ToString();
        }
    }
}
