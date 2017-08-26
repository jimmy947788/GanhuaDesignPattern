using Ganhua.DesignPattern.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ganhua.DesignPattern.Repository
{
    public class ProductRepository : IProductRepository
    {
        public IList<Model.Product> FindAll()
        {
            var products = from p in new ShopDataContext().Products
                           select new Model.Product
                           {
                               No = p.No,
                               Name = p.Name,
                               Price = new Model.Price(p.RRP, p.SellingPrice),
                               Cover = p.Cover,
                               URL = p.URL,
                               Actor = p.Actor
                           };

            return products.ToList();
        }

    }
}
