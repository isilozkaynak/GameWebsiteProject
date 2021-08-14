using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IOrderService
    {
        IDataResult<List<Order>> GetAll();
        IDataResult<Order> GetByOrderId(int id);

        IResult Insert(Order order);
        IResult Delete(Order order);
        IResult Update(Order order);
    }
}
