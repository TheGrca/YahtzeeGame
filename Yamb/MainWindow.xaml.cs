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
    public partial class MainWindow : Window
    {
        private Random random = new Random();
        private Border[] diceBorders;

        private int rollCount = 0;
        private int[] diceValue = new int[6];
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
            };

        public MainWindow()
        {
            InitializeComponent();
            diceBorders = new Border[] { Border1, Border2, Border3, Border4, Border5, Border6 };
        }

        private void RollDice_Click(object sender, RoutedEventArgs e)
        {
            Image[] diceImages = { Dice1, Dice2, Dice3, Dice4, Dice5, Dice6 };

            for (int i = 0; i < 6; i++)
            {
                int randomNumber = random.Next(1, 7);
                if (diceBorders[i].BorderBrush == Brushes.Transparent)
                {
                    string imagePath = $"pack://application:,,,/Images/{randomNumber}.png";
                    diceImages[i].Source = new BitmapImage(new Uri(imagePath, UriKind.Absolute));
                    scoreDictionary[randomNumber] += randomNumber;
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
                    //scoreDictionary[]
                }
                else
                {
                    clickedBorder.BorderBrush = Brushes.Transparent;
                    clickedBorder.BorderThickness = new Thickness(0);
                }
            }
        }



        private void GridSquare_Click(object sender, RoutedEventArgs e)
        {
            Button clickedSquare = sender as Button; 
            int rowIndex = Grid.GetRow(clickedSquare);

            int[] valueCounts = new int[6]; // Index 0 for 1s, Index 1 for 2s, ..., Index 5 for 6s
            foreach (var value in diceValue)
            {
                valueCounts[value - 1]++;
            }

            int scoreToAdd = 0;
            int countToWrite = 0;

            if (rowIndex >= 1 && rowIndex < 7) // Ensure rowIndex corresponds to 1-6
            {
                countToWrite = Math.Min(5, valueCounts[rowIndex]); // Use up to 5 of that value
                scoreToAdd = countToWrite * (rowIndex + 1); // Score calculation
            }

            // Update the clicked square with the score
            clickedSquare.Content = scoreToAdd; // Assuming the button displays the score

            // Update the total score
            totalScore += scoreToAdd; // Assuming you have a totalScore variable

            // Check if total score is 60 or more
            if (totalScore >= 60)
            {
                totalScore += 30; // Add bonus
            }

            // Reset roll count and enable the roll button again
            rollCount = 0;
            RollDiceButton.IsEnabled = true; // Re-enable the roll button
        }




    }
}
