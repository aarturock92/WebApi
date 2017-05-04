namespace CEMEX.Services.Abstract
{
    public interface IEncryptionService
    {
        string CrearSalt();
        string EncryptionPassword(string password, string salt);
    }
}
