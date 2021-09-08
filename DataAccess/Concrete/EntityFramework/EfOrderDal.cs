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
    public class EfOrderDal : EfEntityRepositoryBase<Order, GameDbContext>, IOrderDal
    {
        public List<OrderDetailDto> GetOrderDetails(Expression<Func<OrderDetailDto, bool>> filter = null)
        {
            using (GameDbContext context = new GameDbContext())
            {
                var result = from c in context.Customers
                             join u in context.Users
                             on c.UserId equals u.UserId
                             join o in context.Orders
                             on c.CustomerId equals o.CustomerId
                             join g in context.Games
                             on c.GameId equals g.GameId
                             join p in context.Products
                             on g.GameId equals p.GameId
                             select new OrderDetailDto
                             {
                                 CustomerId=c.CustomerId,
                                 UserId=u.UserId,
                                 GameId=g.GameId,
                                 CustomerName=c.CustomerName,
                                 CompanyName=c.CompanyName,
                                 FirstName=u.FirstName,
                                 LastName=u.LastName,
                                 Email=u.Email,
                                 OrderDate=o.OrderDate,
                                 ProductId=p.ProductId,
                                 CategoryId=p.CategoryId,
                                 ProductName=p.ProductName,
                                 UnitPrice=p.UnitPrice,
                                 GameName=g.GameName,
                                 OrderId=o.OrderId
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
