using System.Windows.Forms;

namespace Support.Forms
{
    public static class Alerts
    {
        public static void ShowWarning(string text)
        {
            MessageBox.Show(text, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void ShowError(string text)
        {
            MessageBox.Show(text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowInfo(string text)
        {
            MessageBox.Show(text, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
