using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace LKS.Data.Providers
{
    public class PasswordProvider : IPasswordProvider
    {
		// TODO разобраться что не так с хранением хеща в sqlLite и вернуть хеш обратно
		// Временно храним пароль в открытом виде в бд
        public string GetHash(string password, string salt)
        {
			//var data = Encoding.Unicode.GetBytes(salt + password);
			//var hash = SHA256.Create().ComputeHash(data);
			//return Encoding.Unicode.GetString(hash);
			return password + salt;
        }

        public string GetRandomPassword(int length)
        {
            const string availableChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            Random rnd = new Random();
            return new string(Enumerable.Repeat(availableChars, length).Select(x => x[rnd.Next(x.Length)]).ToArray());
        }

        public bool VerifyHashedPassword(string hash, string salt, string password)
        {
            return hash == GetHash(password, salt);
        }
    }
}
