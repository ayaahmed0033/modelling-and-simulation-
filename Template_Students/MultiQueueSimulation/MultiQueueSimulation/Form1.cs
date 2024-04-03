using System;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using MultiQueueModels;

namespace MultiQueueSimulation
{
    public partial class Form1 : Form
    {
        private SimulationSystem simulationSystem;

        private string path;

        public Form1(SimulationSystem system, string path)
        {
            InitializeComponent();
            this.simulationSystem = system;
            this.path = path;

        }

        private void LoadTestCaseButton_Click(object sender, EventArgs e)
        {



            try
            {
                simulationSystem.test_num(path);
                MessageBox.Show("Test case loaded successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading test case: {ex.Message}");
            }
        }

        private void RunSimulationButton_Click(object sender, EventArgs e)
        {
            simulationSystem.all();
            DisplayResultsInDataGridView();
            DisplayPerformanceMetrics();
            //DrawServerBusyTimeChart();
        }

        private void DisplayResultsInDataGridView()
        {
            // Assuming you have a form with a DataGridView named dataGridView1
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            // Add columns to DataGridView
            dataGridView1.Columns.Add("CustomerNumber", "Customer Number");
            dataGridView1.Columns.Add("RandomInterArrival", "Random Digit for Inter-Arrival Time");
            dataGridView1.Columns.Add("InterArrival", "Inter-Arrival Time");
            dataGridView1.Columns.Add("ArrivalTime", "Arrival Time");
            dataGridView1.Columns.Add("RandomService", "Random Digit for Service Duration");
            dataGridView1.Columns.Add("ServiceTime", "Service Duration");
            dataGridView1.Columns.Add("AssignedServer", "Serve ID");
            dataGridView1.Columns.Add("StartTime", "Time Server Begins");
            dataGridView1.Columns.Add("EndTime", "Time Service Ends");

            dataGridView1.Columns.Add("TimeInQueue", "Time in Queue");




            // Add rows to DataGridView
            foreach (var simulationCase in simulationSystem.SimulationTable)
            {

                dataGridView1.Rows.Add(
               simulationCase.CustomerNumber,
               simulationCase.RandomInterArrival,
               simulationCase.InterArrival,
               simulationCase.ArrivalTime,
               simulationCase.RandomService,
               simulationCase.ServiceTime,
               simulationCase.AssignedServer.ID,
               simulationCase.StartTime,
               simulationCase.EndTime,
               simulationCase.TimeInQueue)
           ;
            }

           
            dataGridView1.Refresh();

        }
        private void DisplayPerformanceMetrics()
        {

            
            textBoxAverageWaitingTime.Text = simulationSystem.PerformanceMeasures.AverageWaitingTime.ToString();
            textBoxMaxQueueLength.Text = simulationSystem.PerformanceMeasures.MaxQueueLength.ToString();
            textBoxProbabilitywait.Text = simulationSystem.PerformanceMeasures.WaitingProbability.ToString();


        }


        private void DisplayPerformanceMetrics_perserver(int i)
        {
            if (i < simulationSystem.Servers.Count)
            {
                IdleProbability.Text = simulationSystem.Servers[i].IdleProbability.ToString();
                AverageServiceTime.Text = simulationSystem.Servers[i].AverageServiceTime.ToString();
                Utilization.Text = simulationSystem.Servers[i].Utilization.ToString();

            }
        }

            private void button3_Click(object sender, EventArgs e)
            {
                //DrawServerBusyTimeChart();
            }

            private void testcase1_Click(object sender, EventArgs e)
            {
                DisplayResultsInDataGridView();
            }

            private void button2_Click_1(object sender, EventArgs e)
            {
                DisplayPerformanceMetrics();
            }

            private void testcase1_Click_1(object sender, EventArgs e)
            {
                DisplayResultsInDataGridView();
            }

            private void DrawServerBusyTimeChart()
            {

                
                tabControl1.TabPages.Clear();

                
                for (int i = 0; i < simulationSystem.Servers.Count; i++)
                {
                    
                    TabPage tabPage = new TabPage($"Server {i + 1}");
                    tabPage.Name = $"tabPageServer{i + 1}";

                   
                    Chart chart = new Chart();
                    chart.Dock = DockStyle.Fill;
                    chart.ChartAreas.Add(new ChartArea($"ChartAreaServer{i + 1}"));
                    chart.Titles.Add($"Server {i + 1} Busy Time");
                    chart.ChartAreas[0].AxisX.Title = "Time";
                    chart.ChartAreas[0].AxisY.Title = "Busy";



                    
                    var series = new Series($"Server {i + 1}");
                    series["PixelPointWidth"] = "5";
                    series.ChartType = SeriesChartType.StackedColumn;

                    // Determine when each server is busy or idle and add data points to the series
                    foreach (var simulationCase in simulationSystem.SimulationTable)
                    {
                        if (simulationCase.AssignedServer.ID == i + 1)
                        {
                            // Add data points to display server as busy (1)
                            series.Points.AddXY(simulationCase.StartTime, 1);
                            series.Points.AddXY(simulationCase.EndTime, 0);
                        }
                        else
                        {
                            // Add data points to display server as idle (0)
                            series.Points.AddXY(simulationCase.StartTime, 0);
                            series.Points.AddXY(simulationCase.EndTime, 0);
                        }
                    }

                   
                    chart.Series.Add(series);

                   
                    tabPage.Controls.Add(chart);
                    tabControl1.TabPages.Add(tabPage);

                }

                // Set chart properties

            }

            private void display_Click(object sender, EventArgs e)
            {
                DrawServerBusyTimeChart();
            }
               public static int X;
            private void button1_Click(object sender, EventArgs e) { 
          
                DisplayPerformanceMetrics_perserver(X);
            X++;
            }

        private void testcase1_Click_2(object sender, EventArgs e)
        {
            DisplayResultsInDataGridView();
        }

        private void textBoxAverageWaitingTime_TextChanged(object sender, EventArgs e)
        {

        }
    }
    }
