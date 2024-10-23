using Senator.ViewModels;
using System;
using System.IO;
using System.Windows;
using CefSharp.Wpf;

namespace Senator.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel(); 
            LoadMap();
        }

        private void LoadMap()
        {
            string mapPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "map.html");
            if (File.Exists(mapPath))
            {
                MapBrowser.Load(mapPath);
            }
            else
            {
                MessageBox.Show($"File not found: {mapPath}");
            }
        }
    }
}