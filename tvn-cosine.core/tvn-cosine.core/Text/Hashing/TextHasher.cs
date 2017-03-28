using System;
using System.Security.Cryptography;

namespace Tvn.Cosine.Text.Hashing
{
    public class TextHasher : IEquatable<string>
    {
        private const int saltSize = 16;
        private const int hashSize = 64;
        private const int hashIterationCount = 10000;

        private TextHasher()
        {
            Salt = new byte[saltSize];
            Hash = new byte[hashSize];
        }

        public TextHasher(string input)
            : this()
        {
            new RNGCryptoServiceProvider().GetBytes(Salt);
            Hash = new Rfc2898DeriveBytes(input, Salt, hashIterationCount)
                .GetBytes(hashSize);
        }

        public TextHasher(byte[] salt, byte[] hash)
            : this()
        {
            Array.Copy(salt, 0, Salt, 0, saltSize);
            Array.Copy(hash, 0, Hash, 0, hashSize);
        }

        public byte[] Salt { get; }
        public byte[] Hash { get; }

        public bool Equals(string input)
        {
            byte[] test = new Rfc2898DeriveBytes(input, Salt, hashIterationCount)
                .GetBytes(hashSize);

            for (int i = 0; i < hashSize; i++)
            {
                if (test[i] != Hash[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
