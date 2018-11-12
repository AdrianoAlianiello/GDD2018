using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Support.Forms;

namespace PalcoNet.Abm_Cliente
{
    public partial class ctrlCliente : UserControl
    {
        public ctrlCliente()
        {
            InitializeComponent();
        }

        private void ctrlCliente_Load(object sender, EventArgs e)
        {
            ConfigureInputs();
        }

        private void ConfigureInputs()
        {
            Inputs.NotNumeric(tbNombre);
            Inputs.SetMaxLength(tbNombre, 255);

            Inputs.NotNumeric(tbApellido);
            Inputs.SetMaxLength(tbApellido, 255);

            Inputs.NotNumeric(tbTipoDocumento);
            Inputs.SetMaxLength(tbTipoDocumento, 255);

            Inputs.OnlyNumericInt(tbNumeroDocumento);
            Inputs.SetMaxLength(tbNumeroDocumento, 18);

            Inputs.OnlyNumericInt(tbCuil);
            Inputs.SetMaxLength(tbCuil, 11);

        }

        private void tbNombre_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
