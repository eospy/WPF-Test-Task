using System.Windows;
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
