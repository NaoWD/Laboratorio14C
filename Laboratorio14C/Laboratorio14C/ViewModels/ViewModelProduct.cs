using Laboratorio14C.Models;
using Laboratorio14C.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Laboratorio14C.ViewModels
{
    public class ViewModelProduct : BaseViewModel
    {

        private string color;

        public string Color
        {
            get { return this.color; }
            set { SetValue(ref this.color, value); }
        }

        private string filter;
        public string Filter
        {
            get { return this.filter; }
            set { SetValue(ref this.filter, value); }
        }

        private List<Product> product;
        public List<Product> Product
        {
            get { return this.product; }
            set { SetValue(ref this.product, value); }
        }


        public ICommand SearchCommand { get; set; }

        public ViewModelProduct()
        {

            SearchCommand = new Command(() =>
            {
                ProductService service = new ProductService();
                Product = service.GetByText(Filter);
                if (Product.Count > 3)
                    Color = "Red";
                else
                    Color = "Blue";

            });


        }

    }
}
