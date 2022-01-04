using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using FakeCertificate.Certificates.Entities;
using FakeCertificate.Certificates.Interfaces;
using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Operators;
using Org.BouncyCastle.Crypto.Prng;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.X509;

namespace FakeCertificate.Certificates.Implementations
{
    public class ECertificateFactory : ICertificateFactory
    {

        public X509Certificate2 Create(ECertificateAttributes certificateAttributes)
        {
            try
            {
                var ecdsa = ECDsa.Create();
                var req = new CertificateRequest($"CN={certificateAttributes.Name}:{certificateAttributes.Document}", ecdsa, HashAlgorithmName.SHA256);
                var cert = req.CreateSelfSigned(DateTime.Now, DateTime.Now.AddYears(certificateAttributes.Validity));

                return cert;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
