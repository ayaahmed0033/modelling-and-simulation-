using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MultiQueueTesting;
using MultiQueueModels;

namespace MultiQueueSimulation
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            SimulationSystem system = new SimulationSystem();

            string actualpath = System.IO.Directory.GetCurrentDirectory();
            //MessageBox.Show(actualpath);
            string[] x = new string[12];
            string[] t = actualpath.Split('\\');
            for (int i = 0; i < 10; i++)
            {
                x[i] = t[i];
            }
            x[10] = "TestCases";
            string[] arr = { "TestCase1.txt", "TestCase2.txt", "TestCase3.txt" };   
            string result = "";
            for(int i = 0; i < arr.Length; i++)
            {
                x[11] = arr[i];
                String A = string.Join("\\", x);
                MessageBox.Show(A);
                system.Read_CSV(A);
                system.all();
                result = TestingManager.Test(system, Constants.FileNames.TestCase1);
                MessageBox.Show(result);
            }





            

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1(system));

        }
    }
}
