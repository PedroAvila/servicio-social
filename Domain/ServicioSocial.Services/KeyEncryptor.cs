using System.Security.Cryptography;
using System.Text;

namespace ServicioSocial.Services
{
    public class KeyEncryptor : IKeyEncryptor
    {
        public string HashPassword(string password)
        {
            using var sha = SHA256.Create();
            var asBytes = Encoding.Default.GetBytes(password);
            var hashed = sha.ComputeHash(asBytes);
            return Convert.ToBase64String(hashed);
        }

        public bool ValidatePasword(string passwordRecovered, string passwordEntered)
        {
            var validate = HashPassword(passwordEntered).Equals(passwordRecovered);
            return validate;
        }
    }
}