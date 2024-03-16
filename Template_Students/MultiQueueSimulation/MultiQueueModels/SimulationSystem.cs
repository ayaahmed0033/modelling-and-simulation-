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
        public SimulationSystem()
        {
            this.Servers = new List<Server>();
            this.InterarrivalDistribution = new List<TimeDistribution>();
            this.PerformanceMeasures = new PerformanceMeasures();
            this.SimulationTable = new List<SimulationCase>();
        }
        public void test_num(string path)
        {
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

           
            while (lines[lineIndex] != "")
            {
                
                string[] distributionParts = lines[lineIndex].Split(',');
                InterarrivalDistribution.Add(new TimeDistribution
                {
                    Time = int.Parse(distributionParts[0]),
                    Probability = decimal.Parse(distributionParts[1]),
                    
                }) ;
                
                lineIndex++;
            }
            
            lineIndex += 2;
            // Read the ServiceDistributions

            for (int i = 0; i < NumberOfServers; i++)
            {
                List<TimeDistribution> serviceDistribution = new List<TimeDistribution>();
                if (i != 0) { lineIndex++; }
                try
                {
                    while (lines[lineIndex] != "")
                    {
                        string[] distributionParts = lines[lineIndex].Split(',');
                        serviceDistribution.Add(new TimeDistribution
                        {
                            Time = int.Parse(distributionParts[0]),
                            Probability = decimal.Parse(distributionParts[1]),
                        });
                        lineIndex++;


                    }
                }
                catch (Exception E) { };
                Servers.Add(new Server { TimeDistribution = serviceDistribution });
                lineIndex++;

            }
            

        }



        ///                                 MY MAIN                        ///
       ///            FIRST STEP TO FIND  CUMM TABLE FOR INTERARRIVAL  and servers           ///
       
        public void calculate_InterArrival_Table()
        {  
            for (int i = 0; i < InterarrivalDistribution.Count; i++)
            {
                // Inter arrival
                if (i == 0)
                {
                    InterarrivalDistribution[i].CummProbability = InterarrivalDistribution[i].Probability;
                }
                else
                {
                    InterarrivalDistribution[i].CummProbability = InterarrivalDistribution[i].Probability + InterarrivalDistribution[i - 1].CummProbability;
                    InterarrivalDistribution[i].MinRange = InterarrivalDistribution[i - 1].MaxRange;
                }
                InterarrivalDistribution[i].MaxRange = (int)(InterarrivalDistribution[i].CummProbability * 100);
            }
        }
        public void calculate_cummulative_for_Servers()
        { for (int i = 0; i < NumberOfServers; i++)
            {
                for (int j = 0; j < Servers[i].TimeDistribution.Count; j++) {
                    if (j == 0)
                    {
                        Servers[i].TimeDistribution[j].CummProbability = Servers[i].TimeDistribution[j].Probability;
                    }
                    else
                    {
                        Servers[i].TimeDistribution[j].CummProbability = Servers[i].TimeDistribution[j].Probability + Servers[i].TimeDistribution[j - 1].CummProbability;
                        Servers[i].TimeDistribution[j].MinRange = Servers[i].TimeDistribution[j - 1].MaxRange;        
                    }
                    Servers[i].TimeDistribution[j].MaxRange = (int)(Servers[i].TimeDistribution[j].CummProbability * 100);
                }
             }
        }



        //                      Give Each Server and customer  an ID            ////
        public void calculate_Server_Id()
        {
            for (int i = 0; i < NumberOfServers; i++)
            {
                Servers[i].ID = i + 1;
            }
        }   
        // A
        public void customer_id(int i)
        {
            SimulationTable[i].CustomerNumber = ++i;
        }


        ///      Find Random interarrival time
        ///      Assign interarrival time       
        ///      Find Random service time
        ///      B   &   C   &   E
        public void find_interarrival(int i)
        {

                Random r = new Random();
                int random_Num = r.Next(0, 90);
            Random k = new Random();
            int random_Num_2 = k.Next(0, 90);
                SimulationTable[i].RandomInterArrival = random_Num;
                SimulationTable[i].RandomService = random_Num_2;
                for (int J = 0; J < InterarrivalDistribution.Count(); J++)
                    {
                        if (InterarrivalDistribution[J].MinRange < random_Num && InterarrivalDistribution[J].MaxRange >= random_Num)
                        {
                            SimulationTable[i].InterArrival = InterarrivalDistribution[J].Time;
                            break;
                        }
                    }   
                }

        ///                  Arrival Time                  ///
        ///                  D
        public void CalcArrivalTime(int i)
        {
            if (i == 0)
            {
                SimulationTable[i].ArrivalTime = 0;
            }
            else
            {
                SimulationTable[i].ArrivalTime = SimulationTable[i].InterArrival + SimulationTable[i - 1].ArrivalTime;
            }
            
        }

        ///                  Server choosing      ///
        public void ChooseServer(SimulationCase customer)
        {

            if (SelectionMethod.ToString().Equals("HighestPriority"))
            {
                int min, i;
                min =i = 0;
                // if there is an empty one  enter utomatically to ....
                for (i = 0; i < NumberOfServers; i++)
                {
                    if (Servers[min].FinishTime > Servers[i].FinishTime)
                        min = i;

                    if (Servers[i].FinishTime <= customer.ArrivalTime)
                    {
                        customer.AssignedServer = Servers[i];
                        customer.StartTime = customer.ArrivalTime;
                        break;
                    }
                    // if no empty and he has to wait untill one is empty 
                    else
                    {
                        customer.AssignedServer = Servers[min];
                    }

                }
            }
            else if (SelectionMethod.ToString().Equals("Random"))
            {

                List<int> emptyservers = new List<int>();
                for (int i = 0; i < NumberOfServers; i++) // if all servers are full
                {
                    if (Servers[i].FinishTime <= customer.ArrivalTime)
                        emptyservers.Add(i);
                }
                Random random = new Random();
                int randomNumber = random.Next(0, emptyservers.Count);

                customer.AssignedServer = Servers[randomNumber];

            }
           
        }
        //         Find Service Time 
        //         Find End Time 
        //         G & H
        public void Service_time(SimulationCase customer, Server  Current_Server)
        {
                
                for (int J = 0; J < Current_Server.TimeDistribution.Count(); J++)
                {
                    if (Current_Server.TimeDistribution[J].MinRange < customer.RandomService && Current_Server.TimeDistribution[J].MaxRange >= customer.RandomService)
                    {
                    customer.ServiceTime = Current_Server.TimeDistribution[J].Time;
                        break;
                    }
                }
           

        }
        ///     Find end Time of both  Server and System 
        ///     H
        public void CalcEndTime(int i)
        {
            if (i == 0)
            {
                SimulationTable[i].EndTime = SimulationTable[i].ServiceTime;
                SimulationTable[i].AssignedServer.FinishTime = SimulationTable[i].ServiceTime;
            }
            else
            {
                SimulationTable[i].EndTime = SimulationTable[i].StartTime + SimulationTable[i].ServiceTime;
                SimulationTable[i].AssignedServer.FinishTime = SimulationTable[i].StartTime + SimulationTable[i].ServiceTime;
            }
        }

        public void CalcTimeInQueue(int i)
        {     
                if (i == 0)
                {
                    SimulationTable[i].TimeInQueue = 0;
                }
                else if (SimulationTable[i - 1].EndTime > SimulationTable[i].ArrivalTime)
                {
                    SimulationTable[i].TimeInQueue = SimulationTable[i - 1].EndTime - SimulationTable[i].ArrivalTime;
                }
                else
                {
                    SimulationTable[i].TimeInQueue = 0;
                }          
        }
         
       
        public void all()
        {
            calculate_InterArrival_Table();
            calculate_cummulative_for_Servers();
            calculate_Server_Id();

            for (int i = 0; i < StoppingNumber ; i++)
            {
                SimulationTable.Add(new SimulationCase());
                customer_id(i);
                find_interarrival(i);
                CalcArrivalTime(i);
                ChooseServer(SimulationTable[i]);
                Service_time(SimulationTable[i], SimulationTable[i].AssignedServer);
                CalcEndTime(i);
                CalcTimeInQueue(i);
            }
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
