using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ganhua.DesignPattern.Model
{
    public class ProductService
    {
        private IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IList<Product> GetAllProductsFor(CustomerType customerType)
        {
            IDiscountStrategy discountStrategy = DiscountFactory.GetDiscountStrategyFor(customerType);
            IList<Product> products = _productRepository.FindAll();

            products.Apply(discountStrategy);

            return products;
        }
    }
}
