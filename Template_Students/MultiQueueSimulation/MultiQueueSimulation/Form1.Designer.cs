using System;
using System.Windows.Forms;
using System.Collections.Generic;
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
            this.SuspendLayout();
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion
    }
}
namespace DataInsertWithoutDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a list to store data
            List<Dictionary<string, object>> table = new List<Dictionary<string, object>>();

            // Create a dictionary to represent a row of data
            Dictionary<string, object> row1 = new Dictionary<string, object>
            {
                { "Column1", "Value1" },
                { "Column2", 123 },
                { "Column3", true }
            };

            // Add the row to the table
            table.Add(row1);

            // You can add more rows similarly
            Dictionary<string, object> row2 = new Dictionary<string, object>
            {
                { "Column1", "Value2" },
                { "Column2", 456 },
                { "Column3", false }
            };
            table.Add(row2);

            // Print the table
            foreach (var row in table)
            {
                foreach (var kvp in row)
                {
                    Console.WriteLine($"{kvp.Key}: {kvp.Value}");
                }
                Console.WriteLine();
            }
        }
    }
}

