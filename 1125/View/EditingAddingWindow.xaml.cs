﻿using _1125.ViewModel;
using System;
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

namespace _1125.View
{
    /// <summary>
    /// Логика взаимодействия для EditingAddingWindow.xaml
    /// </summary>
    public partial class EditingAddingWindow : Window
    {
        public EditingAddingWindow()
        {
            InitializeComponent();
            DataContext = new EditingAddingWindowViewModel();
        }
    }
}
