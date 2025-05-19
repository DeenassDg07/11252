using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1125.VMTools;
using System.Windows.Input;
using _1125.View;
using _1125.Model;

namespace _1125.ViewModel
{
    internal class ProductsVM : BaseVM
    {
        public ICommand Back { get; set; }
        public ICommand Baket { get; set; }
       
        public bool CanRegister { get; }

        public ProductsVM(string productType)
        {
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
        public ProductsVM(bool canBaket)
        {
            CanBaket = canBaket;
            if (user.Role == "user")
            {

                BasketWindow basketwindow = new BasketWindow();
                basketwindow.ShowDialog();
                close?.Invoke();
            }
            else if (user.Role == "guest")
            {
               
            }
        }
        private void Search(string productType)
        {
            
        }

        Action close;
        internal void SetClose(Action close)
        {
            this.close = close;
        }
    }
}
