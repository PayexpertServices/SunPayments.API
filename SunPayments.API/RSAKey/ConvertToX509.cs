using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.OpenSsl;

namespace SunPayments.API.RSAKey
{
    public class ConvertToX509
    {
        public static string ConvertToX509Der(RsaKeyParameters publicKeyToConvert)
        {
            try
            {
                byte[] publicKeyDer;
                using (MemoryStream outputStream = new MemoryStream())
                {
                    using (TextWriter outputWriter = new StreamWriter(outputStream))
                    {
                        PemWriter pemWriter = new PemWriter(outputWriter);
                        pemWriter.WriteObject(publicKeyToConvert);
                    }
                    publicKeyDer = outputStream.ToArray();
                }

                return Convert.ToBase64String(publicKeyDer);
            }
            catch (Exception e)
            {
                throw new ApplicationException("Error converting RSA public key to DER format: " + e.Message);
            }
        }
    }

}

//// Example usage
//RsaKeyParameters publicKeyToConvert = // Get your RSA public key here

//try
//{
//    string publicKeyDerBase64 = ConvertToX509Der(publicKeyToConvert);
//Console.WriteLine("RSA public key converted to DER format and Base64 encoded: " + publicKeyDerBase64);
//}
//catch (ApplicationException e)
//{
//    Console.WriteLine("Error: " + e.Message);
//}
