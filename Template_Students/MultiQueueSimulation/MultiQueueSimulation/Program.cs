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


            OpenFileDialog file = new OpenFileDialog();
            string actualpath = file.FileName;
            string[] x = actualpath.Split('\\');
            string path = x[x.Length - 1];
            char index = path[8];
            string result = "";
            if (index == '1')
            {  
                system.test_num(path);
                system.all();
                result = TestingManager.Test(system, Constants.FileNames.TestCase1);

            MessageBox.Show(result);
             }
            else if (index == '2')
            {   system.test_num(path);
                  system.all();
             result = TestingManager.Test(system, Constants.FileNames.TestCase2);
                MessageBox.Show(result);
            }else if (index == '3')
            {
                system.test_num(path);
                system.all();
                result = TestingManager.Test(system, Constants.FileNames.TestCase2);
                MessageBox.Show(result);
            }

               
            


            //string path1 = @"C:\Users\Aya\Downloads\modeling and simulation\task 1\modelling-and-simulation-\Template_Students\MultiQueueSimulation\MultiQueueSimulation\TestCases\TestCase2.txt";
            //SimulationSystem system1 = new SimulationSystem();
            //system1.test_num(path1);
            //system1.all();
            //string result1 = TestingManager.Test(system1, Constants.FileNames.TestCase2);
            //MessageBox.Show(result1);

            string path2 = @"C:\Users\Aya\Downloads\modeling and simulation\task 1\modelling-and-simulation-\Template_Students\MultiQueueSimulation\MultiQueueSimulation\TestCases\TestCase3.txt";
            SimulationSystem system2 = new SimulationSystem();
            system2.test_num(path2);
            system2.all();
            string result2 = TestingManager.Test(system2, Constants.FileNames.TestCase3);
            MessageBox.Show(result2);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

        }
    }
}
