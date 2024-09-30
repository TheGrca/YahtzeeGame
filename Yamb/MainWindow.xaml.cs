using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Media.Animation;
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
        private bool announceClicked = false;
        private string clickedFourthTextBlockName = "";
        private TextBlock fourthColumnTextBox = new TextBlock();
        //Variables for callout
        TextBlock TextBlock1 = new TextBlock();
        TextBlock TextBlock2 = new TextBlock();
        bool isEverythingExceptCallBool = false;
        bool isNumberSelected = false;

        public MainWindow()
        {
            InitializeComponent();
            diceBorders = new Border[] { Border1, Border2, Border3, Border4, Border5, Border6 };
        }

        private void RollDice_Click(object sender, RoutedEventArgs e)
        {
            

            if (rollCount == 1 && !announceClicked)
            {
                int isEverythingExceptCall = 0;
                
                for (int i = 1; i < 17; i++)
                {
                    string textblock1 = "Row" + i;
                    string textblock2 = "Roww" + i;
                    string textblock3 = "Rowww" + i;
                    TextBlock TB1 = (TextBlock)this.FindName(textblock1);
                    TextBlock TB2 = (TextBlock)this.FindName(textblock2);
                    TextBlock TB3 = (TextBlock)this.FindName(textblock3);
                    if(TB1.Text != "" & TB2.Text != "" & TB3.Text != "")
                    {
                        isEverythingExceptCall++;
                    }
                    if (isEverythingExceptCall == 16)
                    {
                        announceLabelChose.Visibility = Visibility.Visible;
                        isEverythingExceptCallBool = true;
                        break;
                    }
                }
            }
            if (!isEverythingExceptCallBool)
            {

                Border1.IsEnabled = true;
                Border2.IsEnabled = true;
                Border3.IsEnabled = true;
                Border4.IsEnabled = true;
                Border5.IsEnabled = true;
                Border6.IsEnabled = true;
                Image[] diceImages = { Dice1, Dice2, Dice3, Dice4, Dice5, Dice6 };
                for (int i = 1; i <= 6; i++)
                {
                    scoreDictionary[i] = 0;
                }
                for (int i = 0; i < 6; i++)
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

                if (rollCount >= maxRolls)
                {
                    RollDiceButton.IsEnabled = false;
                    Border1.BorderBrush = (Brush)new BrushConverter().ConvertFromString("#3FA2F6");
                    Border1.BorderThickness = new Thickness(3);
                    Border1.IsEnabled = false;
                    Border2.BorderBrush = (Brush)new BrushConverter().ConvertFromString("#3FA2F6");
                    Border2.BorderThickness = new Thickness(3);
                    Border2.IsEnabled = false;
                    Border3.BorderBrush = (Brush)new BrushConverter().ConvertFromString("#3FA2F6");
                    Border3.BorderThickness = new Thickness(3);
                    Border3.IsEnabled = false;
                    Border4.BorderBrush = (Brush)new BrushConverter().ConvertFromString("#3FA2F6");
                    Border4.BorderThickness = new Thickness(3);
                    Border4.IsEnabled = false;
                    Border5.BorderBrush = (Brush)new BrushConverter().ConvertFromString("#3FA2F6");
                    Border5.BorderThickness = new Thickness(3);
                    Border5.IsEnabled = false;
                    Border6.BorderBrush = (Brush)new BrushConverter().ConvertFromString("#3FA2F6");
                    Border6.BorderThickness = new Thickness(3);
                    Border6.IsEnabled = false;

                }

                if (rollCount == 1 && !(Rowwww1.Text != "" && Rowwww2.Text != "" && Rowwww3.Text != "" && Rowwww4.Text != "" && Rowwww5.Text != "" && Rowwww6.Text != "" && Rowwww7.Text != "" && Rowwww8.Text != "" && Rowwww9.Text != "" && Rowwww10.Text != "" && Rowwww11.Text != "" && Rowwww12.Text != "" && Rowwww13.Text != "" && Rowwww14.Text != "" && Rowwww15.Text != "" && Rowwww16.Text != ""))
                {
                    Announce.IsEnabled = true;
                    // Announce.Background = (Brush)new BrushConverter().ConvertFromString("#3FA2F6");
                    announceLabelSelect.Visibility = Visibility.Visible;
                }
                else
                {
                    Announce.IsEnabled = false;
                    //Announce.Background = (Brush)new BrushConverter().ConvertFromString("#3FA2F6");
                    announceLabelSelect.Visibility = Visibility.Hidden;
                }

                if (rollCount == 3 && announceClicked)
                {
                    FourthColumnWrite();
                }
            }

        }

        private void FourthColumnWrite()
        {
            if (clickedFourthTextBlockName == "Rowwww1" || clickedFourthTextBlockName == "Rowwww2"
                || clickedFourthTextBlockName == "Rowwww3" || clickedFourthTextBlockName == "Rowwww4" || clickedFourthTextBlockName == "Rowwww5" || clickedFourthTextBlockName == "Rowwww6")
            {
                int textBlockTemp = 0;
                for (int i = 1; i <= 6; i++)
                {
                    if (clickedFourthTextBlockName == "Rowwww" + i)
                    {
                        textBlockTemp = i;
                        break;
                    }
                }

                    if (scoreDictionary[textBlockTemp] > 5) // If a user has 6 of the same
                    {
                        scoreDictionary[textBlockTemp] = 5;
                    }
                    int score = scoreDictionary[textBlockTemp] * textBlockTemp;
                    fourthColumnTextBox.Text = score.ToString();
                    fourthColumnTextBox.IsEnabled = false;

            }

            if (Rowwww1.Text != "" && Rowwww2.Text != "" && Rowwww3.Text != ""
            && Rowwww4.Text != "" && Rowwww5.Text != "" && Rowwww6.Text != "") //Sum first 6
            {
                int sum = 0;
                for (int i = 1; i < 7; i++)
                {
                    string textBlockName = "Rowwww" + i;
                    TextBlock textBlock = (TextBlock)this.FindName(textBlockName);
                    string text = textBlock.Text;
                    sum += int.Parse(text);
                }

                if (sum >= 60)
                    sum += 30;

                Rowwww7.Text = sum.ToString();
                rollCount = 0;

                if (Row7.Text != "" && Roww7.Text != "" && Rowww7.Text != "" && Rowwww7.Text != "")
                {
                    int allSum = int.Parse(Row7.Text) + int.Parse(Roww7.Text) + int.Parse(Rowww7.Text) + int.Parse(Rowwww7.Text);
                    Sum1.Text = allSum.ToString();
                }

            }

            if (clickedFourthTextBlockName == "Rowwww8") //Maximum
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
                Rowwww8.Text = maximum.ToString();
                Rowwww8.IsEnabled = false;
                ResetDices();
            }

            if (clickedFourthTextBlockName == "Rowwww9")//MINIMUM
            {
                List<int> numbers = new List<int>();
                for (int i = 0; i < 6; i++)
                {
                    numbers.Add(diceValue[i]);
                }
                int maxValue = numbers.Max();
                numbers.Remove(maxValue);

                Rowwww9.Text = numbers.Sum().ToString();
                Rowwww9.IsEnabled = false;
            }

            if (Rowwww9.Text != "" && Rowwww8.Text != "" && Rowwww1.Text != "") //MINMAX RESULT
            {
                int ones = int.Parse(Rowwww1.Text);
                int maximum = int.Parse(Rowwww8.Text);
                int minimum = int.Parse(Rowwww9.Text);

                Rowwww10.Text = (ones * (maximum - minimum)).ToString();
                rollCount = 0;
                Rowwww10.IsEnabled = false;
                if (Row10.Text != "" && Roww10.Text != "" && Rowww10.Text != "" && Rowwww10.Text != "")
                {
                    int allSum = int.Parse(Row10.Text) + int.Parse(Roww10.Text) + int.Parse(Rowww10.Text) + int.Parse(Rowwww10.Text);
                    Sum2.Text = allSum.ToString();
                }
            }

            if (clickedFourthTextBlockName == "Rowwww11") //KENTA
            {
                if (scoreDictionary[2] > 0 && scoreDictionary[3] > 0 && scoreDictionary[4] > 0 &&
                    scoreDictionary[5] > 0 && scoreDictionary[6] > 0)
                {
                    Rowwww11.Text = "50";
                }
                else if (scoreDictionary[1] > 0 && scoreDictionary[2] > 0 && scoreDictionary[3] > 0 &&
                        scoreDictionary[4] > 0 && scoreDictionary[5] > 0)
                {
                    Rowwww11.Text = "40";
                }
                else
                {
                    Rowwww11.Text = "0";
                }
                Rowwww11.IsEnabled = false;
                rollCount = 0;
            }

            if (clickedFourthTextBlockName == "Rowwww12") //TRILING
            {
                for (int i = 6; i > 0; i--)
                {
                    if (scoreDictionary[i] >= 3)
                    {
                        if (scoreDictionary[i] > 3)
                        {
                            scoreDictionary[i] = 3;
                        }
                        Rowwww12.Text = ((scoreDictionary[i] * i) + 20).ToString();
                        break;
                    }
                    else
                    {
                        Rowwww12.Text = "0";
                    }
                }
                Row12.IsEnabled = false;
                rollCount = 0;
            }
            if (clickedFourthTextBlockName == "Rowwww13") //FUL
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
                                Rowwww13.Text = ful.ToString();
                                break;
                            }
                        }
                    }
                    else if (Rowwww13.Text == "")
                    {
                        Rowwww13.Text = "0";
                    }
                }
                Rowwww13.IsEnabled = false;
                rollCount = 0;
            }

            if (clickedFourthTextBlockName == "Rowwww14") //Poker
            {
                for (int i = 6; i > 0; i--)
                {
                    if (scoreDictionary[i] >= 4)
                    {
                        if (scoreDictionary[i] > 4)
                        {
                            scoreDictionary[i] = 4;
                        }
                        Rowwww14.Text = ((scoreDictionary[i] * i) + 40).ToString();
                        break;
                    }
                    else
                    {
                        Rowwww14.Text = "0";
                    }
                }
                Rowwww14.IsEnabled = false;
                rollCount = 0;
            }

            if (clickedFourthTextBlockName == "Rowwww15") //JAMB
            {
                for (int i = 6; i > 0; i--)
                {
                    if (scoreDictionary[i] >= 5)
                    {
                        if (scoreDictionary[i] > 5)
                        {
                            scoreDictionary[i] = 5;
                        }
                        Rowwww15.Text = ((scoreDictionary[i] * i) + 50).ToString();
                        break;
                    }
                    else
                    {
                        Rowwww15.Text = "0";
                    }
                }
                Rowwww15.IsEnabled = false;
                rollCount = 0;
            }

            if (Rowwww15.Text != "" && Rowwww14.Text != "" && Rowwww13.Text != "" && Rowwww12.Text != "" && Rowwww11.Text != "")
            {
                int sum = 0;
                for (int i = 11; i < 16; i++)
                {
                    string textBlockName = "Rowwww" + i;
                    TextBlock textBlock = (TextBlock)this.FindName(textBlockName);
                    string text = textBlock.Text;
                    sum += int.Parse(text);
                }

                Rowwww16.Text = sum.ToString();
                if (Row16.Text != "" && Roww16.Text != "" && Rowww16.Text != "" && Rowwww16.Text != "")
                {
                    int allSum = int.Parse(Row16.Text) + int.Parse(Roww16.Text) + int.Parse(Rowww16.Text) + int.Parse(Rowwww16.Text);
                    Sum3.Text = allSum.ToString();
                }
            }
            Announce.IsEnabled = false;
            announceClicked = false;
            TextBlock1.IsEnabled = true;
            TextBlock2.IsEnabled = true;

            for (int i = 1; i < 17; i++)
            {
                string Block3 = "Rowww" + i;
                TextBlock TextBlock3 = (TextBlock)this.FindName(Block3);
                if (TextBlock3.Text == "")
                {
                    TextBlock3.IsEnabled = true;
                }
            }
            for (int i = 1; i < 17; i++)
            {
                string Block4 = "Rowwww" + i;
                TextBlock TextBlock4 = (TextBlock)this.FindName(Block4);
                if (TextBlock4.Text == "")
                {
                    TextBlock4.IsEnabled = true;
                }
            }
            string textBlockNumber = new string(clickedFourthTextBlockName.Where(char.IsDigit).ToArray());
            string borderName = "Call" + textBlockNumber;

            // Use FindName to retrieve the Border element by its name
            Border border = (Border)this.FindName(borderName);
            border.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#B6DAF8"));

            ResetDices();
            if (Sum1.Text != "" && Sum2.Text != "" && Sum3.Text != "")
            {
                OnGameEnd(int.Parse(Sum1.Text) + int.Parse(Sum2.Text) + int.Parse(Sum3.Text));
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
                    clickedBorder.BorderBrush = (Brush)new BrushConverter().ConvertFromString("#3FA2F6");
                    clickedBorder.BorderThickness = new Thickness(3);
                    isDiceClicked[borderIndex] = true;
                }
                else
                {
                    clickedBorder.BorderBrush = Brushes.Transparent;
                    isDiceClicked[borderIndex] = false;
                }
            }
        }

        private void Announce_Click(object sender, RoutedEventArgs e)
        {
            RollDiceButton.IsEnabled = false;
            Announce.IsEnabled = false;
            announceClicked = true;
            announceLabelSelect.Visibility = Visibility.Hidden;
            Announce.Background = Announce.Background = (Brush)new BrushConverter().ConvertFromString("#3FA2F6");
            announceLabelChose.Visibility = Visibility.Hidden;
            isEverythingExceptCallBool = false;
            announceLabel.Visibility = Visibility.Visible;

            for (int i = 1; i < 17; i++)
            {
                string Block1 = "Row" + i;
                TextBlock1 = (TextBlock)this.FindName(Block1);
                if (TextBlock1.IsEnabled)
                {
                    TextBlock1.IsEnabled = false;
                    break;
                }
            }

            for(int i = 16; i >= 1; i--)
            {
                string Block2 = "Roww" + i;
                TextBlock2 = (TextBlock)this.FindName(Block2);
                if (TextBlock2.IsEnabled)
                {
                    TextBlock2.IsEnabled = false;
                    break;
                }
            }
            for(int i = 1; i < 17;i++)
            {
                string Block3 = "Rowww" + i;
                TextBlock TextBlock3 = (TextBlock)this.FindName(Block3);
                if (TextBlock3.Text == "")
                {
                    TextBlock3.IsEnabled = false;
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
                ResetDices();
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

                if(Row7.Text != "" && Roww7.Text != "" && Rowww7.Text != "" && Rowwww7.Text != "")
                {
                    int allSum = int.Parse(Row7.Text) + int.Parse(Roww7.Text) + int.Parse(Rowww7.Text) + int.Parse(Rowwww7.Text);
                    Sum1.Text = allSum.ToString();
                }

                ResetDices();
            }

            if (rollCount > 0 && firstColumnCounter == 8) //Maximum
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
             
            if(rollCount > 0 && firstColumnCounter == 9) { //MINIMUM
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
                ResetDices();
            }

            if (firstColumnCounter == 10) //MINMAX RESULT
            {
                int ones = int.Parse(Row1.Text);
                int maximum = int.Parse(Row8.Text);
                int minimum = int.Parse(Row9.Text);

                Row10.Text = (ones*(maximum-minimum)).ToString();
                rollCount = 0;
                Row11.IsEnabled = true;
                firstColumnCounter = 11;
                if (Row10.Text != "" && Roww10.Text != "" && Rowww10.Text != "" && Rowwww10.Text != "")
                {
                    int allSum = int.Parse(Row10.Text) + int.Parse(Roww10.Text) + int.Parse(Rowww10.Text) + int.Parse(Rowwww10.Text);
                    Sum2.Text = allSum.ToString();
                }
                ResetDices();
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
                ResetDices();
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
                ResetDices();
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
                    else if (Row13.Text == "")
                    {
                        Row13.Text = "0";
                    }
                }
                Row13.IsEnabled = false;
                Row14.IsEnabled = true;
                rollCount = 0;
                firstColumnCounter = 14;
                ResetDices();
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
                ResetDices();
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
                ResetDices();
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
                if (Row16.Text != "" && Roww16.Text != "" && Rowww16.Text != "" && Rowwww16.Text != "")
                {
                    int allSum = int.Parse(Row16.Text) + int.Parse(Roww16.Text) + int.Parse(Rowww16.Text) + int.Parse(Rowwww16.Text);
                    Sum3.Text = allSum.ToString();
                }
                ResetDices();
            }
            if (Sum1.Text != "" && Sum2.Text != "" && Sum3.Text != "")
            {
                OnGameEnd(int.Parse(Sum1.Text) + int.Parse(Sum2.Text) + int.Parse(Sum3.Text));
            }
        }
        #endregion

        #region SecondColumn
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
                ResetDices();
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
                ResetDices();
            }

            if (rollCount > 0 && secondColumnCounter == 13) 
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
                    else if (Roww13.Text == "")
                    {
                        Roww13.Text = "0";
                    }
                }
                Roww13.IsEnabled = false;
                Roww12.IsEnabled = true;
                rollCount = 0;
                secondColumnCounter = 12;
                ResetDices();
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
                ResetDices();
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
                ResetDices();
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
                if (Row16.Text != "" && Roww16.Text != "" && Rowww16.Text != "" && Rowwww16.Text != "")
                {
                    int allSum = int.Parse(Row16.Text) + int.Parse(Roww16.Text) + int.Parse(Rowww16.Text) + int.Parse(Rowwww16.Text);
                    Sum3.Text = allSum.ToString();
                }
                ResetDices();
            }


            if (rollCount > 0 && secondColumnCounter == 9)//MINIMUM
            { 
                List<int> numbers = new List<int>();
                for (int i = 0; i < 6; i++)
                {
                    numbers.Add(diceValue[i]);
                }
                int maxValue = numbers.Max();
                numbers.Remove(maxValue);

                Roww9.Text = numbers.Sum().ToString();
                Roww9.IsEnabled = false;
                Roww8.IsEnabled = true;
                rollCount = 0;
                secondColumnCounter = 8;
                ResetDices();
            }


            if (rollCount > 0 && secondColumnCounter == 8) //Maximum
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
                Roww8.Text = maximum.ToString();
                Roww8.IsEnabled = false;
                Roww6.IsEnabled = true;
                secondColumnCounter = 6;
                ResetDices();
            }

            TextBlock clickedTextBlock = sender as TextBlock;
            if (rollCount > 0 && secondColumnCounter < 7)
            {
                if (clickedTextBlock != null && clickedTextBlock.IsEnabled)
                {
                    if (scoreDictionary[secondColumnCounter] > 5) // If a user has 6 of the same
                    {
                        scoreDictionary[secondColumnCounter] = 5;
                    }
                    int score = scoreDictionary[secondColumnCounter] * secondColumnCounter;
                    secondColumnCounter--;
                    clickedTextBlock.Text = score.ToString();
                    clickedTextBlock.IsEnabled = false;
                    var parent = VisualTreeHelper.GetParent(clickedTextBlock) as Panel;

                    if (parent != null)
                    {
                        int clickedIndex = parent.Children.IndexOf(clickedTextBlock);

                        if (clickedIndex >= 0)
                        {
                            var previous = parent.Children[clickedIndex - 1] as TextBlock;

                            if (previous != null)
                            {
                                previous.IsEnabled = true;
                            }
                        }
                    }
                }
                ResetDices();
            }

            if (secondColumnCounter == 0)
            {
                int sum = 0;
                for (int i = 1; i < 7; i++)
                {
                    string textBlockName = "Roww" + i;
                    TextBlock textBlock = (TextBlock)this.FindName(textBlockName);
                    string text = textBlock.Text;
                    sum += int.Parse(text);
                }

                if (sum >= 60)
                    sum += 30;

                Roww7.Text = sum.ToString();
                rollCount = 0;
                Roww10.IsEnabled = true;
                secondColumnCounter = 10;
                if (Row7.Text != "" && Roww7.Text != "" && Rowww7.Text != "" && Rowwww7.Text != "")
                {
                    int allSum = int.Parse(Row7.Text) + int.Parse(Roww7.Text) + int.Parse(Rowww7.Text) + int.Parse(Rowwww7.Text);
                    Sum1.Text = allSum.ToString();
                }

                ResetDices();
            }

            if (secondColumnCounter == 10) //MINMAX RESULT
            {
                int ones = int.Parse(Roww1.Text);
                int maximum = int.Parse(Roww8.Text);
                int minimum = int.Parse(Roww9.Text);

                Roww10.Text = (ones * (maximum - minimum)).ToString();
                rollCount = 0;
                Roww10.IsEnabled = false;
                secondColumnCounter = -1;
                if (Row10.Text != "" && Roww10.Text != "" && Rowww10.Text != "" && Rowwww10.Text != "")
                {
                    int allSum = int.Parse(Row10.Text) + int.Parse(Roww10.Text) + int.Parse(Rowww10.Text) + int.Parse(Rowwww10.Text);
                    Sum2.Text = allSum.ToString();
                }
                ResetDices();
            }
            if (Sum1.Text != "" && Sum2.Text != "" && Sum3.Text != "")
            {
                OnGameEnd(int.Parse(Sum1.Text) + int.Parse(Sum2.Text) + int.Parse(Sum3.Text));
            }
        }
        #endregion

        #region ThirdColumn
        private void ThirdColumnClick(object sender, RoutedEventArgs e)
        {

            TextBlock clickedTextBlock = sender as TextBlock;

            string clickedTextBlockName = clickedTextBlock.Name;

            if (rollCount > 0 && (clickedTextBlockName == "Rowww1" || clickedTextBlockName == "Rowww2"
                || clickedTextBlockName == "Rowww3" || clickedTextBlockName == "Rowww4" || clickedTextBlockName == "Rowww5" || clickedTextBlockName == "Rowww6"))
            {
                int textBlockTemp = 0;
                for (int i = 1; i<=6; i++)
                {
                    if(clickedTextBlockName == "Rowww" + i)
                    {
                        textBlockTemp = i;
                        break;
                    }
                }

                if (clickedTextBlock != null)
                {
                    if (scoreDictionary[textBlockTemp] > 5) // If a user has 6 of the same
                    {
                        scoreDictionary[textBlockTemp] = 5;
                    }
                    int score = scoreDictionary[textBlockTemp] * textBlockTemp;
                    clickedTextBlock.Text = score.ToString();
                    clickedTextBlock.IsEnabled = false;
                }
                ResetDices();
            }



            if (rollCount > 0 && clickedTextBlockName == "Rowww8") //Maximum
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
                Rowww8.Text = maximum.ToString();
                Rowww8.IsEnabled = false;
                rollCount = 0;
                ResetDices();
            }

            if (rollCount > 0 && clickedTextBlockName == "Rowww9")//MINIMUM
            { 
                List<int> numbers = new List<int>();
                for (int i = 0; i < 6; i++)
                {
                    numbers.Add(diceValue[i]);
                }
                int maxValue = numbers.Max();
                numbers.Remove(maxValue);

                Rowww9.Text = numbers.Sum().ToString();
                Rowww9.IsEnabled = false;
                rollCount = 0;
                ResetDices();
            }



            if (rollCount > 0 && clickedTextBlockName == "Rowww11") //KENTA
            {
                if (scoreDictionary[2] > 0 && scoreDictionary[3] > 0 && scoreDictionary[4] > 0 &&
                    scoreDictionary[5] > 0 && scoreDictionary[6] > 0)
                {
                    Rowww11.Text = "50";
                }
                else if (scoreDictionary[1] > 0 && scoreDictionary[2] > 0 && scoreDictionary[3] > 0 &&
                        scoreDictionary[4] > 0 && scoreDictionary[5] > 0)
                {
                    Rowww11.Text = "40";
                }
                else
                {
                    Rowww11.Text = "0";
                }
                Rowww11.IsEnabled = false;
                rollCount = 0;
                ResetDices();
            }

            if (rollCount > 0 && clickedTextBlockName == "Rowww12") //TRILING
            {
                for (int i = 6; i > 0; i--)
                {
                    if (scoreDictionary[i] >= 3)
                    {
                        if (scoreDictionary[i] > 3)
                        {
                            scoreDictionary[i] = 3;
                        }
                        Rowww12.Text = ((scoreDictionary[i] * i) + 20).ToString();
                        break;
                    }
                    else
                    {
                        Rowww12.Text = "0";
                    }
                }
                Rowww12.IsEnabled = false;
                rollCount = 0;
                ResetDices();
            }
            if (rollCount > 0 && clickedTextBlockName == "Rowww13") //FUL
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
                                Rowww13.Text = ful.ToString();
                                break;
                            }
                        }
                    }
                    else if (Rowww13.Text == "")
                    {
                        Rowww13.Text = "0";
                    }
                }
                Rowww13.IsEnabled = false;
                rollCount = 0;
                ResetDices();
            }

            if (rollCount > 0 && clickedTextBlockName == "Rowww14") //Poker
            {
                for (int i = 6; i > 0; i--)
                {
                    if (scoreDictionary[i] >= 4)
                    {
                        if (scoreDictionary[i] > 4)
                        {
                            scoreDictionary[i] = 4;
                        }
                        Rowww14.Text = ((scoreDictionary[i] * i) + 40).ToString();
                        break;
                    }
                    else
                    {
                        Rowww14.Text = "0";
                    }
                }
                Rowww14.IsEnabled = false;
                rollCount = 0;
                ResetDices();
            }

            if (rollCount > 0 && clickedTextBlockName == "Rowww15") //JAMB
            {
                for (int i = 6; i > 0; i--)
                {
                    if (scoreDictionary[i] >= 5)
                    {
                        if (scoreDictionary[i] > 5)
                        {
                            scoreDictionary[i] = 5;
                        }
                        Rowww15.Text = ((scoreDictionary[i] * i) + 50).ToString();
                        break;
                    }
                    else
                    {
                        Rowww15.Text = "0";
                    }
                }
                Rowww15.IsEnabled = false;
                rollCount = 0;
                ResetDices();
            }

            if (Rowww15.Text != "" && Rowww14.Text != "" && Rowww13.Text != "" && Rowww12.Text != ""  && Rowww11.Text != "")
            {
                int sum = 0;
                for (int i = 11; i < 16; i++)
                {
                    string textBlockName = "Rowww" + i;
                    TextBlock textBlock = (TextBlock)this.FindName(textBlockName);
                    string text = textBlock.Text;
                    sum += int.Parse(text);
                }

                Rowww16.Text = sum.ToString();
                ResetDices();
            }

            if (Rowww1.Text != "" && Rowww8.Text != "" && Rowww9.Text != "") //MINMAX RESULT
            {
                int ones = int.Parse(Rowww1.Text);
                int maximum = int.Parse(Rowww8.Text);
                int minimum = int.Parse(Rowww9.Text);

                Rowww10.Text = (ones * (maximum - minimum)).ToString();
                rollCount = 0;
                ResetDices();
            }

            if (Rowww1.Text != "" && Rowww2.Text != "" && Rowww3.Text != ""
                && Rowww4.Text != "" && Rowww5.Text != "" && Rowww6.Text != "") //Sum first 6
            {
                int sum = 0;
                for (int i = 1; i < 7; i++)
                {
                    string textBlockName = "Rowww" + i;
                    TextBlock textBlock = (TextBlock)this.FindName(textBlockName);
                    string text = textBlock.Text;
                    sum += int.Parse(text);
                }

                if (sum >= 60)
                    sum += 30;

                Rowww7.Text = sum.ToString();
                rollCount = 0;
                if (Row7.Text != "" && Roww7.Text != "" && Rowww7.Text != "" && Rowwww7.Text != "")
                {
                    int allSum = int.Parse(Row7.Text) + int.Parse(Roww7.Text) + int.Parse(Rowww7.Text) + int.Parse(Rowwww7.Text);
                    Sum1.Text = allSum.ToString();
                }
                ResetDices();
            }
            if (Sum1.Text != "" && Sum2.Text != "" && Sum3.Text != "")
            {
                OnGameEnd(int.Parse(Sum1.Text) + int.Parse(Sum2.Text) + int.Parse(Sum3.Text));
            }

        }
        #endregion

        #region FourthColumn
        private void FourthColumnClick(object sender, EventArgs e)
        {
            TextBlock clickedTextBlock = sender as TextBlock;

                if (rollCount == 1 && announceClicked && !isNumberSelected)
                {

                    clickedFourthTextBlockName = clickedTextBlock.Name;
                    fourthColumnTextBox = clickedTextBlock;
                    announceLabel.Visibility = Visibility.Hidden;
                    RollDiceButton.IsEnabled = true;
                    Announce.IsEnabled = false;

                    string textBlockNumber = new string(clickedFourthTextBlockName.Where(char.IsDigit).ToArray());
                    string borderName = "Call" + textBlockNumber;

                    // Use FindName to retrieve the Border element by its name
                    Border border = (Border)this.FindName(borderName);
                    border.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#76c1df"));
                    for (int i = 1; i < 17; i++)
                    {
                        string Block4 = "Rowwww" + i;
                        TextBlock TextBlock4 = (TextBlock)this.FindName(Block4);
                        if (fourthColumnTextBox != TextBlock4)
                        {
                            TextBlock4.IsEnabled = false;
                        }

                    }
                isNumberSelected = true;
                    return;
                }

                if (announceClicked && (clickedFourthTextBlockName == "Rowwww1" || clickedFourthTextBlockName == "Rowwww2"
                    || clickedFourthTextBlockName == "Rowwww3" || clickedFourthTextBlockName == "Rowwww4" || clickedFourthTextBlockName == "Rowwww5" || clickedFourthTextBlockName == "Rowwww6"))
                {
                    int textBlockTemp = 0;
                    for (int i = 1; i <= 6; i++)
                    {
                        if (clickedFourthTextBlockName == "Rowwww" + i)
                        {
                            textBlockTemp = i;
                            break;
                        }
                    }

                    clickedTextBlock.IsEnabled = true;

                    if (clickedTextBlock != null)
                    {
                        if (scoreDictionary[textBlockTemp] > 5) // If a user has 6 of the same
                        {
                            scoreDictionary[textBlockTemp] = 5;
                        }
                        int score = scoreDictionary[textBlockTemp] * textBlockTemp;
                        clickedTextBlock.Text = score.ToString();
                        clickedTextBlock.IsEnabled = false;
                    }

                }

                if (Rowwww1.Text != "" && Rowwww2.Text != "" && Rowwww3.Text != ""
                    && Rowwww4.Text != "" && Rowwww5.Text != "" && Rowwww6.Text != "") //Sum first 6
                {
                    int sum = 0;
                    for (int i = 1; i < 7; i++)
                    {
                        string textBlockName = "Rowwww" + i;
                        TextBlock textBlock = (TextBlock)this.FindName(textBlockName);
                        string text = textBlock.Text;
                        sum += int.Parse(text);
                    }

                    if (sum >= 60)
                        sum += 30;

                    Rowwww7.Text = sum.ToString();
                    if (Row7.Text != "" && Roww7.Text != "" && Rowww7.Text != "" && Rowwww7.Text != "")
                    {
                        int allSum = int.Parse(Row7.Text) + int.Parse(Roww7.Text) + int.Parse(Rowww7.Text) + int.Parse(Rowwww7.Text);
                        Sum1.Text = allSum.ToString();
                    }
                    rollCount = 0;
                }

                if (announceClicked && clickedFourthTextBlockName == "Rowwww8") //Maximum
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
                    Rowwww8.Text = maximum.ToString();
                    Rowwww8.IsEnabled = false;
                    ResetDices();
                }

                if (announceClicked && clickedFourthTextBlockName == "Rowwww9")//MINIMUM
                {
                    List<int> numbers = new List<int>();
                    for (int i = 0; i < 6; i++)
                    {
                        numbers.Add(diceValue[i]);
                    }
                    int maxValue = numbers.Max();
                    numbers.Remove(maxValue);

                    Rowwww9.Text = numbers.Sum().ToString();
                    Rowwww9.IsEnabled = false;
                }

                if (Rowwww8.Text != "" && Rowwww9.Text != "" && Rowwww1.Text != "") //MINMAX RESULT
                {
                    int ones = int.Parse(Rowwww1.Text);
                    int maximum = int.Parse(Rowwww8.Text);
                    int minimum = int.Parse(Rowwww9.Text);

                    Rowwww10.Text = (ones * (maximum - minimum)).ToString();
                    rollCount = 0;
                    Rowwww10.IsEnabled = false;
                    if (Row10.Text != "" && Roww10.Text != "" && Rowww10.Text != "" && Rowwww10.Text != "")
                    {
                        int allSum = int.Parse(Row10.Text) + int.Parse(Roww10.Text) + int.Parse(Rowww10.Text) + int.Parse(Rowwww10.Text);
                        Sum2.Text = allSum.ToString();
                    }
                }

                if (announceClicked && clickedFourthTextBlockName == "Rowwww11") //KENTA
                {
                    if (scoreDictionary[2] > 0 && scoreDictionary[3] > 0 && scoreDictionary[4] > 0 &&
                        scoreDictionary[5] > 0 && scoreDictionary[6] > 0)
                    {
                        Rowwww11.Text = "50";
                    }
                    else if (scoreDictionary[1] > 0 && scoreDictionary[2] > 0 && scoreDictionary[3] > 0 &&
                            scoreDictionary[4] > 0 && scoreDictionary[5] > 0)
                    {
                        Rowwww11.Text = "40";
                    }
                    else
                    {
                        Rowwww11.Text = "0";
                    }
                    Rowwww11.IsEnabled = false;
                    rollCount = 0;
                }

                if (announceClicked && clickedFourthTextBlockName == "Rowwww12") //TRILING
                {
                    for (int i = 6; i > 0; i--)
                    {
                        if (scoreDictionary[i] >= 3)
                        {
                            if (scoreDictionary[i] > 3)
                            {
                                scoreDictionary[i] = 3;
                            }
                            Rowwww12.Text = ((scoreDictionary[i] * i) + 20).ToString();
                            break;
                        }
                        else
                        {
                            Rowwww12.Text = "0";
                        }
                    }
                    Row12.IsEnabled = false;
                    rollCount = 0;
                }
                if (announceClicked && clickedFourthTextBlockName == "Rowwww13") //FUL
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
                                    Rowwww13.Text = ful.ToString();
                                    break;
                                }
                            }
                        }
                        else if (Rowwww13.Text == "")
                        {
                            Rowwww13.Text = "0";
                        }
                    }
                    Rowwww13.IsEnabled = false;
                    rollCount = 0;
                }

                if (announceClicked && clickedFourthTextBlockName == "Rowwww14") //Poker
                {
                    for (int i = 6; i > 0; i--)
                    {
                        if (scoreDictionary[i] >= 4)
                        {
                            if (scoreDictionary[i] > 4)
                            {
                                scoreDictionary[i] = 4;
                            }
                            Rowwww14.Text = ((scoreDictionary[i] * i) + 40).ToString();
                            break;
                        }
                        else
                        {
                            Rowwww14.Text = "0";
                        }
                    }
                    Rowwww14.IsEnabled = false;
                    rollCount = 0;
                }

                if (announceClicked && clickedFourthTextBlockName == "Rowwww15") //JAMB
                {
                    for (int i = 6; i > 0; i--)
                    {
                        if (scoreDictionary[i] >= 5)
                        {
                            if (scoreDictionary[i] > 5)
                            {
                                scoreDictionary[i] = 5;
                            }
                            Rowwww15.Text = ((scoreDictionary[i] * i) + 50).ToString();
                            break;
                        }
                        else
                        {
                            Rowwww15.Text = "0";
                        }
                    }
                    Rowwww15.IsEnabled = false;
                    rollCount = 0;
                }

                if (Rowwww15.Text != "" && Rowwww14.Text != "" && Rowwww13.Text != "" && Rowwww12.Text != "" && Rowwww11.Text != "")
                {
                    int sum = 0;
                    for (int i = 11; i < 16; i++)
                    {
                        string textBlockName = "Rowwww" + i;
                        TextBlock textBlock = (TextBlock)this.FindName(textBlockName);
                        string text = textBlock.Text;
                        sum += int.Parse(text);
                    }

                    Rowwww16.Text = sum.ToString();
                    if (Row16.Text != "" && Roww16.Text != "" && Rowww16.Text != "" && Rowwww16.Text != "")
                    {
                        int allSum = int.Parse(Row16.Text) + int.Parse(Roww16.Text) + int.Parse(Rowww16.Text) + int.Parse(Rowwww16.Text);
                        Sum3.Text = allSum.ToString();
                    }
                }

                TextBlock1.IsEnabled = true;
                TextBlock2.IsEnabled = true;

                for (int i = 1; i < 17; i++)
                {
                    string Block3 = "Rowww" + i;
                    TextBlock TextBlock3 = (TextBlock)this.FindName(Block3);
                    if (TextBlock3.Text == "")
                    {
                        TextBlock3.IsEnabled = true;
                    }
                }

                for (int i = 1; i < 17; i++)
                {
                    string Block4 = "Rowwww" + i;
                    TextBlock TextBlock4 = (TextBlock)this.FindName(Block4);
                    if (TextBlock4.Text == "")
                    {
                        TextBlock4.IsEnabled = true;
                    }
                }
                announceClicked = false;

                string textBlockNumberr = new string(clickedFourthTextBlockName.Where(char.IsDigit).ToArray());
                string borderNamee = "Call" + textBlockNumberr;
            isNumberSelected = false;
            // Use FindName to retrieve the Border element by its name
            Border borderr = (Border)this.FindName(borderNamee);
                borderr.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#B6DAF8"));
                ResetDices();

                if (Sum1.Text != "" && Sum2.Text != "" && Sum3.Text != "")
                {
                    OnGameEnd(int.Parse(Sum1.Text) + int.Parse(Sum2.Text) + int.Parse(Sum3.Text));
                }
            
        }
        #endregion

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
            Border1.IsEnabled = false;
            Border2.IsEnabled = false;
            Border3.IsEnabled = false;
            Border4.IsEnabled = false;
            Border5.IsEnabled = false;
            Border6.IsEnabled = false;
            rollCount = 0;
            RollDiceButton.IsEnabled = true;

        }

        private void OnGameEnd(int score)
        {
            EndPopUp popup = new EndPopUp(score);
            bool? result = popup.ShowDialog();
            if (result == true)
            {
                RestartGame();
            }
        }

        private void RestartGame()
        {
            
         ResetDices();
         firstColumnCounter = 1;
         secondColumnCounter = 15;
         announceClicked = false;
         clickedFourthTextBlockName = "";
         isEverythingExceptCallBool = false;

            for (int i = 1; i < 17; i++)
            {
                string row = "Row" + i;
                TextBlock TextBlock1 = (TextBlock)this.FindName(row);
                if (row == "Row1")
                {
                    TextBlock1.IsEnabled = true;
                    TextBlock1.Text = "";
                }
                else if(row == "Row7" || row == "Row10" || row == "Row16")
                {
                    TextBlock1.IsEnabled = false;
                    TextBlock1.Text = "";
                }
                else
                {
                    TextBlock1.IsEnabled = false;
                    TextBlock1.Text = "";
                }
            }
            for (int i = 1; i < 17; i++)
            {
                string row = "Roww" + i;
                TextBlock TextBlock1 = (TextBlock)this.FindName(row);
                if (row == "Roww15")
                {
                    TextBlock1.IsEnabled = true;
                    TextBlock1.Text = "";
                }
                else if (row == "Roww7" || row == "Roww10" || row == "Roww16")
                {
                    TextBlock1.IsEnabled = false;
                    TextBlock1.Text = "";
                }
                else
                {
                    TextBlock1.IsEnabled = false;
                    TextBlock1.Text = "";
                }

            }
            for (int i = 1; i < 17; i++)
            {
                string row = "Rowww" + i;
                TextBlock TextBlock1 = (TextBlock)this.FindName(row);
                if (row == "Rowww7" || row == "Rowww10" || row == "Rowww16")
                {
                    TextBlock1.IsEnabled = false;
                    TextBlock1.Text = "";
                }
                TextBlock1.IsEnabled = true;
                TextBlock1.Text = "";

            }
            for (int i = 1; i < 17; i++)
            {
                string row = "Rowwww" + i;
                TextBlock TextBlock1 = (TextBlock)this.FindName(row);
                if (row == "Rowwww7")
                {
                    TextBlock1.IsEnabled = true;
                    TextBlock1.Text = "";
                }
                else if (row == "Rowwww7" || row == "Rowwww10" || row == "Rowwww16")
                {
                    TextBlock1.IsEnabled = false;
                    TextBlock1.Text = "";
                }
                else
                {
                    TextBlock1.IsEnabled = true;
                    TextBlock1.Text = "";
                }

            }
            Sum1.Text = "";
            Sum2.Text = "";
            Sum3.Text = "";



        }

        private void RulesClick(object sender, RoutedEventArgs e)
        {
            Rules rules = new Rules();
            rules.ShowDialog();
        }

    }




}
