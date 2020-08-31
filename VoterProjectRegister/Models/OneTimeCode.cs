using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace VoterProjectRegister.Models
{
    public class OneTimeCode
    {
        const int Salt_Length = 128;
        const int Code_Length = 8;
        public int OTCID { get; set; }

        [StringLength(128)]
        public string CodeHash { get; set; }

        public string Salt { get; set; }

        public bool IsOpen { get; set; } = true;

        public string InstantiateCode(Poll poll)
        {
            string returner = this.GenerateCode();
            poll.Codes.Add(this);
            return returner;
        }
        public string GenerateCode()
        {
            byte[] code = new byte[Code_Length];

            byte[] salt = new byte[Salt_Length / 8];

            using (var random = RandomNumberGenerator.Create())
            {
                random.GetBytes(salt);
                random.GetBytes(code);
            }

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: code.ToString(),
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: (2 * Salt_Length) / 8));

            this.CodeHash = hashed;
            this.Salt = Convert.ToBase64String(salt);
            return code.ToString();

        }



        public static OneTimeCode[] generateCode(int codeCount, Poll poll)
        {
            OneTimeCode[] otc = new OneTimeCode[codeCount];

            for(int i = 0; i < codeCount; i++)
            {
                otc[i] = generateCode(poll);
            }

            return otc;

        }

        public override string ToString()
        {
            return Code;
        }
    }
}
