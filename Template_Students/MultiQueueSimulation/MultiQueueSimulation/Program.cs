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
            

            string actualpath = System.IO.Directory.GetCurrentDirectory();
            //MessageBox.Show(actualpath);         
            string[] t = actualpath.Split('\\');
            string[] x = new string[t.Length];  
            for (int i = 0; i < x.Length-1; i++)   
            {
                x[i] = t[i];
            }
            x[x.Length - 2] = "TestCases";
            string[] arr = { "TestCase1.txt", "TestCase2.txt", "TestCase3.txt"};   
            string result = "";
           
             
            int choose =1;                                         //// change  choose numberrr ////
            SimulationSystem system = new SimulationSystem();

            String path = "";
            // MessageBox.Show(path);

            if (choose==1)
            {
                x[x.Length - 1] = arr[0];
                path = string.Join("\\", x);
                system.test_num(path);
                system.all();
                result = TestingManager.Test(system, Constants.FileNames.TestCase1);
                MessageBox.Show(result);
            }
            else if (choose.Equals(2))
            {
                x[x.Length - 1] = arr[1];
                path = string.Join("\\", x);
                system.test_num(path);
                system.all();
                result = TestingManager.Test(system, Constants.FileNames.TestCase2);
                MessageBox.Show(result);
            }
            else if (choose.Equals(3))
            {
                x[x.Length - 1] = arr[2];
                path = string.Join("\\", x);
                system.test_num(path);
                system.all();
                result = TestingManager.Test(system, Constants.FileNames.TestCase3);
                MessageBox.Show(result);
            }

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(true);
            //Application.Run(new Form1(system, path));     // 7oto second paramter 3and forms 3ashan ta5do el path





        }
    }
}
