﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Email_Helper
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FormCreator Creator;
        public MainWindow()
        {
            InitializeComponent();
            MouseLeftButtonDown += new MouseButtonEventHandler
           (MainWindow_MouseLeftButtonDown);
            Creator = new FormCreator();
        }
        void MainWindow_MouseLeftButtonDown(object sender,

     MouseButtonEventArgs e)

        {

            DragMove();

        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
        private void OnChooseForm(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Window window = Creator.GetWindow(button.Name);
            window.Show();
            Hide();
        }

        private void MinimizeWindow(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }


        private void OpenHelp(object sender, RoutedEventArgs e)
        {
            Process.Start("Email_Helper_Help.chm");
        }
    }
}
