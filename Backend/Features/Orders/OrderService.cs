using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Backend.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

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

    public class OrderService: IOrderService
    {
        private readonly CargoHubDbContext _dbContext;
        public OrderService(CargoHubDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void AddOrder(Order order)
        {
            _dbContext.Orders?.Add(order);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Order> GetAllOrders()
        {
            if (_dbContext.Orders != null)
            {
                return _dbContext.Orders.ToList();
            }
            return new List<Order>();
        }
        public Order? GetOrderById(int id)
        {
            return _dbContext.Orders?.FirstOrDefault(o => o.Id == id);
        }
        public void UpdateOrder(Order order)
        {
            _dbContext.Orders?.Update(order);
            _dbContext.SaveChanges();
        }
        public void DeleteOrder(int id)
        {
            var order = _dbContext.Orders
                ?.Include(o => o.Items)
                .FirstOrDefault(o => o.Id == id);

            if (order != null)
            {
                if (order.Items != null)
                {
                    _dbContext.Items?.RemoveRange(order.Items);
                }

                _dbContext.Orders?.Remove(order);
                _dbContext.SaveChanges();
            }
        }

    }
}
