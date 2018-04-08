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

namespace GroupDice
{
    enum RollMode
    {
        FourDSixDropLowest, Random, ThreeDSixStraight, FourDSixFlat 
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Random r = new Random();
        private RollMode rollMode = RollMode.FourDSixDropLowest;
        private List<Stat> baseStats = new List<Stat>(6);
        public MainWindow()
        {
            InitializeComponent();
            baseStats.Add(new Stat("STR", 0));
            baseStats.Add(new Stat("DEX", 0));
            baseStats.Add(new Stat("CON", 0));
            baseStats.Add(new Stat("INT", 0));
            baseStats.Add(new Stat("WIS", 0));
            baseStats.Add(new Stat("CHA", 0));
            group1Grid.ItemsSource = baseStats;
            group2Grid.ItemsSource = baseStats;
            group3Grid.ItemsSource = baseStats;
            group4Grid.ItemsSource = baseStats;
            group5Grid.ItemsSource = baseStats;
            group6Grid.ItemsSource = baseStats;
            group7Grid.ItemsSource = baseStats;
            group8Grid.ItemsSource = baseStats;
        }

        private void Button_Click(object sendingObject, RoutedEventArgs e)
        {


            Button sender = (Button)sendingObject;
            sender.IsEnabled = false;
            List<Stat> stats = RollStats();

            if (sender.Name.Contains("group1"))
            {
                group1Grid.ItemsSource = stats;
            }
            else if ((sender.Name.Contains("group2")))
            {
                group2Grid.ItemsSource = stats;
            }
            else if ((sender.Name.Contains("group3")))
            {
                group3Grid.ItemsSource = stats;
            }
            else if ((sender.Name.Contains("group4")))
            {
                group4Grid.ItemsSource = stats;
            }
            else if ((sender.Name.Contains("group5")))
            {
                group5Grid.ItemsSource = stats;
            }
            else if ((sender.Name.Contains("group6")))
            {
                group6Grid.ItemsSource = stats;
            }
            else if ((sender.Name.Contains("group7")))
            {
                group7Grid.ItemsSource = stats;
            }
            else if ((sender.Name.Contains("group8")))
            {
                group8Grid.ItemsSource = stats;
            }
            
        }

        private List<Stat> get3d6Stats()
        {
            List<Stat> stats = new List<Stat>(6);
            stats.Add(new Stat("STR", get3d6()));
            stats.Add(new Stat("DEX", get3d6()));
            stats.Add(new Stat("CON", get3d6()));
            stats.Add(new Stat("INT", get3d6()));
            stats.Add(new Stat("WIS", get3d6()));
            stats.Add(new Stat("CHA", get3d6()));
            return stats;
        }

        private List<Stat> getRandomStats()
        {
            List<Stat> stats = new List<Stat>(6);
            stats.Add(new Stat("STR", r.Next(7, 20)));
            stats.Add(new Stat("DEX", r.Next(7, 20)));
            stats.Add(new Stat("CON", r.Next(7, 20)));
            stats.Add(new Stat("INT", r.Next(7, 20)));
            stats.Add(new Stat("WIS", r.Next(7, 20)));
            stats.Add(new Stat("CHA", r.Next(7, 20)));

            foreach (Stat stat in stats)
            {
                if (stat.Value>18)
                {
                    stat.Value = r.Next(16, 18);
                }
            }
            return stats;
        }

        private List<Stat> get4d6DLStats()
        {
            List<Stat> stats = new List<Stat>(6);
            stats.Add(new Stat("STR", get4d6dropLowest()));
            stats.Add(new Stat("DEX", get4d6dropLowest()));
            stats.Add(new Stat("CON", get4d6dropLowest()));
            stats.Add(new Stat("INT", get4d6dropLowest()));
            stats.Add(new Stat("WIS", get4d6dropLowest()));
            stats.Add(new Stat("CHA", get4d6dropLowest()));

            return stats;
        }

        private List<Stat> get4d6FlatStats()
        {
            List<Stat> stats = new List<Stat>(6);
            stats.Add(new Stat("STR", get4D6Flat()));
            stats.Add(new Stat("DEX", get4D6Flat()));
            stats.Add(new Stat("CON", get4D6Flat()));
            stats.Add(new Stat("INT", get4D6Flat()));
            stats.Add(new Stat("WIS", get4D6Flat()));
            stats.Add(new Stat("CHA", get4D6Flat()));

            return stats;
        }
        private int get3d6()
        {
            int[] dice = new int[3];
            for (int i = 0; i < dice.Length; i++)
            {
                dice[i] = r.Next(1, 7);
            }

            int total = 0;
            for (int i = 0; i < dice.Length; i++)
            {
                total += dice[i];
            }
            return total;

        }
        private int get4d6dropLowest()
        {
            int[] dice = new int[4];

            //roll 4d6
            for (int i = 0; i < dice.Length; i++)
            {
                dice[i] = r.Next(1, 7);
            }

            //reroll ones
            for (int i = 0; i < dice.Length; i++)
            {
                if (dice[i] <= 1)
                {
                    dice[i] = r.Next(1, 7);
                }

            }

            //find lowest
            int min = 20;
            int minIdx = 0;
            for (int i = 0; i < dice.Length; i++)
            {
                if (dice[i] < min)
                {
                    min = dice[i];
                    minIdx = i;
                }
            }

            dice[minIdx] = 0;
            int total = 0;
            for (int i = 0; i < dice.Length; i++)
            {
                total += dice[i];
            }
            return total;
        }

        private int get4D6Flat()
        {
            int[] dice = new int[4];

            //roll 4d6
            for (int i = 0; i < dice.Length; i++)
            {
                dice[i] = r.Next(1, 6);
            }

            //find lowest
            int min = 20;
            int minIdx = 0;
            for (int i = 0; i < dice.Length; i++)
            {
                if (dice[i] < min)
                {
                    min = dice[i];
                    minIdx = i;
                }
            }

            dice[minIdx] = 0;
            int total = 0;
            for (int i = 0; i < dice.Length; i++)
            {
                total += dice[i];
            }
            return total;
        }

        private void MenuItem_Click(object senderObject, RoutedEventArgs e)
        {
            MenuItem sender = (MenuItem)senderObject;
            if (sender.Name == "closeItem")
            {
                System.Windows.Application.Current.Shutdown();
            } else if (sender.Name == "fourD6FlatItem")
            {
                rollMode = RollMode.FourDSixFlat;
                fourD6Item.IsChecked = false;
                threeD6Item.IsChecked = false;
                randItem.IsChecked = false;
            } else if (sender.Name == "fourD6Item")
            {
                rollMode = RollMode.FourDSixDropLowest;
                fourD6FlatItem.IsChecked = false;
                threeD6Item.IsChecked = false;
                randItem.IsChecked = false;
            } else if (sender.Name == "threeD6Item")
            {
                rollMode = RollMode.ThreeDSixStraight;
                fourD6FlatItem.IsChecked = false;
                fourD6Item.IsChecked = false;
                randItem.IsChecked = false;
            } else if (sender.Name == "randItem")
            {
                rollMode = RollMode.Random;
                fourD6FlatItem.IsChecked = false;
                fourD6Item.IsChecked = false;
                threeD6Item.IsChecked = false;
            } else if (sender.Name == "popItem")
            {
                ResetItesms();
            } else if (sender.Name == "gridItem")
            {
                GridStats gridStats = new GridStats(this);
                gridStats.Show();
            } else if (sender.Name == "rollerItem")
            {
                ExpressionRoller expressionRoller = new ExpressionRoller(this);
                expressionRoller.Show();
            }
        }

        private void ResetItesms()
        {
            group1Grid.ItemsSource = baseStats;
            group2Grid.ItemsSource = baseStats;
            group3Grid.ItemsSource = baseStats;
            group4Grid.ItemsSource = baseStats;
            group5Grid.ItemsSource = baseStats;
            group6Grid.ItemsSource = baseStats;
            group7Grid.ItemsSource = baseStats;
            group8Grid.ItemsSource = baseStats;

            group1Roll.IsEnabled = true;
            group2Roll.IsEnabled = true;
            group3Roll.IsEnabled = true;
            group4Roll.IsEnabled = true;
            group5Roll.IsEnabled = true;
            group6Roll.IsEnabled = true;
            group7Roll.IsEnabled = true;
            group8Roll.IsEnabled = true;
        }

        private void gridItem_Click(object sender, RoutedEventArgs e)
        {
            
        }

        public int getRollStatValue()
        {
            switch (rollMode)
            {
                case RollMode.FourDSixDropLowest:
                    return get4d6dropLowest();
                case RollMode.Random:
                    return getRandomRoll();
                case RollMode.ThreeDSixStraight:
                    return  get3d6();
                case RollMode.FourDSixFlat:
                    return  get4D6Flat();
                default:
                    return getRandomRoll();
            }
        }

        public List<Stat> RollStats()
        {
            switch (rollMode)
            {
                case RollMode.FourDSixDropLowest:
                    return get4d6DLStats();
                case RollMode.Random:
                    return getRandomStats();
                case RollMode.ThreeDSixStraight:
                    return get3d6Stats();
                case RollMode.FourDSixFlat:
                    return get4d6FlatStats();
                default:
                    return getRandomStats();
            }
        }

        public int RollDice(string expression)
        {
            if (!expression.Contains('d') && !expression.Contains('%'))
            {
                return 0;
            }
            try
            {
                string modifier = "";
                int numDice = 0;
                int numSides = 0;
                int mod = 0;
                if (expression.Contains("+"))
                {
                    modifier = "+";
                    string[] exprFirstParts = expression.Split('+');
                    Int32.TryParse(exprFirstParts[1], out mod);
                    string[] exprSecondParts = exprFirstParts[0].Split('d');
                    Int32.TryParse(exprSecondParts[0], out numDice);
                    Int32.TryParse(exprSecondParts[1], out numSides);
                }
                else if (expression.Contains("-"))
                {
                    modifier = "-";
                    string[] exprFirstParts = expression.Split('+');
                    Int32.TryParse(exprFirstParts[1], out mod);
                    string[] exprSecondParts = exprFirstParts[0].Split('d');
                    Int32.TryParse(exprSecondParts[0], out numDice);
                    Int32.TryParse(exprSecondParts[1], out numSides);
                }
                else if (expression == "%")
                {
                    return r.Next(1, 100);
                } else
                {
                    string[] exprSecondParts = expression.Split('d');
                    Int32.TryParse(exprSecondParts[0], out numDice);
                    Int32.TryParse(exprSecondParts[1], out numSides);
                }
                switch (modifier)
                {
                    case "":
                        return r.Next(1, numSides) * numDice;
                    case "+":
                        return r.Next(1, numSides) * numDice + mod;
                    case "-":
                        return r.Next(1, numSides) * numDice - mod;
                    default:
                        return 0;
                }
            } catch (Exception)
            {
                return 0;
            }
            
        }
        private int getRandomRoll()
        {
            int roll = r.Next(7, 20);
            if (roll > 18) roll = r.Next(16, 18);
            return roll;
        }
    }
}
