using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Data;

namespace IceCreamListsPart2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you'd like to clear the file?", "Cones 'R Us",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                // Erase contents of file
                FileStream clearFile = File.OpenWrite("orders.txt");
                clearFile.SetLength(0);

                // Clear the form
                lbxOrders.Items.Clear();
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string order;

            try
            {
                // Open the orders.txt file
                StreamReader orderFile = File.OpenText("orders.txt");

                while (!orderFile.EndOfStream)
                {
                    // Display the contents of the file
                    order = orderFile.ReadLine();
                    lbxOrders.Items.Add(order);
                }

                orderFile.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Cones 'R Us",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }
    }
}
