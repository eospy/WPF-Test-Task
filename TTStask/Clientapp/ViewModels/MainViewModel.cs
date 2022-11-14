﻿using AppLibrary;
using Clientapp;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
namespace Clientapp.ViewModels
{
    public class MainViewModel :ViewModelBase
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Mouseevent> eventslist; 
        ObservableCollection<Mouseevent> fulleventslist;

        bool recordcondition=false;
        //счётчик количества событий
        private string counter;
        int eventscount = 0;
        //количество предложенных отправок
        int sendcount = 1;
        private DateTime _startDate = DateTime.Now;
        private DateTime _endDate = DateTime.Now;
        //диалоговое окно подтверждения отправки пользователем
        string messageBoxText = "Отправить количество записей?";
        string caption = "Подтверждение отправки";
        MessageBoxButton button = MessageBoxButton.YesNo;
        MessageBoxImage icon = MessageBoxImage.Question;

        private readonly RelayCommand _mousebuttoncommand;
        public ICommand MouseButtonCommand => _mousebuttoncommand;

        private readonly RelayCommand _startbuttoncommand;
        public ICommand Startbuttoncommand=> _startbuttoncommand;

        private readonly RelayCommand _filterbydatecommand;
        public ICommand Filterbydatecommand => _filterbydatecommand;

        private readonly RelayCommand _cancelfilterscommand;
        public ICommand Cancelfilterscommand=> _cancelfilterscommand;
        public MainViewModel()
        {
            eventslist = new ObservableCollection<Mouseevent>();
            fulleventslist = new ObservableCollection<Mouseevent>();
            _mousebuttoncommand = new RelayCommand(Mousebutton);
            _startbuttoncommand = new RelayCommand(StartButton);
            _filterbydatecommand = new RelayCommand(FilterByDate);
            _cancelfilterscommand = new RelayCommand(CancelFilters);
        }
        public DateTime Starttime
        {
            get { return _startDate; }
            set { _startDate = value; OnPropertyChanged("Starttime"); }
        }
        public DateTime Endtime
        {
            get { return _endDate; }
            set { _endDate = value; OnPropertyChanged("Endtime"); }
        }
        private void Mousebutton(object param)
        {
            if (recordcondition)
            {
                double curx = Mouse.GetPosition(null).X;
                double cury = Mouse.GetPosition(null).Y;
                Mouseevent buttonpress = new Mouseevent(DateTime.Now,param.ToString(), curx, cury);
                fulleventslist.Add((buttonpress));
                eventslist.Add(buttonpress);
                SendEvent(buttonpress);
            }
            
        }
        
        private async void StartButton(object param)
        {
            recordcondition = !recordcondition;
            //отправка состояния на сервер
            string str;
            if (recordcondition) str = "start";
            else str = "stop";
            var url = "http://localhost:5026/api/events/Recordcondition";
            var result = await Post(url, new Conditions(str));
        }
        private void FilterByDate(object param)
        {
            if (!recordcondition)
            {
                var itemsToRemove = eventslist
                      .Where(p => p.dateTime > _endDate || p.dateTime < _startDate)
                      .ToList();
                foreach (var item in itemsToRemove) eventslist.Remove(item);
            }
        }
        private void CancelFilters(object param)
        {
            eventslist.Clear();
            foreach (var item in fulleventslist) eventslist.Add(item);
        }
        public string Eventscount
        {
            protected set { this.SetProperty<string>(ref counter, value); }
            get { return counter; }
        }
        public ObservableCollection<Mouseevent> Events
        {
            get=>eventslist;
            set=> SetProperty(ref eventslist, value);
        }
        private async void SendEvent(Mouseevent mouseevent)
        {
            eventscount++;
            this.Eventscount= eventscount.ToString(); ;
            if (eventscount > 50 * sendcount)
            {
                CheckMessageBox(MessageBox.Show(messageBoxText, caption, button, icon));
                sendcount++;
            }
            var url = "http://localhost:5026/api/events/Sendevent";
            var result = await Post(url, mouseevent);
        }
        private void CheckMessageBox(MessageBoxResult result)
        {
            switch (result)
            {
                case MessageBoxResult.Yes:
                    SendLetters();
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }
        private async void SendLetters()
        {
            LetterRequest req = new LetterRequest(eventscount, "user");
            var url = "http://localhost:5026/api/events/Sendletter";
            var response = await Post(url, req);
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
