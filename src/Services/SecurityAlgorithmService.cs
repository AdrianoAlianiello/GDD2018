using System.Security.Cryptography;
using System.Text;

namespace Services
{
    public class SecurityAlgorithmService
    {
        public string Encrypt(string password)
        {
            var stringEncrypted = new StringBuilder();
            var stream = SHA256.Create().ComputeHash(new ASCIIEncoding().GetBytes(password));
            for (int i = 0; i < stream.Length; i++)
                stringEncrypted.AppendFormat("{0:x2}", stream[i]);
            return stringEncrypted.ToString();
        }
    }
}
