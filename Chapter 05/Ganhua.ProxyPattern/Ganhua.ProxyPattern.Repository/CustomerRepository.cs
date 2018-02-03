using Ganhua.ProxyPattern.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ganhua.ProxyPattern.Repository
{
    public class CustomerRepository : ICustomerRespository
    {
        private IOrderRepository _orderRepository;

        public CustomerRepository(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Customer FindBy(Guid id)
        {
            Customer customer = new ProxyCustomer(_orderRepository);

            // Code to connect to the database and retrieve a customer
            customer.Id = new Guid("0b7f95b0-be8b-4758-a994-c4ab81d33b40");
            customer.OrderDate = DateTime.Parse("2018-01-12");
            //customer.Orders;
            
            return customer;
        }
    }
}
