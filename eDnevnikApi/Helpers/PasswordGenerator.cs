using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnikApi.Helpers
{
    public class PasswordGenerator
    {
        public static string GenerateHash(string password)
        {
            byte[] arrPassword = Encoding.Unicode.GetBytes(password);


            byte[] arr = new byte[arrPassword.Length];

            System.Buffer.BlockCopy(arrPassword, 0, arr, 0, arrPassword.Length);


            HashAlgorithm alg = HashAlgorithm.Create("SHA1");

            return Convert.ToBase64String(alg.ComputeHash(arr));
        }
    }
}
