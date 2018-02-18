using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
using RunCodeAtTime;

namespace WindowsSleepOnTime
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        Action<string> action;
        Action actionWithoutParameters;

        public void ShowMessage(string msg)
        {
            MessageBox.Show(msg);
        }
        public void ShowMessageWithoutParam()
        {
            MessageBox.Show("Bez parametru");
        }

        [DllImport("Powrprof.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool SetSuspendState(bool hiberate, bool forceCritical, bool disableWakeEvent);

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            action = new Action<string>(ShowMessage);
            actionWithoutParameters = new Action(ShowMessageWithoutParam);
            ScheduleRunner sr = new ScheduleRunner();
            sr.runCodeAt(DateTime.Now.AddSeconds(2.0), actionWithoutParameters, null);
            sr.runCodeAt<string>(DateTime.Now.AddSeconds(2.0), action, "Testowa wiadomosc", null);
            //SetSuspendState(false, true, true);
        }
    }
}
