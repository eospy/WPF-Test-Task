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
    //это представление
    public partial class Main : Window
    {
        //имя пользователя
        public string username = "";
        //состояние нажатия кнопки запуск/стоп
        bool recordcondition = false;
        //предыдущие координты указателя мыши
        double xprev = 0;
        double yprev = 0;
        //список событий мыши для отображения в таблице
        ObservableCollection<Mouseevent> eventslist;
        //коллекция после применения фильтра
        ObservableCollection<Mouseevent> fulleventslist;
        //вспомогательные переменные
        int mousecheckbox = -1;
        int rigthbtncheckbox = -1;
        int leftbtncheckbox = -1;
      
        public Main(string username)
        {
            var mainviewmodel = new MainViewModel();
            DataContext = mainviewmodel;
            InitializeComponent();
        }
        //не правильно
        /*
        public void Window_MouseMove(object sender, MouseEventArgs e)
        {
            if (recordcondition)
            {
                double curx = e.GetPosition(null).X;
                double cury = e.GetPosition(null).Y;
                //движение указателя мыши внутри окна приложения
                if ((Math.Abs(curx - xprev) > 10) || (Math.Abs(cury - yprev) > 10))
                {
                    xprev = curx;
                    yprev = cury;
                    Mouseevent moveevent = new Mouseevent(DateTime.Now, "mousemove", curx, cury);
                    fulleventslist.Add(moveevent);
                    eventslist.Add(moveevent);
                    SendEvent(moveevent);
                }

            }
        }
        */
        //чекбокс
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
            if ((!recordcondition) && (mousecheckbox > 0))
            {
                foreach (var item in fulleventslist.Where(i => i.Type == "mousemove")) eventslist.Add(item);
                mousecheckbox = 0;
            }
        }
        //чекбокс
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
        private void LeftbtnCheckBox_Checked_1(object sender, RoutedEventArgs e)
        {
            if ((!recordcondition) && (mousecheckbox > 0))
            {
                foreach (var item in fulleventslist.Where(i => i.Type == "leftbutton")) eventslist.Add(item);
                leftbtncheckbox = 0;
            }
        }
        //чекбокс
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
    

   
    }
}
