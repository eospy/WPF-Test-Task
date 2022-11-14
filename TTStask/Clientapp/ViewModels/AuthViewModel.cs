using AppLibrary;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Clientapp.ViewModels
{
    public class AuthViewModel : ViewModelBase
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string curlogin;
        public string curpass;
        private readonly RelayCommand _regCommand;
        private readonly RelayCommand _logCommand;
        public ICommand RegCommand => _regCommand;
        public ICommand LogCommand => _logCommand;
        public AuthViewModel()
        {
            _regCommand = new RelayCommand(OnRegister);
            _logCommand = new RelayCommand(OnLogin);
        }
        //регистрация
        private async void OnRegister(object commandParameter)
        {
            var user = new User(curlogin, curpass);
            var url = "http://localhost:5026/api/main/reg";
            var result = await Post(url, user);
            if (result == "OK")
            {
                Main mainwindow = new Main();
                mainwindow.Show();
            }
            else MessageBox.Show("Пользователь уже зарегистрирован");
            _regCommand.RaiseCanExecuteChanged();
        }

        //вход
        private async void OnLogin(object commandParameter)
        {
            //немного нарушается mvvm и не соблюдается безопасность
            var passbox = commandParameter as PasswordBox;
            curpass = passbox.Password;
            var user = new User(curlogin,curpass);
            var url = "http://localhost:5026/api/main/log";
            var result = await Post(url, user);
            if (result == "Userauth")
            {
                Main mainwindow = new Main();
                mainwindow.Title = "Main window[Default user]";
                mainwindow.Show();
            }
            else if (result == "Adminauth")
            {
                Main mainwindow = new Main();
                mainwindow.Title = "Main window[Administrator]";
                mainwindow.Show();
            }
            else MessageBox.Show("Неправильное имя пользователя/пароль");
            _logCommand.RaiseCanExecuteChanged();
        }

        public string Curlogin
        {
            get =>curlogin;
            set => SetProperty(ref curlogin, value);
        }
        public string Curpass
        {
            get => curpass;
            set => SetProperty(ref curpass, value);
        }
        //отправка запросов
        public async Task<string> Post(string uri, object o)
        {

            if (App.GetHttpClient() == null)
            {
                throw new InvalidOperationException();
            }
            var response = await App.GetHttpClient().PostAsJsonAsync(uri, o);
            var content = await response.Content.ReadAsStringAsync();

            return content;
        }
        public void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
