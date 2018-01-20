using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Math_Quiz
{
    public partial class Form1 : Form
    {
        Random randomizer = new Random();

        int addend1;
        int addend2;

        int subtractend1;
        int subtractend2;

        int multiplicand;
        int multiplier;

        int dividend;
        int divisor;

        int timeLeft;

        public Form1()
        {
            InitializeComponent();
            CurrentDate.Text = DateTime.Now.ToString("dd MMM yyyy");
        }

        public void StartTheQuiz()
        {
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);

            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();

            sum.Value = 0;

            subtractend1 = randomizer.Next(1,101);
            subtractend2 = randomizer.Next(1, subtractend1);
            minusLeftLabel.Text = subtractend1.ToString();
            minusRIghtLabel.Text = subtractend2.ToString();

            difference.Value = 0;

            multiplicand = randomizer.Next(2, 11);
            multiplier = randomizer.Next(2, 11);
            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();

            product.Value = 0;

            divisor = randomizer.Next(2, 11);
            int temp = randomizer.Next(2, 11);
            dividend = divisor * temp;
            dividedLeftLabel.Text = dividend.ToString();
            dividedRightLabel.Text = divisor.ToString();

            quotient.Value = 0;


            timeLeft = 30;
            timeLabel.Text = timeLeft.ToString() + " seconds";
            timer1.Start();
        }

        public bool CheckTheAnswer()
        {
            if (addend1 + addend2 == sum.Value && 
                subtractend1 - subtractend2 == difference.Value &&
                multiplicand * multiplier == product.Value &&
                dividend / divisor == quotient.Value)
                return true;
            else
                return false;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckTheAnswer())
            {
                timer1.Stop();
                MessageBox.Show("You got all the answers right!",
                            "Congratulations!");
                startButton.Enabled = true;
            }
            else if (timeLeft > 0)
            {
                timeLeft -= 1;
                timeLabel.Text = timeLeft + " seconds";
                if(timeLeft <= 5)
                    timeLabel.ForeColor = System.Drawing.Color.Red;
                
            }
            else
            {
                timer1.Stop();
                timeLabel.Text = "Time's up!";
                timeLabel.ForeColor = Color.Black;
                MessageBox.Show("You didn't finish in time.", "Sorry!");
                sum.Value = addend1 + addend2;
                difference.Value = subtractend1 - subtractend2;
                product.Value = multiplicand * multiplier;
                quotient.Value = dividend / divisor;
                startButton.Enabled = true;
            }


        }

        private void answer_Enter(object sender, EventArgs e)
        {
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                answerBox.Select(0, answerBox.Value.ToString().Length);
            }
        }

        private void sound_ValueChanged(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"C:\Users\JessieJay\Downloads\CorrectValue.wav");

            NumericUpDown answerBox = sender as NumericUpDown;
            if (answerBox != null)
            {
                switch (answerBox.Name.ToString())
                {
                    case "sum":
                        if (addend1 + addend2 == answerBox.Value)
                            player.Play();
                        break;
                    case "difference":
                        if (subtractend1 - subtractend2 == answerBox.Value)
                            player.Play();
                        break;
                    case "product":
                        if (multiplicand * multiplier == answerBox.Value)
                            player.Play();
                        break;
                    case "quotient":
                        if (dividend / divisor == answerBox.Value)
                            player.Play();
                        break;
                }
            }
        }
    }
}
