using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp11
{
    public partial class Form1 : Form
    {
        private Random random = new Random();
        private Thread[] progressThread;
        private ProgressBar[] ProgressBar;
        private bool[] isFinished; // 차량의 완료 상태를 추적
        private bool isRunning;
        private DateTime startTime;
        public Form1()
        {
            InitializeComponent();
            ProgressBar = new ProgressBar[] { progressBar1, progressBar2, progressBar3, progressBar4, progressBar5 };
            progressThread = new Thread[ProgressBar.Length];
            isFinished = new bool[ProgressBar.Length];

            for (int i = 0; i < ProgressBar.Length; i++)
            {
                ProgressBar[i].Minimum = 0;
                ProgressBar[i].Maximum = 100;
                ProgressBar[i].Value = 0;
                isFinished[i] = false;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (isRunning) return;

            isRunning = true;
            startTime = DateTime.Now;
            for (int i = 0; i < progressThread.Length; i++)
            {
                int index = i;
                progressThread[i] = new Thread(() => UpdateProgressBar(index));
                progressThread[i].IsBackground = true;
                progressThread[i].Start();
            }
        }
        private void UpdateProgressBar(int index)
        {
            while (isRunning)
            {
               
                int newValue = ProgressBar[index].Value + 1; 
                newValue = Math.Min(ProgressBar[index].Maximum, newValue); //100넘지않게

                // UI 스레드에서 ProgressBar 값 업데이트
                Invoke(new MethodInvoker(delegate ()
                {
                    ProgressBar[index].Value = newValue;
                }));



                if (newValue >= ProgressBar[index].Maximum && !isFinished[index])
                {
                    isFinished[index] = true; 

                   
                    TimeSpan elapsedTime = DateTime.Now - startTime;
                    string carName = $"Car {index + 1}";


                    Invoke(new MethodInvoker(delegate ()
                    {
                        listBoxResults.Items.Add($"{carName} finished in {elapsedTime.TotalSeconds:F2} seconds");
                    }));



                    if (Array.TrueForAll(isFinished, finished => finished))
                    {
                        isRunning = false; 
                        MessageBox.Show("레이스 종료!");
                    }
                }
                Thread.Sleep(random.Next(1, 100));
            }
        }
        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}

