using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, GameDbContext>, IProductDal
    {
        public List<ProductDetailDto> GetProductDetails()
        {
            using (GameDbContext context = new GameDbContext())
            {
              /*  var result = from p in context.Products
                             join c in context.Categories
                             on p.CategoryId equals c.CategoryId
                             select new ProductDetailDto //hangi kolonları istediğimi yazıyorum
                             {
                                 ProductId = p.ProductId,
                                 ProductName = p.ProductName,
                                 CategoryId = c.CategoryId,
                                 CategoryName = c.CategoryName,
                                 UnitPrice = p.UnitPrice
                             }; */


                var result = from p in context.Products
                             join c in context.Categories
                                 on p.CategoryId equals c.CategoryId
                             join g in context.Games
                                on p.GameId equals g.GameId
                             select new ProductDetailDto
                             {
                                 ProductId = p.ProductId,
                                 ProductName = p.ProductName,
                                 CategoryId = c.CategoryId,
                                 CategoryName = c.CategoryName,
                                 UnitPrice = p.UnitPrice,
                                 GameName=g.GameName,
                                 ReleaseDate=p.ReleaseDate
                             };

                return result.ToList();
            }
        }
    }
}
