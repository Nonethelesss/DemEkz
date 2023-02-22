using Microsoft.EntityFrameworkCore;
using Ruziev.ISP19.Domain.Entities;
using Ruziev.ISP19.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruziev.ISP19.Presentation.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private List<Product> _products = new List<Product>();

        public List<Product> Products
        {
            get => _products;
            set => Set(ref _products, value, nameof(Products));
        }

        public MainWindowViewModel()
        {
            GetProducts();
        }

        public void GetProducts()
        {
            using(var db = new AppDbContext())
            {
                Products = db.Products
                    .Include(p => p.ProductMaterials)
                    .ThenInclude(pm => pm.Material)
                    .Include(p => p.ProductType)
                    .ToList();
            }
        }
    }
}
