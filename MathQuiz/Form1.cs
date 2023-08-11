using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathQuiz
{
    public partial class Form1 : Form
    {
        //Create a random object called randomizer
        //to generate random numbers.
        Random randomizer = new Random();

        //These integr variables store the numbers
        //for the addition problem.
        int addend1;
        int addend2;

        //for subtration
        int minuend;
        int subtrahend;

        //for the multiplication problem
        int multliplicand;
        int multiplier;

        //for the division problem
        int dividend;
        int divisor;

        //keeps track of the remaining time
        int timeLeft;

        public Form1()
        {
            InitializeComponent();
        }

        private void sum_Load(object sender, EventArgs e)
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
                //if return true, and user got the right answer.
                //stop time and show a messagebox
                timer1.Stop();
                MessageBox.Show("You got all the answers right!", "Bravo!!!");
                startButton.Enabled = true;

            }
            else if (timeLeft > 0)
            {
                //if return false, keep counting, 
                //decrease the time left by one second 
                //display the new time lef by updating the
                //time left label
                timeLeft -= 1;
                timelabel.Text = timeLeft + " seconds";
            }
            else
            {
                //if user ran out of time, stop the timer, show a
                //messagebox and fill in the answers.
                timer1.Stop();
                timelabel.Text = "Time's up!";
                MessageBox.Show("You didn't finish in time.", "Sorry!");
                sum.Value = addend1 = addend2;
                difference.Value = minuend - subtrahend;
                product.Value = multliplicand * multiplier;
                qoutient.Value = dividend / divisor;
                startButton.Enabled = true;
            }
        }

        public void StartTheQuiz()
        {
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);

            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();

            sum.Value = 0;

            //subtraction sulotions
            minuend = randomizer.Next(1, 101);
            subtrahend = randomizer.Next(1, minuend);
            minusLeftLabel.Text = subtrahend.ToString();
            minusRightLabel.Text = subtrahend.ToString();
            difference.Value = 0;

            //multiplication Solution
            multliplicand = randomizer.Next(2, 11);
            multiplier = randomizer.Next(2, 11);
            timesLeftLabel.Text = multliplicand.ToString();
            timesRightLabel.Text = subtrahend.ToString();
            difference.Value = 0;

            //division problem
            divisor = randomizer.Next(2, 11);
            int temp = randomizer.Next(2,11);
            dividend = divisor * temp;
            dividedLeftLabel.Text = dividend.ToString();
            dividedRightLabel.Text = divisor.ToString();
            qoutient.Value = 0;

            //start the timer
            timeLeft = 30;
            timelabel.Text = "30 seconds";
            timer1.Start();
        }

        //true if the answer is correct, false otherwise
        private bool CheckTheAnswer()
        {
            if ((addend1 + addend2 == sum.Value) && (minuend - subtrahend == difference.Value) && (multliplicand * multiplier == product.Value) && (dividend / divisor == qoutient.Value))
            {
                return true;
            }else {
                return false; 
            }
        }

        private void answer_Enter(object sender, EventArgs e)
        {
            //select the whole answer in the NumericUpDown control
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                int lenghtOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lenghtOfAnswer);
            }
        }

        private void difference_Enter(object sender, EventArgs e)
        {

       }

       private void difference_Click(object sender, EventArgs e)
        {

        }
    }
}
