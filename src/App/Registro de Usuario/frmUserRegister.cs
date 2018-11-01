using Entities;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Registro_de_Usuario
{
    public partial class frmUserRegister : Form
    {
        private readonly frmMain _parent;

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
    }
}
