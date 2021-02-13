using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Practica2_TokenGenerator
{
    public class TokenGenerator
    {
        public TokenGenerator()
        {

        }

        public string GenerateToken(string name, string studentID, string header, string secret)
        {
            string token = string.Empty;
            string payload = $"{{\"name\": \"{name}\", \"studentID\": \"{studentID}\"}}";
            string encodedHeader, encodedPayload = string.Empty;
            string encodedHeaderPayload = string.Empty;
            string encodedSignature = string.Empty;
            string hashedSignature = string.Empty;

            try
            {
                //First we encode the header
                var plainBytesHeader = System.Text.Encoding.UTF8.GetBytes(header);
                encodedHeader = System.Convert.ToBase64String(plainBytesHeader).TrimEnd('=').Replace('+', '-').Replace('/', '_');

                //Then we encode the payload
                var plainBytesPayLoad = System.Text.Encoding.UTF8.GetBytes(payload);
                encodedPayload = System.Convert.ToBase64String(plainBytesPayLoad).TrimEnd('=').Replace('+', '-').Replace('/', '_');

                encodedHeaderPayload = encodedHeader + "." + encodedPayload;

                var plainBytesSecret = System.Text.Encoding.UTF8.GetBytes(secret);

                var hash = new HMACSHA256(plainBytesSecret);

                byte[] hashedResult = hash.ComputeHash(System.Text.Encoding.UTF8.GetBytes(encodedHeaderPayload));


                StringBuilder Sb = new StringBuilder();

                foreach (byte b in hashedResult)
                    Sb.Append(b.ToString());

                hashedSignature = Sb.ToString();

                encodedSignature = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(hashedSignature)).TrimEnd('=').Replace('+', '-').Replace('/', '_');

                token = encodedHeaderPayload + "." + encodedSignature;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return ex.Message;
            }

            return token;
        }

        public string ObtainPayLoadFromToken(string token)
        {
            string decodedPayload = string.Empty;
            string[] tokenParts = token.Split('.');

            tokenParts[1] = tokenParts[1].Replace('-', '+').Replace('_', '/');

            var d = tokenParts[1].Length % 4;

            if (d != 0)
            {
                tokenParts[1] = tokenParts[1].TrimEnd('=');
                tokenParts[1] += d % 2 > 0 ? "=" : "==";
            }

            var decodedPayloadBytes = System.Convert.FromBase64String(tokenParts[1]);

            decodedPayload = System.Text.Encoding.UTF8.GetString(decodedPayloadBytes);
            

            return decodedPayload;
        }

        public static String sha256_hash(string value)
        {
            StringBuilder Sb = new StringBuilder();

            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes(value));

                foreach (Byte b in result)
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
        }
    }
}
