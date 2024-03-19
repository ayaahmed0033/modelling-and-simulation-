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
            for(int i = 0; i < arr.Length; i++)
            {
                SimulationSystem system = new SimulationSystem();
                x[x.Length-1] = arr[i];
                String path = string.Join("\\", x);
                MessageBox.Show(path);
                system.test_num(path);
                system.all();
                if (i == 0)
                     result = TestingManager.Test(system, Constants.FileNames.TestCase1);
                else if(i==1)
                    result = TestingManager.Test(system, Constants.FileNames.TestCase2);
                 else if(i==2)
                    result = TestingManager.Test(system, Constants.FileNames.TestCase3);
                MessageBox.Show(result);

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1(system ,path));     // 7oto second paramter 3and forms 3ashan ta5do el path
            }




        }
    }
}
