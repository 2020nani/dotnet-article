using System.Security.Cryptography;

namespace FirstApi.Application.UseCases.PasswordHasher
{
    public class PasswordHasher : IPasswordHasher
    {
        private int SaltSize = 128 / 8;
        private int KeySize = 256 / 8;
        private int Iterations = 10000;
        private static HashAlgorithmName _hash = HashAlgorithmName.SHA256;
        private char Delimiter = ';'; 
        string IPasswordHasher.Hash(string password)
        {
            var salt = RandomNumberGenerator.GetBytes(SaltSize);
            var hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations,_hash, KeySize);
            return string.Join(Delimiter, Convert.ToBase64String(salt), Convert.ToBase64String(hash));
        }

        bool IPasswordHasher.Verify(string passwordHash, string password)
        {
            var elements = passwordHash.Split(Delimiter);
            var salt = Convert.FromBase64String(elements[0]);
            var hash = Convert.FromBase64String(elements[1]);
            var hashInput = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, _hash, KeySize);
            return CryptographicOperations.FixedTimeEquals(hash, hashInput);
        }
    }
}
