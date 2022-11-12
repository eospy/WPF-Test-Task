using AppLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Clientapp.ViewModels
{
    public class MainViewModel :ViewModelBase
    {
        public event PropertyChangedEventHandler PropertyChanged;
        ObservableCollection<Mouseevent> eventslist;
        ObservableCollection<Mouseevent> fulleventslist;

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
