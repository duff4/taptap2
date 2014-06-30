using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace taptap
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

    class Stats
    {
        public int Total=0;
        public int Missed=0;
        public int Correct=0;
        public int Accuracy = 0;

        public void Update(bool correctKey)
        {
            if (!correctKey)
                Missed++;
            else
                Correct++;
            Accuracy = 100 * Correct / (Missed + Correct);
            Total++;
        }
    }
}
