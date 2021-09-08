using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IOrderService
    {
        IDataResult<List<Order>> GetAll();
        IDataResult<Order> GetByOrderId(int id);

        IDataResult<List<OrderDetailDto>> GetOrderDetails();
        IDataResult<List<OrderDetailDto>> GetOrderDetailsByOrderId(int orderId);
        IDataResult<List<OrderDetailDto>> GetOrderDetailsByProductId(int productId);

        IResult Insert(Order order);
        IResult Delete(Order order);
        IResult Update(Order order);
    }
}
