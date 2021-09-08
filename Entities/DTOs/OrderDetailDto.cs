using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class OrderDetailDto : IDto
    {
        //customer
        public int CustomerId { get; set; }
        public int UserId { get; set; }
        public string CustomerName { get; set; }
        public string CompanyName { get; set; }
        public int GameId { get; set; }
        //user
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        //order
        public DateTime OrderDate { get; set; }
        //product
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        //game
        public string GameName { get; set; }
    }
}
