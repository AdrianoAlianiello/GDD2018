using Entities;
using Entities.DTOs;
using PalcoNet.Abm_Cliente;
using Services;
using Support;
using Support.Forms;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using static Support.Constants.Configuration;
using static Support.Constants.Messages;

namespace PalcoNet.Registro_de_Usuario
{
    public partial class frmUserRegister : Form
    {
        private readonly frmMain _parent;
        private ctrlCliente _ctrCliente;
        private readonly ClienteRegistracionDTO _clienteRegistracionDTO = new ClienteRegistracionDTO();
        private readonly UserRegistrationService _userRegistrationService = new UserRegistrationService();

        public frmUserRegister(frmMain parent)
        {
            _parent = parent;
            InitializeComponent();
        }

        private void frmUserRegister_Load(object sender, EventArgs e)
        {
            LoadCboRoles();
            ConfigureInputs();
        }

        private void ConfigureInputs()
        {
            Inputs.NotSeparated(tbUsuario);
            Inputs.SetMaxLength(tbUsuario, 255);

            Inputs.NotSeparated(tbContrasenia);
            Inputs.SetMaxLength(tbContrasenia, 255);
        }

        private void LoadCboRoles()
        {
            cboRoles.DataSource = new RoleService().GetPublicRoles().OrderBy(rol => rol.Nombre).ToList();
            cboRoles.ValueMember = "Id";
            cboRoles.DisplayMember = "Nombre";
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Back();
        }

        private void Back()
        {
            _parent.BackToPreviousForm(this);
        }

        private void cboRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            RoleChanged();
        }

        private void RoleChanged()
        {
            CleanContainer();
            if (IsClient())
                ShowClientForm();
            else if (IsCompany())
                ShowCompanyForm();

        }

        private bool IsClient()
        {
            return ((Rol)cboRoles.SelectedItem).Nombre == ROLE_CLIENT_NAME;
        }

        private bool IsCompany()
        {
            return ((Rol)cboRoles.SelectedItem).Nombre == ROLE_COMPANY_NAME;
        }

        private void CleanContainer()
        {
            container.Controls.Clear();
        }

        private void ShowCompanyForm()
        {
            var companyCtrl = new ctrlEmpresa();
            container.Controls.Add(companyCtrl);

        }

        private void ShowClientForm()
        {
            _ctrCliente = new ctrlCliente(_parent);
            container.Controls.Add(_ctrCliente);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            if (ValidateInputs())
            {
                try
                {
                    if (IsClient())
                    {
                        if (_ctrCliente.PrepareSave())
                        {
                            BindClientFormData();
                            _userRegistrationService.RegisterClient(_clienteRegistracionDTO);
                            Alerts.ShowInfo(MSG_USER_REGISTRATION_SAVE_CLIENT_SUCESS);
                            _parent.BackToPreviousForm(this);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Alerts.ShowWarning(ex.Message);
                }
            }
        }

        private void BindClientFormData()
        {
            _clienteRegistracionDTO.Usuario.Username = tbUsuario.Text;
            _clienteRegistracionDTO.Usuario.Password = tbContrasenia.Text;
            _clienteRegistracionDTO.Roles.Add((Rol)cboRoles.SelectedItem);
            _clienteRegistracionDTO.ClienteDTO = _ctrCliente.GetCurrentClient();
        }

        private bool ValidateInputs()
        {
            if (Validate(Validator.ValidateNotEmptyString(tbUsuario.Text), MSG_USER_REGISTRATION_USERNAME_EMPTY) ||
                Validate(Validator.ValidateNotEmptyString(tbContrasenia.Text), MSG_USER_REGISTRATION_PASSWORD_EMPTY))
                return false;
            return true;
        }

        private bool Validate(bool result, string msgWarning)
        {
            if (!result)
                Alerts.ShowWarning(msgWarning);
            return !result;
        }
    }
}
