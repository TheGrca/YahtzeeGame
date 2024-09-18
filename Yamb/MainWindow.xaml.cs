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
    public partial class MainWindow : Window
    {
        private Random random = new Random();
        private Border[] diceBorders;
        public MainWindow()
        {
            InitializeComponent();

            diceBorders = new Border[] { Border1, Border2, Border3, Border4, Border5, Border6 };
        }

        private void RollDice_Click(object sender, RoutedEventArgs e)
        {
            Image[] diceImages = { Dice1, Dice2, Dice3, Dice4, Dice5, Dice6 };

            for (int i = 0; i < diceImages.Length; i++)
            {
                if (diceBorders[i].BorderBrush == Brushes.Transparent)
                {
                    int randomNumber = random.Next(1, 7);

                    // Set the source of the Image control to the corresponding dice image
                    string imagePath = $"pack://application:,,,/Images/{randomNumber}.png";
                    diceImages[i].Source = new BitmapImage(new Uri(imagePath, UriKind.Absolute));
                }
            }
        }

        private void Dice_Click(object sender, MouseButtonEventArgs e)
        {
            Border clickedBorder = sender as Border;
            int borderIndex = Array.IndexOf(diceBorders, clickedBorder);

            if (borderIndex >= 0)
            {
                // Toggle the click state and border
                if (clickedBorder.BorderBrush == Brushes.Transparent)
                {
                    clickedBorder.BorderBrush = Brushes.Blue;
                    clickedBorder.BorderThickness = new Thickness(3);
                }
                else
                {
                    clickedBorder.BorderBrush = Brushes.Transparent;
                    clickedBorder.BorderThickness = new Thickness(0);
                }
            }
        }
    }
}
