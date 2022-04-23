using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stopwatch
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            updateTextBox();
            updateCurTimeLabel();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            timer.Enabled = true;
            buttonStop.Enabled = true;
            buttonStart.Enabled = false;
            buttonRestart.Enabled = false;
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            timer.Enabled = false;
            buttonStop.Enabled = false;
            buttonStart.Enabled = true;
            buttonRestart.Enabled = true;
        }

        private void buttonRestart_Click(object sender, EventArgs e)
        {
            milisecCounter = 0;
            secCounter = 0;
            minCounter = 0;
            hourCounter = 0;

            updateTextBox();

            buttonStop.Enabled = false;
            buttonStart.Enabled = true;
            buttonRestart.Enabled = false;
        }

        int milisecCounter;
        int secCounter;
        int minCounter;
        int hourCounter;

        private void timer_Tick(object sender, EventArgs e)
        {
            milisecCounter++;
            if (milisecCounter == 100)
            {
                milisecCounter = 0;
                secCounter++;
                if (secCounter == 60)
                {
                    secCounter = 0;
                    minCounter++;
                    if (minCounter == 60)
                    {
                        minCounter = 0;
                        hourCounter++;
                    }
                }
            }

            updateTextBox();
        }

        private void updateTextBox()
        {
            textBox1.Text = string.Format("{0}:{1}:{2}:{3}", hourCounter, minCounter, secCounter, milisecCounter);
        }

        private void updateCurTimeLabel()
        {
            labelCurTime.Text = DateTime.Now.ToString("t", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));
        }

        private void timerCurTime_Tick(object sender, EventArgs e)
        {
            updateCurTimeLabel();
        }
    }
}
