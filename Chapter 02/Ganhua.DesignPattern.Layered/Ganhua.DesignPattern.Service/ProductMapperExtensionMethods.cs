using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ganhua.DesignPattern.Service
{
    public static class ProductMapperExtensionMethods
    {
        public static IList<ProductViewModel> ConvertToProductListViewModel(this IList<Model.Product> products)
        {
            IList<ProductViewModel> productViewModels = new List<ProductViewModel>();

            foreach (Model.Product p in products)
            {
                productViewModels.Add(p.ConvertToProductViewModel());
            }

            return productViewModels;
        }

        public static ProductViewModel ConvertToProductViewModel(this Model.Product product)
        {
            ProductViewModel productViewModel = new ProductViewModel();
            productViewModel.No = product.No;
            productViewModel.Name = product.Name;
            productViewModel.Cover = product.Cover;
            productViewModel.Actor = product.Actor;
            productViewModel.URL = product.URL;
            productViewModel.RRP = String.Format("{0:C}", product.Price.RRP);
            productViewModel.SellingPrice = String.Format("{0:C}", product.Price.SellingPrice);

            if (product.Price.Discount > 0)
                productViewModel.Discount = String.Format("{0:C}", product.Price.Discount);

            if (product.Price.Savings < 1 && product.Price.Savings > 0)
                productViewModel.Savings = product.Price.Savings.ToString("#%");

            return productViewModel;
        }
    }
}
