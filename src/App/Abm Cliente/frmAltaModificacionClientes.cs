using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Abm_Cliente
{
    public partial class frmAltaModificacionClientes : Form
    {
        private readonly ClienteDTO _clienteDTO;
        private readonly frmMain _parent;
        public frmAltaModificacionClientes(frmMain parent, ClienteDTO clienteDTO = null)
        {
            _clienteDTO = clienteDTO;
            _parent = parent;
            InitializeComponent();
        }

        private void frmAltaModificacionClientes_Load(object sender, EventArgs e)
        {
            var ctrlCliente = new ctrlCliente(_parent, _clienteDTO);
            panel.Controls.Add(ctrlCliente);
        }
    }
}
