using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ExtendedSerialPort_NS;
using System.IO.Ports;
using System.Runtime.CompilerServices;
using System.Windows.Threading;

namespace WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ExtendedSerialPort serialPort1;
        DispatcherTimer timerAffichage;
        Robot robot = new Robot();

        public MainWindow()
        {
            /*serialPort1 = new ExtendedSerialPort("COM3", 115200, Parity.None, 8, StopBits.One);
            serialPort1.Open();
            InitializeComponent();
            */
            serialPort1 = new ExtendedSerialPort("COM3", 115200, Parity.None, 8, StopBits.One);
            serialPort1.DataReceived += SerialPort1_DataReceived;
            serialPort1.Open();

            timerAffichage = new DispatcherTimer();
            timerAffichage.Interval = new TimeSpan(0, 0, 0, 0, 100);
            timerAffichage.Tick += TimerAffichage_Tick;
            timerAffichage.Start();
        }

        private void TimerAffichage_Tick(object? sender, EventArgs e)
        {
            if (receivedText != "")
            {
                textBoxReception.Text += receivedText;
                receivedText = "";
            }
        }

        string receivedText;
        private void SerialPort1_DataReceived(object? sender, DataReceivedArgs e)
        {
            //throw new NotImplementedException();

            receivedText += Encoding.UTF8.GetString(e.Data, 0, e.Data.Length);

        }

        int backChange = 0;
        private void buttonEnvoyer_Click(object sender, RoutedEventArgs e)
        {
            /*if (backChange == 0)
            {
                buttonEnvoyer.Background = Brushes.Beige;
                backChange = 1;+
            }
            else if (backChange == 1)
            {
                buttonEnvoyer.Background = Brushes.RoyalBlue;
                backChange = 0;
            }*/
            SendMessage();
        }

        private void textBoxEmission_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) {
                SendMessage();
            }
        }
        private void SendMessage()
        {
            string message = textBoxEmission.Text;
            if (!string.IsNullOrWhiteSpace(message))
            {
                //RichTextBox.AppendText(Environment.NewLine + "Reçu : " + message);
                textBoxEmission.Clear();
            }
            serialPort1.Write(message);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            textBoxReception.Clear();
        }
    }
}