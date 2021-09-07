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
        public List<ProductDetailDto> GetProductDetails(Expression<Func<ProductDetailDto, bool>> filter = null)
        {
            using (GameDbContext context = new GameDbContext())
            {
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
                                 ReleaseDate=p.ReleaseDate,
                                 Descriptions=g.Descriptions,
                                 ProductImage = (from i in context.ProductImages
                                                 where (p.ProductId == i.ProductId)
                                             select new ProductImage { ProductImageId = i.ProductImageId,
                                                 ProductId = p.ProductId, 
                                                 UploadDate = i.UploadDate, 
                                                 ImagePath = i.ImagePath }).ToList()
                             };

                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }

        /*
        public List<ProductDetailDto> GetProductDetailsById(int id)
        {
            using (GameDbContext context = new GameDbContext())
            {
                var result = from p in context.Products
                             join c in context.Categories
                                 on p.CategoryId equals c.CategoryId
                             join g in context.Games
                                on p.GameId equals g.GameId
                            join pI in context.ProductImages
                                on p.ProductId equals pI.ProductId
                             select new ProductDetailDto
                             {
                                 ProductId = p.ProductId,
                                 ProductName = p.ProductName,
                                 CategoryId = c.CategoryId,
                                 CategoryName = c.CategoryName,
                                 UnitPrice = p.UnitPrice,
                                 GameName = g.GameName,
                                 ReleaseDate = p.ReleaseDate,
                                 ImagePath=pI.ImagePath,
                                 Descriptions = g.Descriptions
                             };

                return result.ToList();
            }
        } */
    }
}
