using Entities;
using PalcoNet.Login;
using Services;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PalcoNet
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        public void LoadMenues()
        {

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            var login = new frmLogin(this);
            login.ShowDialog();
        }
    }
}
