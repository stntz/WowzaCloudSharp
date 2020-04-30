using System;
using System.Security.Cryptography;
using System.Text;

namespace WowzaSDK
{
    public class WowzaAuthGenerator
    {
        public static string GenerateHmacSignature(string apiKey, string requestPath, long timestamp)
        {
            if (string.IsNullOrWhiteSpace(apiKey) || string.IsNullOrWhiteSpace(requestPath))
                throw new NullReferenceException("You cannot have null or empty values for 'apiKey' or 'requestpath'");
            
            var plainSignature = $"{timestamp}:{requestPath}:{apiKey}";                       

            var byteKey = Encoding.UTF8.GetBytes(apiKey);
            var signatureByte = Encoding.UTF8.GetBytes(plainSignature);

            var hash256 = new HMACSHA256(byteKey);

            var signatureHash = hash256.ComputeHash(signatureByte);

            return string.Concat(Array.ConvertAll(signatureHash, b => b.ToString("X2"))).ToLower();           
        }
    }
}