using Bassini_SocketAsyncLib;
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
using System.Windows.Threading;

namespace Bassini_AsyncServer_5A
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AsyncSocketServer mServer;
        DispatcherTimer timer;
        public MainWindow()
        {
            InitializeComponent();
            mServer = new AsyncSocketServer();

          

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            mServer.InviaATutti("ciao");
        }

        private void btnAscolta_Click(object sender, RoutedEventArgs e)
        {
            mServer.InizioAscolto();
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 10);
            timer.Tick += Timer_Tick;
            timer.Start();
            
        }
        
        private void btnDisconetti_Click(object sender, RoutedEventArgs e)
        {
            mServer.ChiudiConnessione();
        }

        private void btnInvia_Click(object sender, RoutedEventArgs e)
        {
            mServer.InviaATutti(txtMessaggio.Text);
        }
    }
}
