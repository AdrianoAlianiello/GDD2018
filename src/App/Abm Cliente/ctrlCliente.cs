using Entities;
using Entities.DTOs;
using Entities.Views;
using Services;
using Support;
using Support.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using static Support.Constants.Messages;

namespace PalcoNet.Abm_Cliente
{
    public partial class ctrlCliente : UserControl
    {
        private readonly ClienteDTO _clienteDTO = new ClienteDTO();
        private readonly frmMain _parent;
        private readonly ClientService _clientService;

        public ClienteDTO GetCurrentClient()
        {
            return _clienteDTO;
        }

        public ctrlCliente(frmMain parent, ClienteDTO clienteDTO = null)
        {
            InitializeComponent();
            _clientService = new ClientService();
            _parent = parent;

            if (clienteDTO != null)
            {
                _clienteDTO = clienteDTO;
                SetFormData();
            }
        }

        private void SetFormData()
        {
            tbApellido.Text = _clienteDTO.Cliente.Apellido;
            tbNombre.Text = _clienteDTO.Cliente.Nombre;
            tbTipoDocumento.Text = _clienteDTO.Cliente.TipoDocumento;
            tbNumeroDocumento.Text = _clienteDTO.Cliente.NroDocumento.ToString();
            tbCuil.Text = _clienteDTO.Cliente.Cuil.ToString();
            tbMail.Text = _clienteDTO.Cliente.Mail;
            tbTelefono.Text = _clienteDTO.Cliente.Telefono.ToString();
            dtpFechaNacimiento.Value = _clienteDTO.Cliente.FechaNacimiento;
            tbCalle.Text = _clienteDTO.Cliente.DomicilioCalle;
            tbNumero.Text = _clienteDTO.Cliente.DomicilioNro.ToString();
            tbPiso.Text = _clienteDTO.Cliente.DomicilioPiso.ToString();
            tbDepto.Text = _clienteDTO.Cliente.DomicilioDepto;
            tbLocalidad.Text = _clienteDTO.Cliente.DomicilioLocalidad;
            ShowTarjetas();
        }

        public void ShowTarjetas()
        {
            dgvTarjetas.DataSource = GetDataSourceTarjetas();
            foreach (DataGridViewColumn column in dgvTarjetas.Columns)
                column.Visible = false;
            ShowColumn("TipoNombre", "Emisora");
            ShowColumn("Numero", "Numero");
            ShowColumn("Titular", "Titular");
            ShowColumn("FechaVto", "Vencimiento", "MM/yy");
            EnableOrDisableTarjetasButtons();
        }

        private void ShowColumn(string columnName, string columnTitle, string format = null)
        {
            dgvTarjetas.Columns[columnName].Visible = true;
            dgvTarjetas.Columns[columnName].HeaderText = columnTitle;
            if(format != null)
                dgvTarjetas.Columns[columnName].DefaultCellStyle.Format = format;
        }

        public List<TarjetaView> GetDataSourceTarjetas()
        {
            return _clienteDTO.Tarjetas.Select(t =>
            {
                return new TarjetaView()
                {
                    Id = t.Tarjeta.Id,
                    TipoId = t.Tipo.Id,
                    TipoNombre = t.Tipo.Descripcion,
                    FechaVto = t.Tarjeta.FechaVencimiento,
                    Numero = t.Tarjeta.Numero,
                    Titular = t.Tarjeta.NombreTitular
                };
            }).ToList();
        }

        private void EnableOrDisableTarjetasButtons()
        {
            btnEliminarTarjeta.Enabled = false;
            if(dgvTarjetas.Rows.Count > 0)
                btnEliminarTarjeta.Enabled = true;
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

            Inputs.NotSeparated(tbMail);
            Inputs.SetMaxLength(tbMail, 255);

            Inputs.OnlyNumericInt(tbTelefono);
            Inputs.SetMaxLength(tbTelefono, 18);

            Inputs.DtpSetBounds(dtpFechaNacimiento, DateTime.Today.AddYears(-110), DateTime.Today);

            Inputs.NotNumeric(tbCalle);
            Inputs.SetMaxLength(tbCalle, 255);

            Inputs.OnlyNumericInt(tbNumero);
            Inputs.SetMaxLength(tbNumero, 18);

            Inputs.OnlyNumericInt(tbPiso);
            Inputs.SetMaxLength(tbPiso, 18);

            Inputs.LetterOrDigit(tbDepto);
            Inputs.SetMaxLength(tbDepto, 255);

            Inputs.LetterOrDigit(tbCodPostal);
            Inputs.SetMaxLength(tbCodPostal, 255);

            Inputs.LetterOrDigit(tbLocalidad);
            Inputs.SetMaxLength(tbLocalidad, 255);
        }

        public void Save()
        {
            if(ValidateInputs())
            {
                try
                {
                    BindFormData();
                    _clientService.Save(_clienteDTO);
                }
                catch (Exception ex)
                {
                    Alerts.ShowWarning(ex.Message);
                }
            }
        }

        public bool PrepareSave()
        {
            if (ValidateInputs())
            {
                BindFormData();
                return true;
            }
            return false;
        }

        private void BindFormData()
        {
            _clienteDTO.Cliente.Nombre = tbNombre.Text;
            _clienteDTO.Cliente.Apellido = tbApellido.Text;
            _clienteDTO.Cliente.TipoDocumento = tbTipoDocumento.Text;
            _clienteDTO.Cliente.NroDocumento = Convert.ToInt64(tbNumeroDocumento.Text);
            _clienteDTO.Cliente.Cuil = Convert.ToInt64(tbCuil.Text);
            _clienteDTO.Cliente.Mail = tbMail.Text;
            _clienteDTO.Cliente.Telefono = Convert.ToInt64(tbTelefono.Text);
            _clienteDTO.Cliente.FechaNacimiento = dtpFechaNacimiento.Value;
            _clienteDTO.Cliente.DomicilioCalle = tbCalle.Text;
            _clienteDTO.Cliente.DomicilioNro = Convert.ToInt64(tbNumero.Text);
            _clienteDTO.Cliente.DomicilioPiso = Convert.ToInt64(tbPiso.Text);
            _clienteDTO.Cliente.DomicilioDepto = tbDepto.Text;
            _clienteDTO.Cliente.DomicilioCodPostal = tbCodPostal.Text;
            _clienteDTO.Cliente.DomicilioLocalidad = tbLocalidad.Text;
            var tarjetas = (List<TarjetaView>)dgvTarjetas.DataSource;
            _clienteDTO.Tarjetas = tarjetas.Select(t => new TarjetaCreditoDTO()
            {
                Tarjeta = new TarjetaCredito()
                {
                    Id = t.Id,
                    NombreTitular = t.Titular,
                    FechaVencimiento = t.FechaVto,
                    Numero = t.Numero,
                    TipoId = t.TipoId
                }
            }).ToList();
        }

        private bool ValidateInputs()
        {
            if (Validate(Validator.ValidateNotEmptyString(tbNombre.Text), MSG_CLIENT_NAME_EMPTY) || 
                Validate(Validator.ValidateNotEmptyString(tbApellido.Text), MSG_CLIENT_SURNAME_EMPTY) ||
                Validate(Validator.ValidateNotEmptyString(tbTipoDocumento.Text), MSG_CLIENT_IDENTIFICATION_DOCUMENT_TYPE_EMPTY) ||
                Validate(Validator.ValidateNotEmptyString(tbNumeroDocumento.Text), MSG_CLIENT_IDENTIFICATION_DOCUMENT_NUMBER_EMPTY) ||
                Validate(Validator.ValidateNotEmptyString(tbCuil.Text), MSG_CLIENT_CUIL_EMPTY) ||
                Validate(Validator.ValidateNotEmptyString(tbMail.Text), MSG_CLIENT_MAIL_EMPTY) ||
                Validate(Validator.ValidateNotEmptyString(tbTelefono.Text), MSG_CLIENT_PHONE_EMPTY) ||
                Validate(Validator.ValidateNotEmptyDate(dtpFechaNacimiento.Value), MSG_CLIENT_BIRTHDATE_EMPTY) ||
                Validate(Validator.ValidateNotEmptyString(tbCalle.Text), MSG_CLIENT_ADDRESS_STREET_EMPTY) ||
                Validate(Validator.ValidateNotEmptyString(tbNumero.Text), MSG_CLIENT_ADDRESS_NUMBER_EMPTY) ||
                Validate(Validator.ValidateNotEmptyString(tbPiso.Text), MSG_CLIENT_ADDRESS_FLOOR_EMPTY) ||
                Validate(Validator.ValidateNotEmptyString(tbDepto.Text), MSG_CLIENT_ADDRESS_DEPARTMENT_EMPTY) ||
                Validate(Validator.ValidateNotEmptyString(tbCodPostal.Text), MSG_CLIENT_ADDRESS_POSTAL_CODE_EMPTY) ||
                Validate(Validator.ValidateNotEmptyString(tbLocalidad.Text), MSG_CLIENT_ADDRESS_CITY_EMPTY) ||
                Validate(Validator.ValidateMailAddress(tbMail.Text), MSG_CLIENT_MAIL_INVALID) ||
                Validate(Validator.ValidateNotEmptyCollection((List<TarjetaView>)dgvTarjetas.DataSource), MSG_CLIENT_CREDIT_CARD_EMPTY))
                return false;
            return true;
        }

        private bool Validate(bool result, string msgWarning)
        {
            if (!result)
                Alerts.ShowWarning(msgWarning);
            return !result;
        }

        private void btnAgregarTarjeta_Click(object sender, EventArgs e)
        {
            _parent.OpenDialogForm(new frmCreditCard(_parent, this));
        }

        private void btnEliminarTarjeta_Click(object sender, EventArgs e)
        {
            var cardSelected = (TarjetaView)dgvTarjetas.SelectedRows[0].DataBoundItem;
            var toDelete = _clienteDTO.Tarjetas.Find(t => t.Tarjeta.TipoId == cardSelected.TipoId && t.Tarjeta.Numero == cardSelected.Numero);
            _clienteDTO.Tarjetas.Remove(toDelete);
            ShowTarjetas();
        }

        public void AddCreditCard(TarjetaCreditoDTO card)
        {
            _clienteDTO.Tarjetas.Add(card);
            ShowTarjetas();
        }

        public bool VerifyIsCreditCardExist(TarjetaCreditoDTO card)
        {
            return _clienteDTO.Tarjetas.Where(t => t.Tarjeta.Numero == card.Tarjeta.Numero).Count() > 0;
        }
    }
}
