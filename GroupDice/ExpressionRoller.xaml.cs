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
using System.Threading;

namespace GroupDice
{
    /// <summary>
    /// Interaction logic for ExpressionRoller.xaml
    /// </summary>
    public partial class ExpressionRoller : Window
    {
        MainWindow mainWindow;
        public ExpressionRoller(MainWindow Parent)
        {
            this.mainWindow = Parent;
            InitializeComponent();
            expressionInput.Focus();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Roll();
        }

        private void Roll()
        {
            string expr = expressionInput.Text.Trim();
            if (expr.Contains("Enter")) return;

            string result = "";
            if (String.Equals(expr, "stats", StringComparison.InvariantCultureIgnoreCase))
            {
                expr = "";
                List<Stat> stats = mainWindow.RollStats();
                StringBuilder sb = new StringBuilder();
                foreach (Stat stat in stats)
                {
                    sb.Append(stat.Name);
                    sb.Append(": ");
                    sb.Append(stat.Value);
                    sb.Append("\n");
                }
                result = sb.ToString();
            }
            else
            {
                result = "" + mainWindow.RollDice(expr);
                expr += ": ";
            }
            resultsBlock.Text = "\n" + expr + result + "\n-------\n" + resultsBlock.Text;
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            expressionInput.Text = "Enter Expression";
            resultsBlock.Text = "";
        }

        private void Stats_Button_Click(object sender, RoutedEventArgs e)
        {
            expressionInput.Text = "stats";
            Roll();
        }

        private void Percent_Button_Click(object sender, RoutedEventArgs e)
        {
            expressionInput.Text = "%";
            Roll();
        }

        private void Mod_D20_Click(object sender, RoutedEventArgs e)
        {
            InputDialog input = new InputDialog("+ what?");
            input.Owner = this;
            input.ShowDialog();
            string mod = input.MessageResult;
            input = null;
            expressionInput.Text = "1d20+" + mod;
            Roll();
        }

        private void expressionInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Roll();
            }
        }
    }
}
