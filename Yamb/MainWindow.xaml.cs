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

        public MainWindow()
        {
            InitializeComponent();
            diceBorders = new Border[] { Border1, Border2, Border3, Border4, Border5, Border6 };
        }

        private void RollDice_Click(object sender, RoutedEventArgs e)
        {
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



        private void GridSquare_Click(object sender, RoutedEventArgs e)
        {
            TextBlock clickedSquare = sender as TextBlock; 
            int rowIndex = Grid.GetRow(clickedSquare);
            
            rollCount = 0;
            RollDiceButton.IsEnabled = true; // Re-enable the roll button
        }


        private void FirstColumnClick(object sender, RoutedEventArgs e)
        {

            TextBlock clickedTextBlock = sender as TextBlock;
            if (rollCount > 0)
            {
                if (clickedTextBlock != null && clickedTextBlock.IsEnabled)
                {
                    //TODO : Logic for writing the result here
                    if (scoreDictionary[firstColumnCounter] > 5) // If a user has 6 of the same
                    {
                        scoreDictionary[firstColumnCounter] = 5;
                    }
                    int score = scoreDictionary[firstColumnCounter]*firstColumnCounter;
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
                                MessageBox.Show($"Enabled: {nextElement.Name}");
                            }
                        }
                    }

                }
            }

            //RESET EVERYTHING
            for(int i = 0; i<6; i++)
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

        //MAKE A FUNCTION THAT WILL BE CALLED TO RESET THE DICES AFTER WRITING A SCORE

    }
}
