using Entities.DTOs;
using Services;
using System;
using System.Windows.Forms;

namespace PalcoNet.Abm_Cliente
{
    public partial class frmListadoClientes : Form
    {
        private readonly ClientService _clientService = new ClientService();
        public frmListadoClientes()
        {
            InitializeComponent();
        }

        private void frmListadoClientes_Load(object sender, EventArgs e)
        {
            ShowClientes();
        }

        private void ShowClientes()
        {
            dgvClientes.DataSource = _clientService.GetAll(GetCurrentFilters());
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
            return new ClienteFiltroDTO();
        }

        private void ShowColumn(string columnName, string columnTitle, string format = null)
        {
            dgvClientes.Columns[columnName].Visible = true;
            dgvClientes.Columns[columnName].HeaderText = columnTitle;
            if (format != null)
                dgvClientes.Columns[columnName].DefaultCellStyle.Format = format;
        }
    }
}
