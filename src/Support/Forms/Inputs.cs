using System;
using System.Windows.Forms;

namespace Support.Forms
{
    public static class Inputs
    {
        public static void SetMaxLength(TextBox tb, int maxLength)
        {
            tb.MaxLength = maxLength;
        }

        public static void OnlyNumericInt(TextBox tb)
        {
            tb.KeyPress += new KeyPressEventHandler(TbOnlyNumericInt);
        }

        public static void OnlyNumericDecimal(TextBox tb)
        {
            tb.KeyPress += new KeyPressEventHandler(TbOnlyNumericDecimal);
        }

        public static void NotNumeric(TextBox tb)
        {
            tb.KeyPress += new KeyPressEventHandler(TbOnlyNotNumeric);
        }

        public static void NotSeparated(TextBox tb)
        {
            tb.KeyPress += new KeyPressEventHandler(TbNotSeparated);
        }

        public static void LetterOrDigit(TextBox tb)
        {
            tb.KeyPress += new KeyPressEventHandler(TbLetterOrDigit);
        }

        private static void TbLetterOrDigit(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar))
                e.Handled = true;
        }

        private static void TbNotSeparated(object sender, KeyPressEventArgs e)
        {
            if (char.IsSeparator(e.KeyChar))
                e.Handled = true;
        }

        private static void TbOnlyNotNumeric(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar) && !char.IsPunctuation(e.KeyChar))
                e.Handled = true;
        }

        private static void TbOnlyNumericDecimal(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                e.Handled = true;

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
                e.Handled = true;
        }

        private static void TbOnlyNumericInt(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        public static void DtpSetBounds(DateTimePicker dtp, DateTime? minDate, DateTime? maxdate)
        {
            if (minDate.HasValue)
                dtp.MinDate = minDate.Value;
            if (maxdate.HasValue)
                dtp.MaxDate = maxdate.Value;
        }
    }
}
