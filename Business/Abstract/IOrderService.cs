﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IOrderService
    {
        List<Order> GetAll();
        Order GetByOrderId(int id);

        void Insert(Order order);
        void Delete(Order order);
        void Update(Order order);
    }
}
