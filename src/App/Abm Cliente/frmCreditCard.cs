using Entities;
using Entities.DTOs;
using Services;
using Support;
using Support.Forms;
using System;
using System.Windows.Forms;
using static Support.Constants.Messages;

namespace PalcoNet.Abm_Cliente
{
    public partial class frmCreditCard : Form
    {
        private readonly CreditCardService _creditCardService;
        private readonly TarjetaCreditoDTO _tarjetaCreditoDTO = new TarjetaCreditoDTO();
        private readonly frmMain _parent;
        private readonly ctrlCliente _ctrlCliente;

        public frmCreditCard(frmMain parent, ctrlCliente ctrlCliente)
        {
            _parent = parent;
            _ctrlCliente = ctrlCliente;
            InitializeComponent();
            _creditCardService = new CreditCardService();
        }

        private void frmCreditCard_Load(object sender, EventArgs e)
        {
            LoadCboTypes();
            ConfigureInputs();
        }

        private void ConfigureInputs()
        {
            Inputs.NotNumeric(tbTitular);
            Inputs.SetMaxLength(tbTitular, 255);

            Inputs.OnlyNumericInt(tbNumero);
            Inputs.SetMaxLength(tbNumero, 18);

            Inputs.DtpSetBounds(dtpFechaVencimiento, DateTime.Today.AddDays(1), DateTime.Today.AddYears(10));
            dtpFechaVencimiento.CustomFormat = "MM/yy";

        }

        private void LoadCboTypes()
        {
            cboTipo.DataSource = _creditCardService.GetAllTypes();
            cboTipo.ValueMember = "Id";
            cboTipo.DisplayMember = "Descripcion";
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            _parent.CloseForm(this);
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
                    BindFormData();
                    if (_ctrlCliente.VerifyIsCreditCardExist(_tarjetaCreditoDTO))
                        Alerts.ShowWarning(MSG_CREDIT_CARD_EXISTING);
                    else
                    {
                        _ctrlCliente.AddCreditCard(_tarjetaCreditoDTO);
                        _parent.CloseForm(this);
                    }
                }
                catch (Exception ex)
                {
                    Alerts.ShowWarning(ex.Message);
                }
            }
        }

        private void BindFormData()
        {
            _tarjetaCreditoDTO.Tipo = (TipoTarjetaCredito)cboTipo.SelectedItem;
            _tarjetaCreditoDTO.Tarjeta = new TarjetaCredito()
            {
                NombreTitular = tbTitular.Text,
                FechaVencimiento = dtpFechaVencimiento.Value,
                Numero = Convert.ToInt64(tbNumero.Text),
                Activa = true,
                TipoId = _tarjetaCreditoDTO.Tipo.Id
            };
        }

        private bool Validate(bool result, string msgWarning)
        {
            if (!result)
                Alerts.ShowWarning(msgWarning);
            return !result;
        }

        private bool ValidateInputs()
        {
            if (Validate(Validator.ValidateNotEmptyString(tbTitular.Text), MSG_CREDIT_CARD_NAME_EMPTY) ||
                Validate(Validator.ValidateNotEmptyString(tbNumero.Text), MSG_CREDIT_CARD_NUMBER_EMPTY) ||
                Validate(Validator.ValidateNotEmptyDate(dtpFechaVencimiento.Value), MSG_CREDIT_CARD_EXPIRATION_DATE_EMPTY) ||
                Validate(Validator.ValidateStringLength(tbNumero.Text, 16), MSG_CREDIT_CARD_INVALID_LENGTH))
                return false;
            return true;
        }
    }
}
