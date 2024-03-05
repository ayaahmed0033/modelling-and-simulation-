using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MultiQueueModels
{
    public class SimulationSystem
    {
        public SimulationSystem(int testcase)
        {
            this.Servers = new List<Server>();
            this.InterarrivalDistribution = new List<TimeDistribution>();
            this.PerformanceMeasures = new PerformanceMeasures();
            this.SimulationTable = new List<SimulationCase>();
            this.Testcase = testcase;


        }
        public int Testcase { get; set; }
        public void test_num()
        {
            string path = @"C:\Users\Aya\Downloads\modeling and simulation\task 1\Template_Students\MultiQueueSimulation\MultiQueueSimulation\TestCases\TestCase" + Testcase.ToString() + ".txt";

            string[] lines = File.ReadAllLines(path);

            int lineIndex = 1;

            // Read the NumberOfServers
            NumberOfServers = int.Parse(lines[lineIndex]);

            lineIndex += 3;
            // Read the StoppingNumber
            StoppingNumber = int.Parse(lines[lineIndex]);

            lineIndex += 3;
            // Read the StoppingCriteria
            StoppingCriteria = (Enums.StoppingCriteria)int.Parse(lines[lineIndex]);

            lineIndex += 3;
            // Read the SelectionMethod
            SelectionMethod = (Enums.SelectionMethod)int.Parse(lines[lineIndex]);

            lineIndex += 3;
            // Read the InterarrivalDistribution
            InterarrivalDistribution = new List<TimeDistribution>();
            while (lines[lineIndex] != "")
            {
                string[] distributionParts = lines[lineIndex].Split(',');
                InterarrivalDistribution.Add(new TimeDistribution
                {
                    Time = int.Parse(distributionParts[0]),
                    Probability = decimal.Parse(distributionParts[1])
                });
                lineIndex++;
            }

            lineIndex += 2;
            // Read the ServiceDistributions
            Servers = new List<Server>();
            for (int i = 1; i < NumberOfServers+1; i++)
            {
                List<TimeDistribution> serviceDistribution = new List<TimeDistribution>();
                lineIndex++;
                
                try
                {
                    while (lines[lineIndex] != "")
                    {
                        string[] distributionParts = lines[lineIndex].Split(',');
                        serviceDistribution.Add(new TimeDistribution
                        {
                            Time = int.Parse(distributionParts[0]),
                            Probability = decimal.Parse(distributionParts[1]),
                            CummProbability = serviceDistribution[i].Probability + serviceDistribution[i - 1].Probability,
                            MinRange = serviceDistribution[i - 1].MaxRange,
                            MaxRange = (int)(serviceDistribution[i].Probability * 100)
                        }); 
                        lineIndex++;

                    }
                }catch(Exception E) { };
                Servers.Add(new Server { TimeDistribution = serviceDistribution });
                lineIndex++;
            }

        }
        public void find_interarrival()
        {

        }
        public void all()
        {
            find_interarrival();
             

        }

        ///////////// INPUTS ///////////// 
        public int NumberOfServers { get; set; }
        public int StoppingNumber { get; set; }
        public List<Server> Servers { get; set; }
        public List<TimeDistribution> InterarrivalDistribution { get; set; }
        public Enums.StoppingCriteria StoppingCriteria { get; set; }
        public Enums.SelectionMethod SelectionMethod { get; set; }

        ///////////// OUTPUTS /////////////
        public List<SimulationCase> SimulationTable { get; set; }
        public PerformanceMeasures PerformanceMeasures { get; set; }

    }
}
