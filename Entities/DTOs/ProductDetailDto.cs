using Core;
using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class ProductDetailDto : IDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string GameName { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string ImagePath { get; set; }
        public string Descriptions { get; set; } 
        public string DescriptionProduct { get; set; }
        public List<ProductImage> ProductImage { get; set; }
    }
}
