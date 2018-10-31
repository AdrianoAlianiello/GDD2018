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
        private Form _previousForm;

        public frmMain()
        {
            InitializeComponent();
        }

        public void LoadMenues()
        {

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            ShowLogin();
        }

        private void ShowLogin()
        {
            var login = new frmLogin(this);
            OpenChildForm(login);
        }

        public void OpenChildForm(Form formToOpen, Form callingForm = null)
        {
            if(callingForm != null)
            {
                _previousForm = callingForm;
                _previousForm.Hide();
            }
            formToOpen.MdiParent = this;
            formToOpen.Show();
        }

        public void CloseForm(Form form)
        {
            form.Close();
        }

        public void CloseApp()
        {
            Close();
        }
    }
}
