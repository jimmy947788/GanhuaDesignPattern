using Ganhua.DesignPattern.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ganhua.DesignPattern.Model;
using Ganhua.DesignPattern.Service;
using Microsoft.Practices.Unity;

namespace Ganhua.DesignPattern.WebUI
{
    public partial class _Default : System.Web.UI.Page, IProductListView
    {
        private ProductListPresenter presenter;

        [Dependency]
        public Service.ProductService productService { get; set; }


        protected void Page_Init(object sender, EventArgs e)
        {
            presenter = new ProductListPresenter(this, productService);
            this.ddlDiscountType.SelectedIndexChanged += delegate { presenter.Display(); };
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack != true)
                presenter.Display();
        }

        public string ErrorMessage
        {
            set { lblErrorMessage.Text = String.Format("<p><strong>Error</strong><br/>{0}<p/>", value); }
        }

        public void Display(IList<ProductViewModel> Products)
        {
            GridView1.DataSource = Products;
            GridView1.DataBind();
        }

        public CustomerType CustomerType
        {
            get { return (CustomerType)Enum.ToObject(typeof(CustomerType), int.Parse(this.ddlDiscountType.SelectedValue)); }
        }
    }
}