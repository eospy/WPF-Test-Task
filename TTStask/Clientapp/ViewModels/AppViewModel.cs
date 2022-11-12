using AppLibrary;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;

namespace Clientapp.ViewModels
{
    public class AppViewModel : INotifyPropertyChanged
    {
        public User currentuser;
        private string curlogin = "";
        private string curpassword = "";
        public event PropertyChangedEventHandler PropertyChanged;
        public AppViewModel()
        {
            //поля с логином,паролем,таблица,кнопка запуска,счетчик,3 переключателя,2 выбора даты
            //и события мыши
            this.RegisterCommand = new RelayCommand(ExecuteRegister, CanExecuteRegister);
            this.LoginCommand= new RelayCommand(ExecuteLogin, CanExecuteLogin);
        }
       
        // Реализация ICommand
        public IDelegateCommand RegisterCommand { protected set; get; }

        public IDelegateCommand LoginCommand { protected set; get; }
        
        //Регистрация
        bool CanExecuteRegister(object param)
        {
            return true;

        }
        async void ExecuteRegister(object param)
        {
            LetterRequest req = new LetterRequest(666,"admin");
            var json = JsonConvert.SerializeObject(req);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var url = "http://localhost:5026/api/events/Sendletter";
            var response = await App.GetHttpClient().PostAsync(url, data);
        }
        //Вход
        bool CanExecuteLogin(object param)
        {
            return true;
        }
        void ExecuteLogin(object param)
        {
            MessageBox.Show(param as string);
        }
        protected bool SetProperty<T>(ref T storage, T value,
                                 [CallerMemberName] string propertyName = null)
        {
            if (object.Equals(storage, value))
                return false;

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
