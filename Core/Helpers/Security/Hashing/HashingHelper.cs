using System.Security.Cryptography;
using System.Text;

namespace Core.Helpers.Security.Hashing
{
    public static class HashingHelper
    {
        public static void CreatePassordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            var hmac = new HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }
        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            var hmac=new HMACSHA512(passwordSalt);
            var enteredPasswordHash = hmac.ComputeHash (Encoding.UTF8.GetBytes(password));
            for(int i=0;i< passwordHash.Length;i++)
            {
                if (enteredPasswordHash[i] != passwordHash[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
