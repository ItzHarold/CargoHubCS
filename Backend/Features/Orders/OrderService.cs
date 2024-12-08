﻿using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Backend.Features.Orders
{
    public interface IOrderService
    {
        IEnumerable<Order> GetAllOrders();
        Order? GetOrderById(int id);
        void AddOrder(Order order);
        // void UpdateOrder(Order order);
        // void DeleteOrder(int id);
    }

    public class OrderService: IOrderService
    {
        private readonly List<Order> _orders = new();
        public void AddOrder(Order order)
        {
            _orders.Add(order);
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _orders;
        }
        public Order? GetOrderById(int id)
        {
            return _orders.FirstOrDefault(o => o.Id == id);
        }

    }
}
