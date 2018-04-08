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
using System.Windows.Shapes;

namespace GroupDice
{
    /// <summary>
    /// Interaction logic for InputDialog.xaml
    /// </summary>
    public partial class InputDialog : Window
    {

        public string MessageResult { get; set; } = "No Response";

        public InputDialog(String Message)
        {
            
            InitializeComponent();
            this.MessageLabel.Content = Message;
            InputBox.Focus();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            MessageResult = InputBox.Text;
            this.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            MessageResult = "Cancelled";
            this.Close();
        }

        private void InputBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                MessageResult = InputBox.Text;
                this.Close();
            }
        }
    }
}
