using System;
using System.Collections.Generic;
using Ganhua.ProxyPattern.Model;
using Ganhua.ProxyPattern.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Ganhua.ProxyPattern.Test
{
    [TestClass]
    public class CustomerProxyTests
    {
        [TestMethod]
        public void CustomerProxy_Should_Delegate_The_Retrieval_Of_Orders_To_The_OrderRepository()
        {
            Guid customerId = Guid.NewGuid();

            var mockery = new Mock<IOrderRepository>();
            mockery.Setup(or => or.FindAllBy(customerId));

            Customer customer = new ProxyCustomer(mockery.Object) { Id = customerId };

            IEnumerable<Order> orders = customer.Orders;

            mockery.VerifyAll();

        }
    }
}
