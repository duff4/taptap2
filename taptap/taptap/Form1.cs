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
            
            listBox1.Items.Add((Keys)random.Next(65, 90));
            if (listBox1.Items.Count > 8)
            {
                listBox1.Items.Clear();
                listBox1.Items.Add("Game over");
                timer1.Stop();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (listBox1.Items.Contains(e.KeyCode))
            {
                listBox1.Items.Remove(e.KeyCode);
                listBox1.Refresh();
                timer1.Interval -= timer1.Interval / 50;
                difficultyProgressBar.Value = 800 - timer1.Interval;

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
}
