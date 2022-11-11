using AppLibrary;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Clientapp
{
    //это модель представления
    /*
    public class AppViewModel :INotifyPropertyChanged
    {

        //список событий мыши для отображения в таблице
        ObservableCollection<Mouseevents> eventslist;
        public AppViewModel()
        {
            eventslist = new ObservableCollection<Mouseevents>();
            //fulleventslist = new ObservableCollection<Mouseevents>();
        }


        private RelayCommand regCommand;
        public RelayCommand RegCommand
        {
            get
            {
                return regCommand ??
                  (regCommand = new RelayCommand(obj =>
                  {
                  }));
            }
        }
        public ObservableCollection<Mouseevents> Events => eventslist;
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
    */
}
