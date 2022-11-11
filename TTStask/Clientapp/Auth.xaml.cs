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
            InitializeComponent();
        }

        private async void Regbtn_Click(object sender, RoutedEventArgs e)
        {
            //Регистрация
            var user = new User(Logintextbox.Text, Passbox.Password);
            var url = "http://localhost:5026/api/main/reg";
            var result = await Post(url, user);
            if (result == "OK")
            {
                Main mainwindow = new Main(Logintextbox.Text);
                mainwindow.Show();
            }
            else MessageBox.Show("Пользователь уже зарегистрирован");


        }


        private async void Loginbtn_Click(object sender, RoutedEventArgs e)
        {
            //Вход
            //учетная запись админа {admin,1234} содержится в бд сервера
            //и с клиентского приложения никак не создается
            var user = new User(Logintextbox.Text, Passbox.Password);

            var url = "http://localhost:5026/api/main/log";
            var result = await Post(url, user);
            if (result == "Userauth")
            {
                Main mainwindow = new Main(Logintextbox.Text);
                mainwindow.Title = "Main window[Default user]";
                this.Close();
                mainwindow.Show();
            }
            else if (result == "Adminauth")
            {
                Main mainwindow = new Main(Logintextbox.Text);
                mainwindow.Title = "Main window[Administrator]";
                this.Close();
                mainwindow.Show();
            }
            else MessageBox.Show("Неправильное имя пользователя/пароль");
        }
        public async Task<string> Post(string uri,User user)
        {

            if (App.GetHttpClient() == null)
            {
                throw new InvalidOperationException();
            }
            var response=await App.GetHttpClient().PostAsJsonAsync(uri,user);
            var content = await response.Content.ReadAsStringAsync();

            return content;
        }
        private void Logintextbox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
