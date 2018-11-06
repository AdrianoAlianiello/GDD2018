using Entities;
using Services;
using Support;
using System;
using System.Windows.Forms;

namespace PalcoNet.Login
{
    public partial class frmRoleSelection : Form
    {
        private readonly frmMain _parent;
        private readonly RoleService _roleService;
        private readonly LoginService _loginService;

        public frmRoleSelection(frmMain parent)
        {
            _parent = parent;
            _roleService = new RoleService();
            _loginService = new LoginService();
            InitializeComponent();
        }
      
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            var selectedRole = (Rol)(cboRoles.SelectedItem);
            _loginService.SelectRole(selectedRole);
            _parent.LoadMenues();
            _parent.CloseForm(this);
        }

        private void frmRoleSelection_Load(object sender, EventArgs e)
        {
            LoadRoles();
        }

        private void LoadRoles()
        {
            var userRoles = CurrentUser.Roles;
            var availableRoles = _roleService.GetRolesByName(userRoles);
            cboRoles.DataSource = availableRoles;
            cboRoles.ValueMember = "Id";
            cboRoles.DisplayMember = "Nombre";
        }
    }
}
