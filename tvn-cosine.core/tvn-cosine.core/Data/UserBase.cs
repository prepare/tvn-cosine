using System;
using System.Collections.Generic;
using Tvn.Cosine.Text.Hashing;

namespace Tvn.Cosine.Data
{
    public abstract class UserBase : IUser
    {
        public virtual DateTime DateCreated { get; protected set; }
        public virtual DateTime DateLastUpdated { get; protected set; }
        public virtual string Email { get; protected set; }
        public virtual uint Id { get; protected set; }
        public virtual string Name { get; protected set; }
        public virtual byte[] PasswordHash { get; protected set; }
        public virtual byte[] PasswordSalt { get; protected set; }
        public virtual ICollection<ILanguage> Languages { get; protected set; }

        #region Password    
        private PasswordHasher passwordHasher;

        protected void SetPassword(string password)
        {
            passwordHasher = new PasswordHasher(password);
            PasswordHash = passwordHasher.Hash;
            PasswordSalt = passwordHasher.Salt;
        }

        protected bool VerifyPassword(string password)
        {
            if (passwordHasher == null)
            {
                if (PasswordHash != null && PasswordSalt != null)
                {
                    passwordHasher = new PasswordHasher(PasswordSalt, PasswordHash);
                }
            }

            if (passwordHasher != null)
                return passwordHasher.Verify(password);
            else
                return false;
        }

        #endregion
    }
}
