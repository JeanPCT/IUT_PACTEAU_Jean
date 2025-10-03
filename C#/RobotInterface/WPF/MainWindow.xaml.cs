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

namespace WPF
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
         
            string message = textBoxEmission.Text;
            if (!string.IsNullOrWhiteSpace(message))
            {
                RichTextBox.AppendText(Environment.NewLine + "Reçu : " + message);
                textBoxEmission.Clear();
            }

        }

        private void textBoxEmission_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) {
                string message = textBoxEmission.Text;
                if (!string.IsNullOrWhiteSpace(message))
                {
                    RichTextBox.AppendText(Environment.NewLine + "Reçu : " + message);
                    textBoxEmission.Clear();
                }

            }
        }
    }
}