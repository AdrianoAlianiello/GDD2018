using Entities;
using Services;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PalcoNet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadDgv();
        }

        private void LoadDgv()
        {
            var data = new ExampleService().GetData();
            dgv.DataSource = data;
            dgv.Columns[0].HeaderText = "Apellido";
            dgv.Columns[1].HeaderText = "Cod. Postal";
        }
    }
}
