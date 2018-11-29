using Entities.DTOs;
using Services;
using System;
using System.Windows.Forms;

namespace PalcoNet.Abm_Cliente
{
    public partial class frmListadoClientes : Form
    {
        private readonly ClientService _clientService = new ClientService();
        private readonly frmMain _parent;

        public frmListadoClientes(frmMain parent)
        {
            _parent = parent;
            InitializeComponent();
        }

        private void frmListadoClientes_Load(object sender, EventArgs e)
        {
            ShowClientes();
        }

        private void ShowClientes()
        {
            var source = _clientService.GetAll(GetCurrentFilters());
            dgvClientes.DataSource = source;
            foreach (DataGridViewColumn column in dgvClientes.Columns)
                column.Visible = false;
            ShowColumn("Nombre", "Nombre");
            ShowColumn("Apellido", "Apellido");
            ShowColumn("TipoDocumento", "Tipo Documento");
            ShowColumn("NumeroDocumento", "Número Documento");
            ShowColumn("Cuil", "CUIL");
            ShowColumn("Email", "Email");
            ShowColumn("Estado", "Estado");
        }

        private ClienteFiltroDTO GetCurrentFilters()
        {
            return new ClienteFiltroDTO()
            {
                Apellido = tbApellido.Text,
                Nombre = tbNombre.Text,
                Dni = tbDNI.Text,
                Mail = tbMail.Text
            };
        }

        private void ShowColumn(string columnName, string columnTitle, string format = null)
        {
            dgvClientes.Columns[columnName].Visible = true;
            dgvClientes.Columns[columnName].HeaderText = columnTitle;
            if (format != null)
                dgvClientes.Columns[columnName].DefaultCellStyle.Format = format;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ShowClientes();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            CleanFilters();
        }

        private void CleanFilters()
        {
            tbNombre.Text = string.Empty;
            tbApellido.Text = string.Empty;
            tbDNI.Text = string.Empty;
            tbMail.Text = string.Empty;
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            var frmAltaModificacion = new frmAltaModificacionClientes(_parent);
            _parent.OpenChildForm(frmAltaModificacion, this);
        }
    }
}
