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





            //else if (index == '2')
            //{   system.test_num(path);
            //      system.all();
            // result = TestingManager.Test(system, Constants.FileNames.TestCase2);
            //    MessageBox.Show(result);
            //}else if (index == '3')
            //{
            //    system.test_num(path);
            //    system.all();
            //    result = TestingManager.Test(system, Constants.FileNames.TestCase2);
            //    MessageBox.Show(result);
            //}





            //string path1 = @"C:\Users\Aya\Downloads\modeling and simulation\task 1\modelling-and-simulation-\Template_Students\MultiQueueSimulation\MultiQueueSimulation\TestCases\TestCase2.txt";
            //SimulationSystem system1 = new SimulationSystem();
            //system1.test_num(path1);
            //system1.all();
            //string result1 = TestingManager.Test(system1, Constants.FileNames.TestCase2);
            //MessageBox.Show(result1);

            //string path2 = @"C:\Users\Aya\Downloads\modeling and simulation\task 1\modelling-and-simulation-\Template_Students\MultiQueueSimulation\MultiQueueSimulation\TestCases\TestCase3.txt";
            //SimulationSystem system2 = new SimulationSystem();
            //system2.test_num(path2);
            //system2.all();
            //string result2 = TestingManager.Test(system2, Constants.FileNames.TestCase3);
            //MessageBox.Show(result2);

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());

        }
    }
}
