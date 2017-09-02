using Ganhua.DesignPattern.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ganhua.DesignPattern.Presentation
{
    public class ProductListPresenter
    {
        private IProductListView productListView;
        private Service.ProductService productService;

        public ProductListPresenter(IProductListView productListView, Service.ProductService productService)
        {
            this.productService = productService;
            this.productListView = productListView;
        }

        public void Display()
        {
            ProductListRequest productListRequest = new ProductListRequest();
            productListRequest.CustomerType = productListView.CustomerType;

            ProductListResponse productResponse = 
                productService.GetAllProductsFor(productListRequest);

            if (productResponse.Success)
            {
                productListView.Display(productResponse.Products);
            }
            else
            {
                productListView.ErrorMessage = productResponse.Message;
            }
        }
    }
}
