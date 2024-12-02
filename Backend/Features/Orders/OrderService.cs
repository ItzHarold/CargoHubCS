using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Backend.Features.Orders
{
    public interface IOrderService
    {
        IEnumerable<Order> GetAllOrders();
        Order? GetOrderById(int id);
        void AddOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(int id);
    }

    public class OrderService
    {

    }
}
