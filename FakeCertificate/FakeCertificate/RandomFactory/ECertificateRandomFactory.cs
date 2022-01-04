using Bogus;
using Bogus.Extensions.Brazil;
using FakeCertificate.Certificates.Entities;
using FakeCertificate.Certificates.Implementations;
using FakeCertificate.Extensions;

namespace FakeCertificate.RandomFactory
{
    public static class ECertificateRandomFactory
    {
        public static void Generate(string path, string password, int number = 1, int validity = 1)
        {
            Faker(validity).Generate(number).ForEach(Attributes =>
            {
                var certificate = new ECertificateFactory().Create(Attributes);
                certificate.ExportPFX(path, password);
                certificate.ExportCert(path, password);
            });
        }

        private static Faker<ECertificateAttributes> Faker(int validity)
        {
            return new Faker<ECertificateAttributes>("pt_BR").StrictMode(false).Rules((faker, obj) =>
            {
                obj.Algorithm = "SHA256WITHRSA";
                obj.Document = faker.Person.Cpf(false);
                obj.Name = faker.Person.FullName;
                obj.Validity = validity;
            });
        }
    }
}
