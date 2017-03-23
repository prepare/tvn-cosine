using System;
using System.Security.Cryptography;

namespace Tvn.Cosine.Text.Hashing
{
    public class PasswordHasher
    {
        const int saltSize = 16;
        const int hashSize = 64;
        const int hashIterationCount = 10000;

        readonly byte[] salt;
        readonly byte[] hash;

        public PasswordHasher(string password)
        {
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[saltSize]);
            hash = new Rfc2898DeriveBytes(password, salt, hashIterationCount).GetBytes(hashSize);
        }

        public PasswordHasher(byte[] hashBytes)
        {
            Array.Copy(hashBytes, 0, salt = new byte[saltSize], 0, saltSize);
            Array.Copy(hashBytes, saltSize, hash = new byte[hashSize], 0, hashSize);
        }

        public PasswordHasher(byte[] salt, byte[] hash)
        {
            this.salt = new byte[saltSize];
            this.hash = new byte[hashSize];

            Array.Copy(salt, 0, this.salt, 0, saltSize);
            Array.Copy(hash, 0, this.hash, 0, hashSize);
        }

        public byte[] ToArray()
        {
            byte[] hashBytes = new byte[saltSize + hashSize];
            Array.Copy(salt, 0, hashBytes, 0, saltSize);
            Array.Copy(hash, 0, hashBytes, saltSize, hashSize);
            return hashBytes;
        }

        public byte[] Salt { get { return (byte[])salt.Clone(); } }
        public byte[] Hash { get { return (byte[])hash.Clone(); } }

        public bool Verify(string password)
        {
            byte[] test = new Rfc2898DeriveBytes(password, salt, hashIterationCount).GetBytes(hashSize);
            for (int i = 0; i < hashSize; i++)
                if (test[i] != hash[i])
                    return false;
            return true;
        }
    }
}
