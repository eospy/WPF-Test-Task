using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Net.Http;

namespace Clientapp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static object _locker = new object();
        private static HttpClient _httpClient;
        public static HttpClient GetHttpClient()
        {
            if (_httpClient == null)
            {
                lock (_locker)
                {
                    if(_httpClient == null)
                        _httpClient = new HttpClient();
                }
            }
            return _httpClient;
        }
        public App()
        {
            Startup += new StartupEventHandler(App_Startup);
        }
        void App_Startup(object sender, StartupEventArgs e)
        {
            Auth.Instance.Show();
        }
    }
}
