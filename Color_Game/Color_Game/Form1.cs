using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Color_Game
{
    public partial class Form1 : Form
    {
        static Color RED = System.Drawing.Color.Red;
        static Color BLUE = System.Drawing.Color.Blue;
        static Color GREEN = System.Drawing.Color.Green;
        static Color PURPLE = System.Drawing.Color.Purple;
        static Color YELLOW = System.Drawing.Color.Yellow;
        static Color BLACK = System.Drawing.Color.Black;
        private const String RED_TEXT = "RED";
        private const String BLUE_TEXT = "BLUE";
        private const String GREEN_TEXT = "GREEN";
        private const String PURPLE_TEXT = "PURPLE";
        private const String YELLOW_TEXT = "YELLOW";
        private const String BLACK_TEXT = "BLACK";
        private String currentWord = "RED";
        private Color currentColor = RED;
        private const int TIMESTART = 12;
        private bool playing = false;
        private bool reset = true;
        private int time = 0;
        private int highscore = 0;
        private int score = 0;
        private int rand = 0;
        private int rand2 = 0;
        private int lastRandom2 = 0;
        private int lastRandom = 0;
        private Random random = new Random();
        private Random random2 = new Random();

        public Form1()
        {
            InitializeComponent();
            using (System.IO.StreamReader sr = new System.IO.StreamReader("highscore.txt"))
            {
                highScoreBox.Text = sr.ReadLine();
                highscore = int.Parse(highScoreBox.Text);
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (time == 0)
            { 
                Console.Beep();
                playing = false;
                if (score > highscore)
                {
                    using (System.IO.StreamWriter sw = new System.IO.StreamWriter("highscore.txt"))
                    {
                        sw.WriteLine(score);
                        sw.Close();
                    }
                    using (System.IO.StreamReader sr = new System.IO.StreamReader("highscore.txt"))
                    {
                        highScoreBox.Text = sr.ReadLine();
                        highscore = int.Parse(highScoreBox.Text);
                    }
                }
                timer.Stop();
            }
            else
            {
                time -= 1;
                playing = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if(!playing && reset)
            {
                playing = true;
                reset = false;
                time = TIMESTART;
                changeColor();
                timer.Start();
            }
           
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            if (score > highscore)
            {
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter("highscore.txt"))
                {
                    sw.WriteLine(score);
                    sw.Close();
                }
                using (System.IO.StreamReader sr = new System.IO.StreamReader("highscore.txt"))
                {
                    highScoreBox.Text = sr.ReadLine();
                    highscore = int.Parse(highScoreBox.Text);
                }
            }
            timer.Stop();
            reset = true;
            playing = false;
            score = 0;
            scoreBox.Text = score.ToString();
            time = TIMESTART;
        }

        private void changeColor()
        {
            lastRandom2 = rand2;
            rand = random.Next(1, 7);
            rand2 = random2.Next(1, 7);
            while (rand == rand2)
            {
                rand = random.Next(1, 7);
            }
            while(lastRandom2 == rand2)
            {
                rand2 = random2.Next(1, 7);
            }

            //CHANGING current color
            switch (rand)
            {
                case 1:
                    currentColor = RED;
                    break;
                case 2:
                    currentColor = BLUE;
                    break;
                case 3:
                    currentColor = GREEN;
                    break;
                case 4:
                    currentColor = PURPLE;
                    break;
                case 5:
                    currentColor = YELLOW;
                    break;
                default:
                    currentColor = BLACK;
                    break;
            }
            //CHANGING current word
            switch (rand2)
            {
                case 1:
                    currentWord = RED_TEXT;
                    break;
                case 2:
                    currentWord = BLUE_TEXT;
                    break;
                case 3:
                    currentWord = GREEN_TEXT;
                    break;
                case 4:
                    currentWord = PURPLE_TEXT;
                    break;
                case 5:
                    currentWord = YELLOW_TEXT;
                    break;
                default:
                    currentWord = BLACK_TEXT;
                    break;
            }
            timer.Start();
            Color.Text = currentWord;
            Color.ForeColor = currentColor;
            scoreBox.Text = score.ToString();
        }

        private void redButton_Click(object sender, EventArgs e)
        {
            if(playing)
            {
                timer.Stop();
                if (currentColor == RED)
                {
                    score++;
                    time = TIMESTART;
                    changeColor();
                }
                else
                {
                    playing = false;
                    Console.Beep();
                }
            }
        }

        private void greenButton_Click(object sender, EventArgs e)
        {
            if (playing)
            {
                timer.Stop();
                if (currentColor == GREEN)
                {
                    score++;
                    time = TIMESTART;
                    changeColor();
                }
                else
                {
                    playing = false;
                    Console.Beep();
                }
            }
        }

        private void yellowButton_Click(object sender, EventArgs e)
        {
            if (playing)
            {
                timer.Stop();
                if (currentColor == YELLOW)
                {
                    score++;
                    time = TIMESTART;
                    changeColor();
                }
                else
                {
                    
                    playing = false;
                    Console.Beep();
                }
            }
        }

        private void purpleButton_Click(object sender, EventArgs e)
        {
            if (playing)
            {
                timer.Stop();
                if (currentColor == PURPLE)
                {
                    score++;
                    time = TIMESTART;
                    changeColor();
                }
                else
                {
                    
                    playing = false;
                    Console.Beep();
                }
            }
        }

        private void blackButton_Click(object sender, EventArgs e)
        {
            if (playing)
            {
                timer.Stop();
                if (currentColor == BLACK)
                {
                    score++;
                    time = TIMESTART;
                    changeColor();
                }
                else
                {
                    
                    playing = false;
                    Console.Beep();
                }
            }
        }

        private void blueButton_Click(object sender, EventArgs e)
        {
            if (playing)
            {
                timer.Stop();
                if (currentColor == BLUE)
                {
                    score++;
                    time = TIMESTART;
                    changeColor();
                }
                else
                {
                    
                    playing = false;
                    Console.Beep();
                }
            }
        }
    }
}
