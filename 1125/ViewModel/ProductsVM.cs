using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1125.VMTools;
using System.Windows.Input;
using _1125.View;
using _1125.Model;
using System.Windows;
using _1125.DB;

namespace _1125.ViewModel
{
    internal class ProductsVM : BaseVM
    {
        Action close;
        private List<Product> products;
        private Product selectedProduct;

        public ICommand Back { get; set; }
        public ICommand Baket { get; set; }
       
        public bool CanRegister { get; }

        public List<Product> Products 
        { 
            get => products; 
            set
            {
                products = value;
                Signal();
            }
        }
        public Product SelectedProduct 
        { 
            get => selectedProduct; 
            set
            {
                selectedProduct = value;
                Signal();
            }
        }

        public ProductsVM(string productType)
        {
            SelectAll();
            if (!string.IsNullOrEmpty(productType))
            {
                Search(productType);
            }

            Back = new CommandVM(() =>
            {
                CategoryWindow categoryWindow = new CategoryWindow();
                close?.Invoke();
                categoryWindow.ShowDialog();
            }, () => true);

        }
        public bool CanBaket { get; } = true;
        
        private void Search(string productType)
        {
            
        }


        internal void SetClose(Action close)
        {
            this.close = close;
        }

        private void SelectAll()
        {
            Products = ProductDB.GetDb().SelectAll();
        }
    }
}
