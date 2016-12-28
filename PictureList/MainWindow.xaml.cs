﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace PictureList
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            window.MouseLeftButtonDown += Window_MouseLeftButtonDown;
            window.MouseMove += Window_MouseMove;
            window.MouseLeftButtonUp += Window_MouseLeftButtonUp;
            window.Loaded += Window_Loaded;
           
            lstObject = ImageFactory.LoadImages();

            lstObject.Add(addButton);

            Listbox.ItemsSource = lstObject;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            addButton.Style = (Style)this.FindResource("AddButton");
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            CanWinMove = true;
            pos = PointToScreen(e.GetPosition(null));
            Win_Left = this.Left;
            Win_Top = this.Top;
            this.CaptureMouse();
        }

        private void Window_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            CanWinMove = false;
            this.ReleaseMouseCapture();
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            if (CanWinMove)
            {
                Point tempPos = PointToScreen(e.GetPosition(null));
                this.Left = tempPos.X - pos.X + Win_Left;
                this.Top = tempPos.Y - pos.Y + Win_Top;
                Win_Left = this.Left;
                Win_Top = this.Top;
                pos = tempPos;
            }
            
        }

        private void ButtonX_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public static System.Windows.Controls.Button addButton = new System.Windows.Controls.Button();
        public static ObservableCollection<object> lstObject = new ObservableCollection<object>(); 
        private bool CanWinMove = false;
        Point pos = new Point();
        private double Win_Left,Win_Top;
    }
}
