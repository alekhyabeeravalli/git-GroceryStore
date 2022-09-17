using GroceryStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStore.Core.Interface
{
    public interface IOrder
    {
        List<OrderModel> GetOrder();
        OrderModel AddOrder(OrderModel orderModel);
        OrderModel UpdateOrder(OrderModel orderModel);
        OrderModel DeleteOrder(int orderId);
    }
}
