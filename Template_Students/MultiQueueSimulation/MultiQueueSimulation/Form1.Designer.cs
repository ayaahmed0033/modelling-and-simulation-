using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Windows.Forms.DataVisualization.Charting;
namespace MultiQueueSimulation
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
      

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.testcase1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.Utilization = new System.Windows.Forms.TextBox();
            this.AverageServiceTime = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.IdleProbability = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.textBoxProbabilitywait = new System.Windows.Forms.TextBox();
            this.textBoxMaxQueueLength = new System.Windows.Forms.TextBox();
            this.textBoxAverageWaitingTime = new System.Windows.Forms.TextBox();
            this.prob = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.average_waiting_time = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.display = new System.Windows.Forms.Button();
            this.chartServerBusyTime = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartServerBusyTime)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 11);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1099, 462);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.testcase1);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Size = new System.Drawing.Size(1091, 433);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // testcase1
            // 
            this.testcase1.Location = new System.Drawing.Point(63, 28);
            this.testcase1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.testcase1.Name = "testcase1";
            this.testcase1.Size = new System.Drawing.Size(107, 23);
            this.testcase1.TabIndex = 1;
            this.testcase1.Text = "show";
            this.testcase1.UseVisualStyleBackColor = true;
            this.testcase1.Click += new System.EventHandler(this.testcase1_Click_2);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(5, 63);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(899, 345);
            this.dataGridView1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.Utilization);
            this.tabPage2.Controls.Add(this.AverageServiceTime);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.IdleProbability);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.textBoxProbabilitywait);
            this.tabPage2.Controls.Add(this.textBoxMaxQueueLength);
            this.tabPage2.Controls.Add(this.textBoxAverageWaitingTime);
            this.tabPage2.Controls.Add(this.prob);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.average_waiting_time);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Size = new System.Drawing.Size(1091, 433);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(128, 361);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 294);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(164, 16);
            this.label4.TabIndex = 13;
            this.label4.Text = "Utilization  per each server";
            // 
            // Utilization
            // 
            this.Utilization.Location = new System.Drawing.Point(273, 291);
            this.Utilization.Name = "Utilization";
            this.Utilization.Size = new System.Drawing.Size(100, 22);
            this.Utilization.TabIndex = 12;
            // 
            // AverageServiceTime
            // 
            this.AverageServiceTime.Location = new System.Drawing.Point(273, 252);
            this.AverageServiceTime.Name = "AverageServiceTime";
            this.AverageServiceTime.Size = new System.Drawing.Size(100, 22);
            this.AverageServiceTime.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 252);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(236, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = " AverageServiceTime per each server";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 216);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(193, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = " IdleProbability per each server";
            // 
            // IdleProbability
            // 
            this.IdleProbability.Location = new System.Drawing.Point(273, 210);
            this.IdleProbability.Name = "IdleProbability";
            this.IdleProbability.Size = new System.Drawing.Size(100, 22);
            this.IdleProbability.TabIndex = 8;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(128, 155);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // textBoxProbabilitywait
            // 
            this.textBoxProbabilitywait.Location = new System.Drawing.Point(208, 97);
            this.textBoxProbabilitywait.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxProbabilitywait.Name = "textBoxProbabilitywait";
            this.textBoxProbabilitywait.Size = new System.Drawing.Size(100, 22);
            this.textBoxProbabilitywait.TabIndex = 6;
            // 
            // textBoxMaxQueueLength
            // 
            this.textBoxMaxQueueLength.Location = new System.Drawing.Point(208, 58);
            this.textBoxMaxQueueLength.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxMaxQueueLength.Name = "textBoxMaxQueueLength";
            this.textBoxMaxQueueLength.Size = new System.Drawing.Size(100, 22);
            this.textBoxMaxQueueLength.TabIndex = 5;
            // 
            // textBoxAverageWaitingTime
            // 
            this.textBoxAverageWaitingTime.Location = new System.Drawing.Point(208, 18);
            this.textBoxAverageWaitingTime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxAverageWaitingTime.Name = "textBoxAverageWaitingTime";
            this.textBoxAverageWaitingTime.Size = new System.Drawing.Size(100, 22);
            this.textBoxAverageWaitingTime.TabIndex = 4;
            this.textBoxAverageWaitingTime.TextChanged += new System.EventHandler(this.textBoxAverageWaitingTime_TextChanged);
            // 
            // prob
            // 
            this.prob.AutoSize = true;
            this.prob.Location = new System.Drawing.Point(28, 97);
            this.prob.Name = "prob";
            this.prob.Size = new System.Drawing.Size(94, 16);
            this.prob.TabIndex = 3;
            this.prob.Text = "Probabilitywait";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = " MaxQueueLength";
            // 
            // average_waiting_time
            // 
            this.average_waiting_time.AutoSize = true;
            this.average_waiting_time.Location = new System.Drawing.Point(28, 22);
            this.average_waiting_time.Name = "average_waiting_time";
            this.average_waiting_time.Size = new System.Drawing.Size(138, 16);
            this.average_waiting_time.TabIndex = 1;
            this.average_waiting_time.Text = "average_waiting_time";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.display);
            this.tabPage3.Controls.Add(this.chartServerBusyTime);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage3.Size = new System.Drawing.Size(1091, 433);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // display
            // 
            this.display.Location = new System.Drawing.Point(964, 383);
            this.display.Margin = new System.Windows.Forms.Padding(4);
            this.display.Name = "display";
            this.display.Size = new System.Drawing.Size(100, 28);
            this.display.TabIndex = 1;
            this.display.Text = "display";
            this.display.UseVisualStyleBackColor = true;
            this.display.Click += new System.EventHandler(this.display_Click);
            // 
            // chartServerBusyTime
            // 
            chartArea1.Name = "ChartArea1";
            this.chartServerBusyTime.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartServerBusyTime.Legends.Add(legend1);
            this.chartServerBusyTime.Location = new System.Drawing.Point(44, 25);
            this.chartServerBusyTime.Margin = new System.Windows.Forms.Padding(4);
            this.chartServerBusyTime.Name = "chartServerBusyTime";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "series";
            this.chartServerBusyTime.Series.Add(series1);
            this.chartServerBusyTime.Size = new System.Drawing.Size(1020, 350);
            this.chartServerBusyTime.TabIndex = 0;
            this.chartServerBusyTime.Text = "chart1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1596, 820);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartServerBusyTime)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private DataGridView dataGridView1;
        private TabPage tabPage2;
        private Button button2;
        private TextBox textBoxProbabilitywait;
        private TextBox textBoxMaxQueueLength;
        private TextBox textBoxAverageWaitingTime;
        private Label prob;
        private Label label1;
        private Label average_waiting_time;
        private TabPage tabPage3;
        private Button testcase1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartServerBusyTime;
        private Button display;
        private TextBox IdleProbability;
        private Label label2;
        private Label label3;
        private TextBox AverageServiceTime;
        private Label label4;
        private TextBox Utilization;
        private Button button1;
    }
}


