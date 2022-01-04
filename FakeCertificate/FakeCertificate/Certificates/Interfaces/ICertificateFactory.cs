using FakeCertificate.Certificates.Entities;
using System.Security.Cryptography.X509Certificates;

namespace FakeCertificate.Certificates.Interfaces
{
    public interface ICertificateFactory
    {
        X509Certificate2 Create(ECertificateAttributes certificateAttributes);
    }
}
