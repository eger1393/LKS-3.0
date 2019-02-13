namespace LKS.Data.Providers
{
    public interface IPasswordProvider
    {
        string GetHash(string password, string salt);
        string GetRandomPassword(int length);
        bool VerifyHashedPassword(string hash, string salt, string password);
    }
}
