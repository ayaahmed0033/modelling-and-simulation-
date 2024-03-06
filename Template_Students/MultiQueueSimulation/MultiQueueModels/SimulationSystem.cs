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
            int i = 1;
            while (lines[lineIndex] != "")
            {
                string[] distributionParts = lines[lineIndex].Split(',');
                InterarrivalDistribution.Add(new TimeDistribution
                {
                    Time = int.Parse(distributionParts[0]),
                    Probability = decimal.Parse(distributionParts[1]),
                    CummProbability = InterarrivalDistribution[i].Probability + InterarrivalDistribution[i - 1].Probability,
                    MinRange = InterarrivalDistribution[i - 1].MaxRange,
                    MaxRange = (int)(InterarrivalDistribution[i].Probability * 100)
                });
                lineIndex++;
            }

            lineIndex += 2;
            // Read the ServiceDistributions
            Servers = new List<Server>();
             i = 1;
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
        public void find_interarrival()
        {
            InterarrivalDistribution = new List<TimeDistribution>();
            SimulationTable = new List<SimulationCase>();
            for (int i = 0; i < StoppingNumber; i++)
            {
                Random r = new Random();
                int random_Num = r.Next(0, 90);

                SimulationTable[i].InterArrival = random_Num;
            }
        }
        public void ChooseServer(SimulationCase customer)
        {
            Servers = new List<Server>();
            if (SelectionMethod.Equals (1))
            {
                if (Servers[1].avaialble== true)
                customer.AssignedServer = Servers[1];

            }
            
            else if (SelectionMethod.Equals (2))
            {
                for (int i = 0; i < NumberOfServers; i++) // if all servers are full
                {

                    int min = i;

                    if (Servers[min].FinishTime > Servers[i].FinishTime)
                        min = i;
                    customer.AssignedServer = Servers[min];

                }

            }
        }
        public void CalcClockTimeArrival()
        {

            SimulationTable = new List<SimulationCase>();
            for (int i = 1; i < StoppingNumber + 1; i++)
            {
                if (i == 1)
                {
                    SimulationTable[i].TimeInQueue = 0;
                }
                else
                {
                    SimulationTable[i].ArrivalTime = SimulationTable[i].InterArrival + SimulationTable[i - 1].ArrivalTime;
                }
            }
        }

        public void CalcTimeInQueue()
        {
            for (int i = 1; i < StoppingNumber + 1; i++)
            {
                if (i == 1)
                {
                    SimulationTable[i].TimeInQueue = 0;
                }
                if (SimulationTable[i - 1].EndTime > SimulationTable[i].ArrivalTime)
                {
                    SimulationTable[i].TimeInQueue = SimulationTable[i - 1].EndTime - SimulationTable[i].ArrivalTime;
                }
                else
                {
                    SimulationTable[i].TimeInQueue = 0;
                }
            }

        }

        public void CalcStartTime()
        {
            for (int i = 1; i < StoppingNumber + 1; i++)
            {
                if (i == 1)
                {
                    SimulationTable[i].StartTime = 0;
                }

                SimulationTable[i].StartTime = SimulationTable[i - 1].EndTime;
            }
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
