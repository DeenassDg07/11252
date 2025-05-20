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
    internal class OrderVM : BaseVM
    {
        public ICommand Cancel { get; set; }
        public ICommand Ok { get; set; }
        public OrderVM()
        {
            Cancel = new CommandVM(() =>
            {
                BasketWindow basketwindow = new BasketWindow();
                close?.Invoke();
                basketwindow.ShowDialog();
            }, () => true);
            Ok = new CommandVM(() =>
            {
                MainWindow mainwindow = new MainWindow();
                close?.Invoke();
                mainwindow.ShowDialog();
            }, () => true);
        }

        Action close;
        internal void SetClose(Action close)
        {
            this.close = close;
        }
    }
}

