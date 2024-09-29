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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Yamb
{
    /// <summary>
    /// Interaction logic for EndPopUp.xaml
    /// </summary>
    public partial class EndPopUp : Window
    {
        public EndPopUp(int score)
        {
            InitializeComponent();
            ScoreText.Text = $"SCORE: {score}";
        }

        private void RestartButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;  
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DoubleAnimation fadeIn = new DoubleAnimation(0, 1, TimeSpan.FromSeconds(0.5));
            this.BeginAnimation(Window.OpacityProperty, fadeIn);
        }
    }
}
