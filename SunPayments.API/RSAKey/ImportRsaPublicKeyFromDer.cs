using System;
using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;

namespace SunPayments.API.Key
{
    public class ImportRsaKey
    {
        public static RsaKeyParameters ImportRsaPublicKeyFromDer(byte[] publicKeyDer)
        {
            try
            {
                // Parse the DER-encoded public key
                Asn1Object publicKeyObj = Asn1Object.FromByteArray(publicKeyDer);

                // Extract the RSA public key parameters from the parsed object
                RsaPublicKeyStructure rsaPubKeyStructure = RsaPublicKeyStructure.GetInstance(publicKeyObj);
                RsaKeyParameters publicKeyParams = new RsaKeyParameters(false, rsaPubKeyStructure.Modulus, rsaPubKeyStructure.PublicExponent);

                return publicKeyParams;
            }
            catch (Exception e)
            {
                throw new ArgumentException("Error importing RSA public key from DER format: " + e.Message);
            }
        }


    }
    

}


//// Example usage
//byte[] publicKeyDerBytes = // Load your DER-encoded public key here

//try
//{
//    RsaKeyParameters publicKey = ImportRsaPublicKeyFromDer(publicKeyDerBytes);
//Console.WriteLine("RSA public key imported successfully.");
//    // Now you have the RSA public key in the 'publicKey' variable
//}
//catch (ArgumentException e)
//{
//    Console.WriteLine("Error importing RSA public key: " + e.Message);
//}
