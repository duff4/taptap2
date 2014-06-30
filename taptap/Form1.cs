using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace taptap
{
    public partial class Form1 : Form
    {
        Random random = new Random();
        Stats stats = new Stats();
        public Form1()
        {
            InitializeComponent();
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!stats.IsGameOver)
            {
                listBox1.Items.Add((Keys)random.Next(65, 90));
                if (listBox1.Items.Count > 8)
                {
                    listBox1.Items.Clear();
                    listBox1.Items.Add("Game over");
                    stats.IsGameOver = true;
                    //timer1.Stop();
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (!stats.IsGameOver)
            {
                if (listBox1.Items.Contains(e.KeyCode))
                {
                    listBox1.Items.Remove(e.KeyCode);
                    listBox1.Refresh();
                    timer1.Interval -= timer1.Interval / 50;
                    if(timer1.Interval>100)
                        difficultyProgressBar.Value = 800 - timer1.Interval;
                    //listBox1.BackColor.R++;
                    //listBox1.BackColor = Color.FromArgb(255, (int)((timer1.Interval * 255 / 800)), (int)((timer1.Interval * 255 / 800)));
                    listBox1.BackColor = Color.FromArgb((int)((255-timer1.Interval * 255 / 800)), (int)((timer1.Interval * 255 / 800)), 0);
                    
                    stats.Update(true);
                }
                else
                {
                    stats.Update(false);
                }
                CorrectLabel.Text = "Correct: " + stats.Correct;
                MissedLabel.Text = "Missed: " + stats.Missed;
                totalLabel.Text = "Total: " + stats.Total;
                accuracyLabel.Text = "Accuracy: " + stats.Accuracy + "%";
            }
        }

        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {
            stats.Correct = 0;
            CorrectLabel.Text = "Correct: 0";
            stats.Missed = 0;
            MissedLabel.Text = "Missed: 0";
            stats.Total = 0;
            totalLabel.Text = "Total: 0";
            stats.Accuracy = 0;
            accuracyLabel.Text = "Accuracy: 0%";
            difficultyProgressBar.Value = 0;
            timer1.Interval = 800;
            listBox1.Items.Clear();
            stats.IsGameOver = false;

        }
    }
}
