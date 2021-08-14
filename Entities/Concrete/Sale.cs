using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Sale : IEntity
    {
        public int SalesId { get; set; }
        public int GameId { get; set; }
        public int CustomerId { get; set; }
    }
}
