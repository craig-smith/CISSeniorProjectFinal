using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserOrder
/// </summary>
namespace cisseniorproject.order
{
    public class UserOrder
    {
        public int orderId { get; set; }
        public String creditCardNumber { get; set; }
        public Double orderTotal { get; set; }
        public Double paymentAmount { get; set; }
        public List<UserOrderItem> orderItems { get; set; }

        public UserOrder()
        {
            
        }
    }
}
