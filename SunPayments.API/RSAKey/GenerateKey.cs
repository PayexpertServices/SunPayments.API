using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Pkcs;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.X509;

namespace SunPayments.API.Key
{
    public class GenerateKey
    {
        public static void GenerateKeys(out string _private,out string _public)
        {
            var generator = new RsaKeyPairGenerator();
            generator.Init(new Org.BouncyCastle.Crypto.KeyGenerationParameters(new SecureRandom(), 2048));
            var keyPair=generator.GenerateKeyPair();
            var publicKeyParam = (RsaKeyParameters)keyPair.Public;
            var privateKeyParam=(RsaKeyParameters)keyPair.Private;
            var publicKey = Convert.ToBase64String(SubjectPublicKeyInfoFactory.CreateSubjectPublicKeyInfo(publicKeyParam).GetDerEncoded());
            var privateKey = Convert.ToBase64String(PrivateKeyInfoFactory.CreatePrivateKeyInfo(privateKeyParam).GetDerEncoded());
            _private = privateKey;
            _public = publicKey;



        }
    }
}
