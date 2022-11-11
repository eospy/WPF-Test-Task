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
namespace Clientapp
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    //это представление
    public partial class Main : Window
    {
        //имя пользователя
        string username = "";
        //состояние нажатия кнопки запуск/стоп
        bool recordcondition = false;
        //предыдущие координты указателя мыши
        double xprev = 0;
        double yprev = 0;
        //список событий мыши для отображения в таблице
        ObservableCollection<Mouseevents> eventslist;
        //коллекция после применения фильтра
        ObservableCollection<Mouseevents> fulleventslist;
        //вспомогательные переменные
        int mousecheckbox = -1;
        int rigthbtncheckbox = -1;
        int leftbtncheckbox = -1;
        DateTime prev;
        DateTime post;
        //счётчик количества событий
        int eventscount = 0;
        //количество предложенных отправок
        int sendcount = 1;
        //диалоговое окно подтверждения отправки пользователем
        string messageBoxText = "Отправить количество записей?";
        string caption = "Подтверждение отправки";
        MessageBoxButton button = MessageBoxButton.YesNo;
        MessageBoxImage icon = MessageBoxImage.Question;
        public Main(string username)
        {
            InitializeComponent();
            this.username = username;
            Counter.Text= eventscount.ToString();
            eventslist = new ObservableCollection<Mouseevents>();
            fulleventslist = new ObservableCollection<Mouseevents>();
            Grid.ItemsSource = eventslist;
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            double curx = e.GetPosition(null).X;
            double cury = e.GetPosition(null).Y;
            if (recordcondition)
            {
                //движение указателя мыши внутри окна приложения
                if ((Math.Abs(curx - xprev) > 10)|| (Math.Abs(cury - yprev) > 10))
                {
                    xprev = curx;
                    yprev = cury;
                    Mouseevents moveevent = new Mouseevents(DateTime.Now, "mousemove",curx,cury);
                    fulleventslist.Add(moveevent);
                    eventslist.Add(moveevent);
                    SendEvent(moveevent);
                }
             
            }
        }
        //нажатие левой клавиши мыши
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (recordcondition)
            {
                double curx = e.GetPosition(null).X;
                double cury = e.GetPosition(null).Y;
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    Mouseevents leftbtnpress = new Mouseevents(DateTime.Now, "leftbutton", curx, cury);
                    fulleventslist.Add((leftbtnpress));
                    eventslist.Add(leftbtnpress);
                    SendEvent(leftbtnpress);
                }
            }
              
        }
        //нажатие правой клавиши мыши
        private void Window_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (recordcondition)
            {
                double curx = e.GetPosition(null).X;
                double cury = e.GetPosition(null).Y;
                if (e.RightButton == MouseButtonState.Pressed)
                {
                    Mouseevents rightbtnpress = new Mouseevents(DateTime.Now, "rightbutton", curx, cury);
                    fulleventslist.Add(rightbtnpress);
                    eventslist.Add(rightbtnpress);
                    SendEvent(rightbtnpress);
                }
            }

        }
        //отправка событий на сервер
        private async void SendEvent(Mouseevents mouseevent)
        {
            eventscount++;
            Counter.Text = eventscount.ToString();
            if (eventscount > 50*sendcount)
            {
                CheckMessageBox(MessageBox.Show(messageBoxText, caption, button, icon));
                sendcount++;
            }
            var json = JsonConvert.SerializeObject(mouseevent);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var url = "http://localhost:5026/api/main/Sendevent";
            var response = await App.GetHttpClient().PostAsync(url, data);
        }
        //обработка событий в окне подтверждения
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
        //отправка количества записей на сервер
        private async void SendLetters()
        {
            LetterRequest req = new LetterRequest(eventscount, username);
            var json = JsonConvert.SerializeObject(req);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var url = "http://localhost:5026/api/main/Sendletter";
            var response = await App.GetHttpClient().PostAsync(url, data);
        }
        private async void Startbtn_Click(object sender, RoutedEventArgs e)
        {
            //запуск/cтоп
            if (!recordcondition)recordcondition = true;
            else recordcondition = false;
            //отправка состояния на сервер
            Conditions c=new Conditions();
            if (recordcondition) c.Condition="start";
            else c.Condition = "stop";
            var json = JsonConvert.SerializeObject(c);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var url = "http://localhost:5026/api/main/Recordcondition";
            var response = await App.GetHttpClient().PostAsync(url, data);
        }
        //фильтр по значению mousemove 
        private void MousemoveCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            if (!recordcondition)
            {
                var itemsToRemove = eventslist.Where(p => p.Type == "mousemove").ToList();
                foreach (var item in itemsToRemove) eventslist.Remove(item);
                if (mousecheckbox != 0) mousecheckbox += 2;
                else mousecheckbox = 1;
            }
        }
        private void MousemoveCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if ((!recordcondition)&&(mousecheckbox>0))
            {
                foreach (var item in fulleventslist.Where(i=>i.Type == "mousemove")) eventslist.Add(item);
                mousecheckbox = 0;
            }
        }

        //фильтр по значению leftbutton 
        private void LeftbtnCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            if (!recordcondition)
            {
                var itemsToRemove = eventslist.Where(p => p.Type == "leftbutton").ToList();
                foreach (var item in itemsToRemove) eventslist.Remove(item);
                if (leftbtncheckbox != 0) leftbtncheckbox += 2;
                else leftbtncheckbox = 1;
            }
        }
        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            var picker = sender as DatePicker;
            DateTime? dateprev = picker.SelectedDate;
            if (dateprev == null)
            {
                MessageBox.Show("Date not choosen");
            }
            else 
            {
                prev = (DateTime)dateprev;
            } 
        }
        private void DatePicker_SelectedDateChanged_1(object sender, SelectionChangedEventArgs e)
        {
            var picker = sender as DatePicker;
            DateTime? datepost = picker.SelectedDate;
            if (datepost == null)
            {
                MessageBox.Show("Date not choosen");
            }
            else 
            {
                post = (DateTime)datepost;
            } 
        }
       
        private void LeftbtnCheckBox_Checked_1(object sender, RoutedEventArgs e)
        {
            if ((!recordcondition) && (mousecheckbox > 0))
            {
                foreach (var item in fulleventslist.Where(i => i.Type == "leftbutton")) eventslist.Add(item);
                leftbtncheckbox = 0;
            }
        }
        //фильтр по значению rightbutton 
        private void RightbtnCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            if (!recordcondition)
            {
                var itemsToRemove = eventslist.Where(p => p.Type == "rightbutton").ToList();
                foreach (var item in itemsToRemove) eventslist.Remove(item);
                if (rigthbtncheckbox != 0) rigthbtncheckbox += 2;
                else rigthbtncheckbox = 1;
            }
        }
        private void RightbtnCheckBox_Checked_1(object sender, RoutedEventArgs e)
        { 
            if ((!recordcondition) && (mousecheckbox > 0))
            {
                foreach (var item in fulleventslist.Where(i => i.Type == "rightbutton")) eventslist.Add(item);
                rigthbtncheckbox = 0;
            }
        }
        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Filterbydate_Click(object sender, RoutedEventArgs e)
        {
            if (!recordcondition)
            { 
                var itemsToRemove = eventslist
                      .Where(p => p.dateTime > post || p.dateTime < prev)
                      .ToList();
                foreach (var item in itemsToRemove) eventslist.Remove(item);
            }
          
        }

        private void Cancelfilters_Click(object sender, RoutedEventArgs e)
        {
            eventslist.Clear();
            foreach (var item in fulleventslist) eventslist.Add(item);
        }
    }
}
