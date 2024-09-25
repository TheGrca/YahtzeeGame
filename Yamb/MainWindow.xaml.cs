using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Yamb
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    //TODO : Make the logic for the 1-6 dices, then another function for the MAX and MIN, then another function for the last part of the game SEPERATELY.
    //TODO : Make the logic of the order in which the result will be stored. 
           // Add names to every column and row, and columns will have different ways for the storage 
    public partial class MainWindow : Window
    {
        private Random random = new Random();
        private Border[] diceBorders;
        private int rollCount = 0;
        private const int maxRolls = 3;
        private int totalScore = 0; //TotalScore for the Game
        private Dictionary<int, int> scoreDictionary = new Dictionary<int, int> // Dictionary for storing dices (Key is the dice number)
            {
                { 1, 0 },
                { 2, 0 },
                { 3, 0 },
                { 4, 0 },
                { 5, 0 },
                { 6, 0 }
            }; //DICE SIDE AND HOW MANY DO WE HAVE
        private Dictionary<int, int> diceValue = new Dictionary<int, int>
          {
                { 0, 0 },
                { 1, 0 },
                { 2, 0 },
                { 3, 0 },
                { 4, 0 },
                { 5, 0 }
            }; //DICE INDEX AND VALUE OF IT
        private Dictionary<int, bool> isDiceClicked = new Dictionary<int, bool>
        {
                { 0, false },
                { 1, false },
                { 2, false },
                { 3, false },
                { 4, false },
                { 5, false }
        };
        private int firstColumnCounter = 1;
        private int secondColumnCounter = 15;

        public MainWindow()
        {
            InitializeComponent();
            diceBorders = new Border[] { Border1, Border2, Border3, Border4, Border5, Border6 };
        }

        private void RollDice_Click(object sender, RoutedEventArgs e)
        {
            Border1.IsEnabled = true;
            Border2.IsEnabled = true;
            Border3.IsEnabled = true;
            Border4.IsEnabled = true;
            Border5.IsEnabled = true;
            Border6.IsEnabled = true;
            Image[] diceImages = { Dice1, Dice2, Dice3, Dice4, Dice5, Dice6 };
            for(int i = 1; i <= 6; i++)
            {
                    scoreDictionary[i] = 0;
            }
            for(int i = 0; i<6; i++)
            {
                if (isDiceClicked[i])
                {
                    scoreDictionary[diceValue[i]] += 1;
                }
            }


            for (int i = 0; i < 6; i++)
            {
                int randomNumber = random.Next(1, 7);
                if (diceBorders[i].BorderBrush == Brushes.Transparent)
                {
                    string imagePath = $"pack://application:,,,/Images/{randomNumber}.png";
                    diceImages[i].Source = new BitmapImage(new Uri(imagePath, UriKind.Absolute));
                    scoreDictionary[randomNumber] += 1;
                    diceValue[i] = randomNumber;
                }
            }


            rollCount++;

            if(rollCount >= maxRolls)
            {
                RollDiceButton.IsEnabled = false;
                Border1.BorderBrush = Brushes.Gold;
                Border1.BorderThickness = new Thickness(2);
                Border1.IsEnabled = false;
                Border2.BorderBrush = Brushes.Gold;
                Border2.BorderThickness = new Thickness(2);
                Border2.IsEnabled = false;
                Border3.BorderBrush = Brushes.Gold;
                Border3.BorderThickness = new Thickness(2);
                Border3.IsEnabled = false;
                Border4.BorderBrush = Brushes.Gold;
                Border4.BorderThickness = new Thickness(2);
                Border4.IsEnabled = false;
                Border5.BorderBrush = Brushes.Gold;
                Border5.BorderThickness = new Thickness(2);
                Border5.IsEnabled = false;
                Border6.BorderBrush = Brushes.Gold;
                Border6.BorderThickness = new Thickness(2);
                Border6.IsEnabled = false;

            }
        }


        //Function for clicking the dice to save the result
        private void Dice_Click(object sender, MouseButtonEventArgs e)
        {
            Border clickedBorder = sender as Border;
            int borderIndex = Array.IndexOf(diceBorders, clickedBorder);

            if (borderIndex >= 0)
            {
                if (clickedBorder.BorderBrush == Brushes.Transparent)
                {
                    clickedBorder.BorderBrush = Brushes.Blue;
                    clickedBorder.BorderThickness = new Thickness(3);
                    isDiceClicked[borderIndex] = true;
                }
                else
                {
                    clickedBorder.BorderBrush = Brushes.Transparent;
                    clickedBorder.BorderThickness = new Thickness(0);
                    isDiceClicked[borderIndex] = false;
                }
            }
        }


        #region FirstColumn
        private void FirstColumnClick(object sender, RoutedEventArgs e)
        {

            TextBlock clickedTextBlock = sender as TextBlock;
            if (rollCount > 0 && firstColumnCounter < 7)
            {
                if (clickedTextBlock != null && clickedTextBlock.IsEnabled)
                {
                    if (scoreDictionary[firstColumnCounter] > 5) // If a user has 6 of the same
                    {
                        scoreDictionary[firstColumnCounter] = 5;
                    }
                    int score = scoreDictionary[firstColumnCounter] * firstColumnCounter;
                    firstColumnCounter++;
                    clickedTextBlock.Text = score.ToString();
                    clickedTextBlock.IsEnabled = false;
                    var parent = VisualTreeHelper.GetParent(clickedTextBlock) as Panel;

                    if (parent != null)
                    {
                        int clickedIndex = parent.Children.IndexOf(clickedTextBlock);

                        if (clickedIndex >= 0 && clickedIndex < parent.Children.Count - 1)
                        {
                            var nextElement = parent.Children[clickedIndex + 1] as TextBlock;

                            if (nextElement != null)
                            {
                                nextElement.IsEnabled = true;
                            }
                        }
                    }
                }
            }

            if (firstColumnCounter == 7)
            {
                int sum = 0;
                for (int i = 1; i < 7; i++)
                {
                    string textBlockName = "Row" + i;
                    TextBlock textBlock = (TextBlock)this.FindName(textBlockName);
                    string text = textBlock.Text;
                    sum += int.Parse(text);
                }

                if (sum >= 60)
                    sum += 30;

                Row7.Text = sum.ToString();
                rollCount = 0;
                Row8.IsEnabled = true;
                firstColumnCounter = 8;
            }

            if (rollCount > 0 && firstColumnCounter == 8)
            {
                int maximum = 0;
                List<int> numbers = new List<int>();
                for (int i = 0; i < 6; i++)
                {
                    numbers.Add(diceValue[i]);
                }

                int minValue = numbers.Min();
                numbers.Remove(minValue);

                maximum = numbers.Sum();
                Row8.Text = maximum.ToString();
                Row8.IsEnabled = false;
                Row9.IsEnabled = true;
                firstColumnCounter = 9;
                ResetDices();
            }

            if(rollCount > 0 && firstColumnCounter == 9) {
                List<int> numbers = new List<int>();
                for(int i = 0; i < 6; i++)
                {
                    numbers.Add(diceValue[i]);
                }
                int maxValue = numbers.Max();
                numbers.Remove(maxValue);

                Row9.Text = numbers.Sum().ToString();
                Row9.IsEnabled = false;
                Row10.IsEnabled = true;
                firstColumnCounter = 10;
            }

            if (firstColumnCounter == 10)
            {
                int ones = int.Parse(Row1.Text);
                int maximum = int.Parse(Row8.Text);
                int minimum = int.Parse(Row9.Text);

                Row10.Text = (ones*(maximum-minimum)).ToString();
                rollCount = 0;
                Row11.IsEnabled = true;
                firstColumnCounter = 11;
            }

            if(rollCount>0 && firstColumnCounter == 11) //KENTA
            {
                if(scoreDictionary[2] > 0 && scoreDictionary[3] > 0 && scoreDictionary[4] > 0 &&
                    scoreDictionary[5] > 0 && scoreDictionary[6] > 0)
                {
                    Row11.Text = "50";
                }
                else if (scoreDictionary[1] > 0 && scoreDictionary[2] > 0 && scoreDictionary[3] > 0 &&
                        scoreDictionary[4] > 0 && scoreDictionary[5] > 0)
                {
                    Row11.Text = "40";
                }
                else
                {
                    Row11.Text = "0";
                }
                Row11.IsEnabled = false;
                Row12.IsEnabled = true;
                rollCount = 0;
                firstColumnCounter = 12;
            }

            if(rollCount > 0 && firstColumnCounter == 12) //TRILING
            {
                for(int i = 6; i>0; i--)
                {
                    if (scoreDictionary[i] >= 3)
                    {
                        if (scoreDictionary[i] > 3)
                        {
                            scoreDictionary[i] = 3;
                        }
                        Row12.Text = ((scoreDictionary[i]*i) + 20).ToString();
                        break;
                    }
                    else
                    {
                        Row12.Text = "0";
                    }
                }
                Row12.IsEnabled = false;
                Row13.IsEnabled = true;
                rollCount = 0;
                firstColumnCounter = 13;
            }
            if(rollCount > 0 && firstColumnCounter == 13) //FUL
            {
                for(int i = 6; i>0; i--)
                {
                    if (scoreDictionary[i] >= 3)
                    {
                        for(int j = 6; j>0; j--)
                        {
                            if(j == i)
                            {
                                continue;
                            }
                            if (scoreDictionary[j] >= 2)
                            {
                                if (scoreDictionary[i] > 3)
                                {
                                    scoreDictionary[i] = 3;
                                }
                                if (scoreDictionary[j] > 2)
                                {
                                    scoreDictionary[j] = 2;
                                }
                                int ful = (scoreDictionary[i]*i + scoreDictionary[j]*j) + 30 ;
                                Row13.Text = ful.ToString();
                                break;
                            }
                        }
                    }
                    else
                    {
                        Row13.Text = "0";
                    }
                }
                Row13.IsEnabled = false;
                Row14.IsEnabled = true;
                rollCount = 0;
                firstColumnCounter = 14;
            }

            if(rollCount > 0 && firstColumnCounter == 14) //Poker
            {
                for(int i = 6; i>0; i--)
                {
                    if (scoreDictionary[i] >= 4)
                    {
                        if (scoreDictionary[i] > 4)
                        {
                            scoreDictionary[i] = 4;
                        }
                        Row14.Text = ((scoreDictionary[i] * i)+40).ToString();
                        break;
                    }
                    else
                    {
                        Row14.Text = "0";
                    }
                }
                Row14.IsEnabled = false;
                Row15.IsEnabled = true;
                rollCount = 0;
                firstColumnCounter = 15;
            }

            if (rollCount > 0 && firstColumnCounter == 15) //JAMB
            {
                for (int i = 6; i > 0; i--)
                {
                    if (scoreDictionary[i] >= 5)
                    {
                        if (scoreDictionary[i] > 5)
                        {
                            scoreDictionary[i] = 5;
                        }
                        Row15.Text = ((scoreDictionary[i] * i)+50).ToString();
                        break;
                    }
                    else
                    {
                        Row15.Text = "0";
                    }
                }
                Row15.IsEnabled = false;
                rollCount = 0;
                firstColumnCounter = 16;
            }

            if (firstColumnCounter == 16)
            {
                int sum = 0;
                for (int i = 11; i < 16; i++)
                {
                    string textBlockName = "Row" + i;
                    TextBlock textBlock = (TextBlock)this.FindName(textBlockName);
                    string text = textBlock.Text;
                    sum += int.Parse(text);
                }

                Row16.Text = sum.ToString();
            }
            ResetDices();
        }
        #endregion

        private void SecondColumnClick(object sender, RoutedEventArgs e)
        {
            if (rollCount > 0 && secondColumnCounter == 15) //JAMB
            {
                for (int i = 6; i > 0; i--)
                {
                    if (scoreDictionary[i] >= 5)
                    {
                        if (scoreDictionary[i] > 5)
                        {
                            scoreDictionary[i] = 5;
                        }
                        Roww15.Text = ((scoreDictionary[i] * i) + 50).ToString();
                        break;
                    }
                    else
                    {
                        Roww15.Text = "0";
                    }
                }
                Roww15.IsEnabled = false;
                Roww14.IsEnabled = true;
                rollCount = 0;
                secondColumnCounter = 14;
            }

            if (rollCount > 0 && secondColumnCounter == 14) //Poker
            {
                for (int i = 6; i > 0; i--)
                {
                    if (scoreDictionary[i] >= 4)
                    {
                        if (scoreDictionary[i] > 4)
                        {
                            scoreDictionary[i] = 4;
                        }
                        Roww14.Text = ((scoreDictionary[i] * i) + 40).ToString();
                        break;
                    }
                    else
                    {
                        Roww14.Text = "0";
                    }
                }
                Roww14.IsEnabled = false;
                Roww13.IsEnabled = true;
                rollCount = 0;
                secondColumnCounter = 13;
            }

            if (rollCount > 0 && secondColumnCounter == 13) //FUL
            {
                for (int i = 6; i > 0; i--)
                {
                    if (scoreDictionary[i] >= 3)
                    {
                        for (int j = 6; j > 0; j--)
                        {
                            if (j == i)
                            {
                                continue;
                            }
                            if (scoreDictionary[j] >= 2)
                            {
                                if (scoreDictionary[i] > 3)
                                {
                                    scoreDictionary[i] = 3;
                                }
                                if (scoreDictionary[j] > 2)
                                {
                                    scoreDictionary[j] = 2;
                                }
                                int ful = (scoreDictionary[i] * i + scoreDictionary[j] * j) + 30;
                                Roww13.Text = ful.ToString();
                                break;
                            }
                        }
                    }
                    else
                    {
                        Roww13.Text = "0";
                    }
                }
                Roww13.IsEnabled = false;
                Roww12.IsEnabled = true;
                rollCount = 0;
                secondColumnCounter = 12;
            }

            if (rollCount > 0 && secondColumnCounter == 12) //TRILING
            {
                for (int i = 6; i > 0; i--)
                {
                    if (scoreDictionary[i] >= 3)
                    {
                        if (scoreDictionary[i] > 3)
                        {
                            scoreDictionary[i] = 3;
                        }
                        Roww12.Text = ((scoreDictionary[i] * i) + 20).ToString();
                        break;
                    }
                    else
                    {
                        Roww12.Text = "0";
                    }
                }
                Roww12.IsEnabled = false;
                Roww11.IsEnabled = true;
                rollCount = 0;
                secondColumnCounter = 11;
            }

            if (rollCount > 0 && secondColumnCounter == 11) //KENTA
            {
                if (scoreDictionary[2] > 0 && scoreDictionary[3] > 0 && scoreDictionary[4] > 0 &&
                    scoreDictionary[5] > 0 && scoreDictionary[6] > 0)
                {
                    Roww11.Text = "50";
                }
                else if (scoreDictionary[1] > 0 && scoreDictionary[2] > 0 && scoreDictionary[3] > 0 &&
                scoreDictionary[4] > 0 && scoreDictionary[5] > 0)
                {
                    Roww11.Text = "40";
                }
                else
                {
                    Roww11.Text = "0";
                }
                Roww11.IsEnabled = false;
                Roww16.IsEnabled = true;
                rollCount = 0;
                secondColumnCounter = 16;
            }


            if (secondColumnCounter == 16)
            {
                int sum = 0;
                for (int i = 11; i < 16; i++)
                {
                    string textBlockName = "Roww" + i;
                    TextBlock textBlock = (TextBlock)this.FindName(textBlockName);
                    string text = textBlock.Text;
                    sum += int.Parse(text);
                }

                Roww16.Text = sum.ToString();
                Roww16.IsEnabled = false;
                Roww9.IsEnabled = true;
                rollCount = 0;
                secondColumnCounter = 9;
            }


            ResetDices();
        }

        private void ResetDices()
        {
            //RESET EVERYTHING
            for (int i = 0; i < 6; i++)
            {
                diceValue[i] = 0;
                isDiceClicked[i] = false;

            }
            Border1.BorderBrush = Brushes.Transparent;
            Border1.BorderThickness = new Thickness(0);
            Border2.BorderBrush = Brushes.Transparent;
            Border2.BorderThickness = new Thickness(0);
            Border3.BorderBrush = Brushes.Transparent;
            Border3.BorderThickness = new Thickness(0);
            Border4.BorderBrush = Brushes.Transparent;
            Border4.BorderThickness = new Thickness(0);
            Border5.BorderBrush = Brushes.Transparent;
            Border5.BorderThickness = new Thickness(0);
            Border6.BorderBrush = Brushes.Transparent;
            Border6.BorderThickness = new Thickness(0);
            rollCount = 0;
            RollDiceButton.IsEnabled = true;

        }
    }




}
