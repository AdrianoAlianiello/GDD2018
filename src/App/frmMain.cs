using Entities;
using PalcoNet.Login;
using Services;
using Support;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using static Support.Constants.Configuration;

namespace PalcoNet
{
    public partial class frmMain : Form
    {
        private Form _previousForm;

        public frmMain()
        {
            InitializeComponent();
        }

        private void HideMenu()
        {
            foreach(ToolStripMenuItem item in mainMenu.Items)
            {
                item.Visible = false;
                foreach (ToolStripItem childItem in item.DropDownItems)
                    childItem.Visible = false;
            }
        }

        private void LoadWallpaper()
        {
            BackgroundImage = Properties.Resources.TheatreWallpaper;
            BackgroundImageLayout = ImageLayout.Stretch;
        }

        public void LoadMenues()
        {
            mainMenu.Visible = true;
            LoadMenuesByFunctionalities();
        }

        private void LoadMenuesByFunctionalities()
        {
            var functionalities = CurrentUser.Functionalities;

            if (functionalities.Contains(FUNCTIONALITY_CREATE_CLIENT))
                ShowItemMenu(mainMenuClientesAlta);
            /*if (functionalities.Contains(FUNCTIONALITY_MODIFY_CLIENT))
                ShowItemMenu(submenuClientesModificacion);
            if (functionalities.Contains(FUNCTIONALITY_REMOVE_CLIENT))
                ShowItemMenu(submenuClientesBaja);*/
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            LoadWallpaper();
            HideMenu();
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

        private void ShowItemMenu(ToolStripMenuItem menu)
        {
            var parent = ((ToolStripDropDown)menu.GetCurrentParent()).OwnerItem;
            if (!parent.Visible)
                parent.Visible = true;
            menu.Visible = true;
        }

        public void BackToPreviousForm(Form callingForm)
        {
            if(_previousForm != null)
            {
                callingForm.Close();
                _previousForm.Show();
            }
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
