using System;
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

            //string path = @"C:\Users\Aya\Downloads\modeling and simulation\task 1\modelling-and-simulation-\Template_Students\MultiQueueSimulation\MultiQueueSimulation\TestCases\TestCase1.txt";
            //SimulationSystem system = new SimulationSystem();
            //system.test_num(path);
            //system.all();
            //string result = TestingManager.Test(system, Constants.FileNames.TestCase1);
            //MessageBox.Show(result);

            string path1 = @"C:\Users\Aya\Downloads\modeling and simulation\task 1\modelling-and-simulation-\Template_Students\MultiQueueSimulation\MultiQueueSimulation\TestCases\TestCase2.txt";
            SimulationSystem system1 = new SimulationSystem();
            system1.test_num(path1);
            system1.all();
            string result1 = TestingManager.Test(system1, Constants.FileNames.TestCase2);
            MessageBox.Show(result1);

            //string path2 = @"C:\Users\Aya\Downloads\modeling and simulation\task 1\modelling-and-simulation-\Template_Students\MultiQueueSimulation\MultiQueueSimulation\TestCases\TestCase3.txt";
            // SimulationSystem system2 = new SimulationSystem();
            // system2.test_num(path2);
            // system2.all();
            // string result2 = TestingManager.Test(system2, Constants.FileNames.TestCase3);
            //  MessageBox.Show(result2);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

        }
    }
}
