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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net.Http;
using System.Net.Http.Json;
using AppLibrary;
using Newtonsoft.Json;
using Clientapp.ViewModels;

namespace Clientapp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    ////это представление
    public partial class Auth : Window
    {
        public static Auth Instance { get; private set; }
        static Auth()
        {
            Instance = new Auth();
        }

        private Auth()
        {
            var authviewmodel = new AuthViewModel();
            DataContext = authviewmodel;
            InitializeComponent();
        }
    }
}
