
using PalcoNet.Registro_de_Usuario;
using Support;
using System;
using System.Windows.Forms;
using static Support.Constants.Messages;

namespace PalcoNet.Login
{
    public partial class frmLogin : Form
    {
        private readonly frmMain _parent;

        public frmLogin(frmMain parent)
        {
            _parent = parent;
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            _parent.CloseApp();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void Login()
        {
            if (ValidateInputs())
            {
                try
                {
                    //SERVICIO
                    _parent.LoadMenues();
                    _parent.CloseForm(this);
                }
                catch(Exception ex)
                {
                    ShowMessage(ex.Message);
                }
            }
        }

        private bool ValidateInputs()
        {
            if(!Validator.ValidateNotEmpty(tbUsuario.Text))
            {
                ShowMessage(MSG_LOGIN_USERNAME_REQUIRED);
                return false;
            }
            else if(!Validator.ValidateNotEmpty(tbContrasenia.Text))
            {
                ShowMessage(MSG_LOGIN_PASSWORD_REQUIRED);
                return false;
            }
            return true;
        }

        private void ShowMessage(string message)
        {
            tbErrores.Visible = true;
            tbErrores.Text = message;
        }

        private void linkRegistrarUsuario_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegistrarUsuario();
        }

        private void RegistrarUsuario()
        {
            var registerForm = new frmUserRegister(_parent);
            _parent.OpenChildForm(registerForm, this);
        }
    }
}
