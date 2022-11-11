using AppLibrary;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Clientapp.ViewModels
{
    public class AppViewModel : INotifyPropertyChanged
    {
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
        void ExecuteRegister(object param)
        {
            
        }
        //Вход
        bool CanExecuteLogin(object param)
        {
            return true;
        }
        void ExecuteLogin(object param)
        {
            
        }
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
