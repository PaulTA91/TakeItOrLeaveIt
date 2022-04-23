using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TakeItorLeaveIt
{
    /// Paul Armstrong
    /// Take it or Leave it game
    /// 23/3/2020
    public partial class Play : Window
    {
        //Declare Global variables
        private int[] prizes = new int[] { 1, 2, 5, 10, 25, 50, 100, 500, 1000, 2000, 5000, 10000, 50000, 25000, 50000, 100000, 125000, 150000, 200000, 250000 };
        int chosenBox = 0;
        int noSelected = 0;
        int round = 1;
        double offer = 0;
        

        public Play()
        {
            InitializeComponent();
            Shuffle();
            //disable accept and refuse buttons
            btnAccept.IsEnabled = false;
            btnRefuse.IsEnabled = false;
        }

        private void Shuffle()
        {
            // Shuffle values in the prize array
            int[] shuffledPrizes = FisherYates(prizes);

            // Assign shuffled values to each of the 20 box buttons.
            Btn1.Tag = shuffledPrizes[0];
            Btn2.Tag = shuffledPrizes[1];
            Btn3.Tag = shuffledPrizes[2];
            Btn4.Tag = shuffledPrizes[3];
            Btn5.Tag = shuffledPrizes[4];
            Btn6.Tag = shuffledPrizes[5];
            Btn7.Tag = shuffledPrizes[6];
            Btn8.Tag = shuffledPrizes[7];
            Btn9.Tag = shuffledPrizes[8];
            Btn10.Tag = shuffledPrizes[9];
            Btn11.Tag = shuffledPrizes[10];
            Btn12.Tag = shuffledPrizes[11];
            Btn13.Tag = shuffledPrizes[12];
            Btn14.Tag = shuffledPrizes[13];
            Btn15.Tag = shuffledPrizes[14];
            Btn16.Tag = shuffledPrizes[15];
            Btn17.Tag = shuffledPrizes[16];
            Btn18.Tag = shuffledPrizes[17];
            Btn19.Tag = shuffledPrizes[18];
            Btn20.Tag = shuffledPrizes[19];
        }

        private int[] FisherYates(int[] array)
        {
            Random r = new Random();
            for (int i = array.Length - 1; i > 0; i--)
            {
                int index = r.Next(i);
                //swap
                int tmp = array[index];
                array[index] = array[i];
                array[i] = tmp;
            }
            return array;
        }

        private void btnBox_Click(object sender, RoutedEventArgs e)
        {

            ///Set content to .Tag value
            ///disable button
            Button shuffledBox = (Button)sender;
            string number = shuffledBox.Tag.ToString();
            shuffledBox.IsEnabled = false;
            double total = 0;
            double temp;

            if (chosenBox == 0)
            {
                int.TryParse(number, out chosenBox); //Sets chosenBox to .Tag value of first button clicked
                txtOffer.Text = ("Please select your first box for round " + round);
            }
            else if (round <= 6)
            {

                noSelected++;
                shuffledBox.IsEnabled = false;

                //Only allow player to select three boxes per round
                switch (noSelected)
                {
                    case 1:
                        shuffledBox.Content = "£" + number;
                        double.TryParse(number, out temp);
                        total = (total + temp);
                        txtOffer.Text = "Please select your second box for this round.";
                        break;
                    case 2:
                        shuffledBox.Content = "£" + number;
                        double.TryParse(number, out temp);
                        total = (total + temp);
                        txtOffer.Text = "Please select your final box for this round.";
                        break;
                    case 3:
                        shuffledBox.Content = "£" + number;
                        double.TryParse(number, out temp);
                        total = (total + temp);
                        btnAccept.IsEnabled = true;
                        btnRefuse.IsEnabled = true;
                        offer = (total * .25);
                        string lblOffer = offer.ToString();
                        txtOffer.Text = ("The banker would like to offer you £" + lblOffer + ", will you accept or refuse the offer?");
                        noSelected = 0;
                        BtnPrizePanel.Visibility = Visibility.Collapsed; //Hides wrap panel containing boxes to prevent player from clicking additional buttons.

                        break;
                }
            }
            else if (round > 6)
            {
                btnAccept.IsEnabled = true;
                shuffledBox.Content = "£" + number;
                int.TryParse(number, out chosenBox);
            }
        }

        private void btnAccept_Click(object sender, RoutedEventArgs e)
        {
            btnDisable();
            btnRefuse.IsEnabled = false;
            if (round <= 6)
            {
                txtOffer.Text = ("You have won £" + offer + ".");

            }
            else
            {
                txtOffer.Text = ("You have won £" + chosenBox + ".");
            }
        }

        private void btnDisable()
        {
            //Disables all box buttons
            Btn1.IsEnabled = false;
            Btn2.IsEnabled = false;
            Btn3.IsEnabled = false;
            Btn4.IsEnabled = false;
            Btn5.IsEnabled = false;
            Btn6.IsEnabled = false;
            Btn7.IsEnabled = false;
            Btn8.IsEnabled = false;
            Btn9.IsEnabled = false;
            Btn10.IsEnabled = false;
            Btn11.IsEnabled = false;
            Btn12.IsEnabled = false;
            Btn13.IsEnabled = false;
            Btn14.IsEnabled = false;
            Btn15.IsEnabled = false;
            Btn16.IsEnabled = false;
            Btn17.IsEnabled = false;
            Btn18.IsEnabled = false;
            Btn19.IsEnabled = false;
            Btn20.IsEnabled = false;
        }

        private void btnRefuse_Click(object sender, RoutedEventArgs e)
        {
            btnAccept.IsEnabled = false;
            round++; //increase round counter by 1

            if (round <= 6)
            {
                txtOffer.Text = ("Please select your first box for round " + round + ".");
            }else if (round > 6)
            {
                btnAccept.IsEnabled = true;
                btnRefuse.IsEnabled = false;
                txtOffer.Text = "Click accept to open your own box or click on the final box and click Accept to claim it instead!";
            }

            BtnPrizePanel.Visibility = Visibility.Visible; //Make wrap panel visable again at beginning of next round.

        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            //Reset all aspects of program to default and begin new game.
            Btn1.Content = "1";
            Btn2.Content = "2";
            Btn3.Content = "3";
            Btn4.Content = "4";
            Btn5.Content = "5";
            Btn6.Content = "6";
            Btn7.Content = "7";
            Btn8.Content = "8";
            Btn9.Content = "9";
            Btn10.Content = "10";
            Btn11.Content = "11";
            Btn12.Content = "12";
            Btn13.Content = "13";
            Btn14.Content = "14";
            Btn15.Content = "15";
            Btn16.Content = "16";
            Btn17.Content = "17";
            Btn18.Content = "18";
            Btn19.Content = "19";
            Btn20.Content = "20";
            Shuffle(); //reshuffle and reassign values
            btnEnabled();
            txtOffer.Text = "Please select the box you would like as your own!";
            round = 1;
            chosenBox = 0;
            btnRefuse.IsEnabled = false;
            btnAccept.IsEnabled = false;
            BtnPrizePanel.Visibility = Visibility.Visible;

        }

        private void btnEnabled()
        {
            //enable all box buttons
            Btn1.IsEnabled = true;
            Btn2.IsEnabled = true;
            Btn3.IsEnabled = true;
            Btn4.IsEnabled = true;
            Btn5.IsEnabled = true;
            Btn6.IsEnabled = true;
            Btn7.IsEnabled = true;
            Btn8.IsEnabled = true;
            Btn9.IsEnabled = true;
            Btn10.IsEnabled = true;
            Btn11.IsEnabled = true;
            Btn12.IsEnabled = true;
            Btn13.IsEnabled = true;
            Btn14.IsEnabled = true;
            Btn15.IsEnabled = true;
            Btn16.IsEnabled = true;
            Btn17.IsEnabled = true;
            Btn18.IsEnabled = true;
            Btn19.IsEnabled = true;
            Btn20.IsEnabled = true;
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            //close program
            Application.Current.Shutdown();
        }



    }
}
