using _1125.View;
using _1125.VMTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace _1125.ViewModel
{
    public class BasketVM : BaseVM
    {
        public ICommand Back2 { get; set; }
        public ICommand Order { get; set; }
        public BasketVM()
        {
            Back2 = new CommandVM(() =>
                    {
                        CategoryWindow categoryWindow = new CategoryWindow();
                        close?.Invoke();
                        categoryWindow.ShowDialog();
                    }, () => true);
            Order = new CommandVM(() =>
            {
                OrderWindow orderwindow = new OrderWindow();
                close?.Invoke();
                orderwindow.ShowDialog();
            }, () => true);
        }

        Action close;
        internal void SetClose(Action close)
        {
            this.close = close;
        }
    }
}
    

