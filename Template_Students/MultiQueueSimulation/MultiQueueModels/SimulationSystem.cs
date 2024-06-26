﻿using System;
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

                });

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
        {
            for (int i = 0; i < NumberOfServers; i++)
            {
                for (int j = 0; j < Servers[i].TimeDistribution.Count; j++)
                {
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
        private Random random = new Random();

        public int random_num()
        {
            return random.Next(1, 100);
        }


        ///      Find Random interarrival time
        ///      Assign interarrival time       
        ///      Find Random service time
        ///      B   &   C   &   E
        public void find_interarrival(int i)
        {
           
            int random_Num= random_num();
            int random_Num_2 = random_num();
            SimulationTable[i].RandomInterArrival = random_Num;
            SimulationTable[i].RandomService = random_Num_2;

            if (i == 0)
            {
                SimulationTable[i].InterArrival = 0;
                return;
            }
            else
            {
                for (int J = 0; J < InterarrivalDistribution.Count(); J++)
                {
                   
                    if (InterarrivalDistribution[J].MinRange < random_Num && InterarrivalDistribution[J].MaxRange >= random_Num)
                    {
                        SimulationTable[i].InterArrival = InterarrivalDistribution[J].Time;
                        break;
                    }
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

            int min, i;
            min = i = 0;
            if (SelectionMethod.ToString().Equals("HighestPriority"))
            {
                // if there is an empty one  enter utomatically to ....
                for (i = 0; i < NumberOfServers; i++)
                {
                    if (Servers[min].FinishTime > Servers[i].FinishTime)
                        min = i;

                    if (Servers[i].FinishTime <= customer.ArrivalTime)
                    {
                        customer.AssignedServer = Servers[i];
                        customer.StartTime = customer.ArrivalTime;
                        customer.TimeInQueue = 0;
                        break;
                    }
                    // if no empty and he has to wait untill one is empty 
                    else
                    {
                        customer.AssignedServer = Servers[min];
                        customer.StartTime = Servers[min].FinishTime;
                        customer.TimeInQueue = customer.StartTime - customer.ArrivalTime;


                    }
                }
            }
            else 
            {

                List<int> emptyservers = new List<int>();
                for (i = 0; i < NumberOfServers; i++) // if all servers are full
                {
                    if (Servers[min].FinishTime > Servers[i].FinishTime)
                        min = i;

                    if (Servers[i].FinishTime <= customer.ArrivalTime)
                        emptyservers.Add(i);

                }
                int length = emptyservers.Count;
                if (length == 0)
                {
                    customer.AssignedServer = Servers[min];
                    customer.StartTime = Servers[min].FinishTime;
                    customer.TimeInQueue = customer.StartTime - customer.ArrivalTime;

                }
                else
                {
                    Random random = new Random();
                    int randomNumber = random.Next(0, emptyservers.Count);
                    customer.AssignedServer = Servers[randomNumber];
                    customer.StartTime = customer.ArrivalTime;
                    customer.TimeInQueue = 0;


                }
            }


        }
        //         Find Service Time 
        //         Find End Time 
        //         G & H
        public void Service_time(SimulationCase customer, Server Current_Server)
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

        //               PERFORMANCE FUNCTIONS                        // 
        public void average_waiting_time(SimulationCase customer)
        {
            total_waiting_time += customer.TimeInQueue;
   
        }
       
        public void probabilitywait(SimulationCase customer)
        {
            if (customer.TimeInQueue != 0)
            {
                number_customers_waiting++;
            }

        }

        public void MaxQueueLength(SimulationCase customer, int i)
        {
            if(customer.TimeInQueue!=0)
            PerformanceMeasures.MaxQueueLength++;
        }
        public void averageServiceTime(SimulationCase customer)
        {
            customer.AssignedServer.TotalWorkingTime += customer.ServiceTime;
            customer.AssignedServer.nu_customer_went_in++;
        }
        public void find_run_time(SimulationCase customer)
        {
            sys_run_time = Math.Max(sys_run_time, customer.EndTime);
        }
        // OUR MAIN
        public void all()
        {
            calculate_InterArrival_Table();
            calculate_cummulative_for_Servers();
            calculate_Server_Id();

            for (int i = 0; i < StoppingNumber; i++)
            {
                SimulationTable.Add(new SimulationCase());
                customer_id(i);
                find_interarrival(i);
                CalcArrivalTime(i);
                ChooseServer(SimulationTable[i]);
                Service_time(SimulationTable[i], SimulationTable[i].AssignedServer);
                CalcEndTime(i);

                // performance
                average_waiting_time(SimulationTable[i]);
                MaxQueueLength(SimulationTable[i], i);
                probabilitywait(SimulationTable[i]);
                averageServiceTime(SimulationTable[i]);
                find_run_time(SimulationTable[i]);

            }
            performance();
        }
        public void performance()
        {
       PerformanceMeasures.AverageWaitingTime = total_waiting_time/ (decimal)(StoppingNumber);
               
        PerformanceMeasures.WaitingProbability = (decimal)(number_customers_waiting) / (decimal)(StoppingNumber);
          
            for (int i = 0; i < NumberOfServers; i++)
            {
                if (Servers[i].nu_customer_went_in != 0)
                {
                    Servers[i].AverageServiceTime = ((decimal)(Servers[i].TotalWorkingTime) / (decimal)(Servers[i].nu_customer_went_in));
                }
                if(sys_run_time != 0){ 
                  Servers[i].IdleProbability = (sys_run_time - (decimal)(Servers[i].TotalWorkingTime))/ sys_run_time;
                    Servers[i].Utilization = (decimal)(Servers[i].TotalWorkingTime) / sys_run_time;
                }
                

                    
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

        /// extra ///
         public static int number_customers_waiting { get; set; }
        public static decimal sys_run_time { get; set; }
        public static decimal total_waiting_time { get; set; }

    }
}
