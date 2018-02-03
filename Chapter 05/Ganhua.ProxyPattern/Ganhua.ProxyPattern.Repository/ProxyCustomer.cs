using Ganhua.ProxyPattern.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ganhua.ProxyPattern.Repository
{
    public class ProxyCustomer : Customer
    {
        private bool _haveLoadedOrders = false;
        private IEnumerable<Order> _orders;

        public IOrderRepository OrderRepository { get; set; }

        public ProxyCustomer(IOrderRepository orderRepository)
        {
            OrderRepository = orderRepository;
        }
        public bool HaveLoadedOrders()
        {
            return _haveLoadedOrders;
        }

        public IEnumerable<Order> Orders
        {
            get
            {
                if (!HaveLoadedOrders())
                {
                    RetrieveOrders();
                    _haveLoadedOrders = true;
                }

                return _orders;
            }
            set
            {
                _orders = value;
            }
        }

        private void RetrieveOrders()
        {
            _orders = OrderRepository.FindAllBy(base.Id);
        }
    }
}
