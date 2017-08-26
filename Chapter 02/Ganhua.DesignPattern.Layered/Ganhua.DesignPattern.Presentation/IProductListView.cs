using Ganhua.DesignPattern.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Ganhua.DesignPattern.Presentation
{
    public interface IProductListView
    {
        void Display(IList<ProductViewModel> Products);
        Model.CustomerType CustomerType { get; }
        string ErrorMessage { set; }
    }
}