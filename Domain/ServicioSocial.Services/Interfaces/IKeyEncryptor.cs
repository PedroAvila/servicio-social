namespace ServicioSocial.Services
{
    public interface IKeyEncryptor
    {
        string HashPassword(string password);
        bool ValidatePasword(string passwordRecovered, string passwordEntered);
    }
}