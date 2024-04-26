


namespace Domain.Interfaces
{
    public interface IEncrypt
    {
        string Encrypt(string str);
        string Decrypt(string str);
    }
}