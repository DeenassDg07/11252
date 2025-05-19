﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using _1125.ViewModel;

namespace _1125.View
{
    /// <summary>
    /// Логика взаимодействия для ProductsWindow.xaml
    /// </summary>
    public partial class ProductsWindow : Window
    {
        
        public ProductsWindow(string productType)
        {
            InitializeComponent();
            var vm = new ProductsVM(productType);
            vm.SetClose(Close);
            DataContext = vm;
            
        }
        public ProductsWindow(bool CanBaket)
        {
            InitializeComponent();
            DataContext = new ProductsVM(CanBaket);
        }
        


    }
}
