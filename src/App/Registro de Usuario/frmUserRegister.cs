using Entities;
using PalcoNet.Abm_Cliente;
using Services;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using static Support.Constants.Configuration;

namespace PalcoNet.Registro_de_Usuario
{
    public partial class frmUserRegister : Form
    {
        private readonly frmMain _parent;
        private ctrlCliente _ctrCliente;

        public frmUserRegister(frmMain parent)
        {
            _parent = parent;
            InitializeComponent();
        }

        private void frmUserRegister_Load(object sender, EventArgs e)
        {
            LoadCboRoles();
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
            if (((Rol)cboRoles.SelectedItem).Nombre == ROLE_CLIENT_NAME)
                ShowClientForm();
            else if (((Rol)cboRoles.SelectedItem).Nombre == ROLE_COMPANY_NAME)
                ShowCompanyForm();

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

        private void container_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            _ctrCliente.Save();
        }
    }
}
