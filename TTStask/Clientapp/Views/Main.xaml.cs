using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using AppLibrary;
using System.Net.Http.Json;
using Clientapp.ViewModels;

namespace Clientapp
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        MainViewModel viewModel;
        public Main()
        {
            viewModel = new MainViewModel();
            DataContext = viewModel;
            InitializeComponent();
        }
        //единственный способ, который я нашел
        //mousemove невозможно описать в view model
        //eventtrigger не получается 
        //напрямую не биндится из-за типа делегата

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
           viewModel.Window_MouseMove(sender, e);
        }
    }
}
