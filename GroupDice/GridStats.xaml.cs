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
    /// Interaction logic for GridStats.xaml
    /// </summary>
    public partial class GridStats : Window
    {
        private StatSourceBinding STR = new StatSourceBinding();
        private StatSourceBinding DEX = new StatSourceBinding();
        private StatSourceBinding CON = new StatSourceBinding();
        private StatSourceBinding INT = new StatSourceBinding();
        private StatSourceBinding WIS = new StatSourceBinding();
        private StatSourceBinding CHA = new StatSourceBinding();

        MainWindow mainWindow;
        public GridStats(MainWindow Parent)
        {
            this.mainWindow = Parent;
            InitializeComponent();
        }

        private void Roll_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            if (b.Content.GetType() == typeof(string) && (string)b.Content == "Roll")
            {
                b.Content = ""+ mainWindow.getRoll();
                b.IsEnabled = false;
            } else
            {
                if (b.Name.Contains("str") && STR.Destination == strValue && STR.Source == null)
                {
                    STR.Source = b;
                    strValue.Text = (string)b.Content;
                    b.IsEnabled = false;

                    str_int.IsEnabled = false;
                    str_wis.IsEnabled = false;
                    str_cha.IsEnabled = false;
                }
                if (b.Name.Contains("dex") && DEX.Destination == dexValue && DEX.Source == null)
                {
                    DEX.Source = b;
                    dexValue.Text = (string)b.Content;
                    b.IsEnabled = false;

                    dex_cha.IsEnabled = false;
                    dex_int.IsEnabled = false;
                    dex_wis.IsEnabled = false;
                }
                if (b.Name.Contains("con") && CON.Destination == conValue && CON.Source == null)
                {
                    CON.Source = b;
                    conValue.Text = (string)b.Content;
                    b.IsEnabled = false;

                    con_int.IsEnabled = false;
                    con_wis.IsEnabled = false;
                    con_cha.IsEnabled = false;
                }
                if (b.Name.Contains("int") && INT.Destination == intValue && INT.Source == null)
                {
                    INT.Source = b;
                    intValue.Text = (string)b.Content;
                    b.IsEnabled = false;

                    str_int.IsEnabled = false;
                    dex_int.IsEnabled = false;
                    con_int.IsEnabled = false;
                }
                if (b.Name.Contains("wis") && WIS.Destination == wisValue && WIS.Source == null)
                {
                    WIS.Source = b;
                    wisValue.Text = (string)b.Content;
                    b.IsEnabled = false;

                    str_wis.IsEnabled = false;
                    dex_wis.IsEnabled = false;
                    con_wis.IsEnabled = false;
                }
                if (b.Name.Contains("cha") && CHA.Destination == chaValue && CHA.Source == null)
                {
                    CHA.Source = b;
                    chaValue.Text = (string)b.Content;
                    b.IsEnabled = false;

                    str_cha.IsEnabled = false;
                    dex_cha.IsEnabled = false;
                    con_cha.IsEnabled = false;
                }
            }
        }

        private void strValue_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SortShit();
            if (STR.Destination == null && STR.Source == null)
            {
                STR.Destination = strValue;
                if (INT.Source != str_int)
                {
                    str_int.IsEnabled = true;
                }
                if (WIS.Source != str_wis)
                {
                    str_wis.IsEnabled = true;
                }
                if (CHA.Source != str_cha)
                {
                    str_cha.IsEnabled = true;
                }
            }
        }

        private void dexValue_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SortShit();
            if (DEX.Destination == null && DEX.Source == null)
            {
                DEX.Destination = dexValue;
                if (INT.Source != dex_int)
                {
                    dex_int.IsEnabled = true;
                }
                if (WIS.Source != dex_wis)
                {
                    dex_wis.IsEnabled = true;
                }
                if (CHA.Source != dex_cha)
                {
                    dex_cha.IsEnabled = true;
                }
            }
        }

        private void conValue_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SortShit();
            if (CON.Destination == null && CON.Source == null)
            {
                CON.Destination = conValue;
                if (INT.Source != con_int)
                {
                    con_int.IsEnabled = true;
                }
                if (WIS.Source != con_wis)
                {
                    con_wis.IsEnabled = true;
                }
                if (CHA.Source != con_cha)
                {
                    con_cha.IsEnabled = true;
                }
            }
        }

        private void intValue_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SortShit();
            if (INT.Destination == null && INT.Source == null)
            {
                INT.Destination = intValue;
                if (STR.Source != str_int)
                {
                    str_int.IsEnabled = true;
                }
                if (DEX.Source != dex_int)
                {
                    dex_int.IsEnabled = true;
                }
                if (CON.Source != con_int)
                {
                    con_int.IsEnabled = true;
                }
            }
        }

        private void wisValue_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SortShit();
            if (WIS.Destination == null && WIS.Source == null)
            {
                WIS.Destination = wisValue;
                if (STR.Source != str_wis)
                {
                    str_wis.IsEnabled = true;
                }
                if (DEX.Source != dex_wis)
                {
                    dex_wis.IsEnabled = true;
                }
                if (CON.Source != con_wis)
                {
                    con_wis.IsEnabled = true;
                }
            }
        }

        private void chaValue_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SortShit();
            if (CHA.Destination == null && CHA.Source == null)
            {
                CHA.Destination = chaValue;
                if (STR.Source != str_cha)
                {
                    str_cha.IsEnabled = true;
                }
                if (DEX.Source != dex_cha)
                {
                    dex_cha.IsEnabled = true;
                }
                if (CON.Source != con_cha)
                {
                    con_cha.IsEnabled = true;
                }
            }
        }

        private void SortShit()
        {
            str_int.IsEnabled = false;
            str_wis.IsEnabled = false;
            str_cha.IsEnabled = false;
            dex_int.IsEnabled = false;
            dex_wis.IsEnabled = false;
            dex_cha.IsEnabled = false;
            con_int.IsEnabled = false;
            con_wis.IsEnabled = false;
            con_cha.IsEnabled = false;

            if (strValue.Text == "0") STR.Destination = null;
            if (dexValue.Text == "0") DEX.Destination = null;
            if (conValue.Text == "0") CON.Destination = null;
            if (intValue.Text == "0") INT.Destination = null;
            if (wisValue.Text == "0") WIS.Destination = null;
            if (chaValue.Text == "0") CHA.Destination = null;
        }
    }
}
