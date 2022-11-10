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
using Newtonsoft.Json;
using System.Net.Http;
using Microsoft.Data.Sqlite;
namespace Clientapp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
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
            //данные из клиентского приложения -> http запрос на сервер -> сохранение в бд
            //пароль хранится в открытом виде
            var user = new User(Logintextbox.Text,Passbox.Password);
            var json = JsonConvert.SerializeObject(user);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var url = "http://localhost:5026/api/main/reg";
            var response = await App.GetHttpClient().PostAsync(url, data);
            var result = await response.Content.ReadAsStringAsync();
            if (result == "OK")
            {
                Main mainwindow =new Main(Logintextbox.Text);
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
            var json = JsonConvert.SerializeObject(user);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var url = "http://localhost:5026/api/main/log";
            var response = await App.GetHttpClient().PostAsync(url, data);
            var result = await response.Content.ReadAsStringAsync();
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

        private void Logintextbox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
