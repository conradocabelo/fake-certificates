using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace FakeCertificate.Extensions
{
    public static class X509CertificateExtension
    {
        public static void ExportPFX(this X509Certificate x509Certificate, string fileLocation, string passWord)
        {
            var pfxByteArray = x509Certificate.Export(X509ContentType.Pkcs12, passWord);
            WriteFile(pfxByteArray, fileLocation, $"{x509Certificate.Subject.Replace(":", "_")}.pfx");
        }

        public static void ExportCert(this X509Certificate x509Certificate, string fileLocation, string passWord)
        {
            var cerByteArray = x509Certificate.Export(X509ContentType.Cert, passWord);
            WriteFile(cerByteArray, fileLocation, $"{x509Certificate.Subject.Replace(":", "_")}.cer");
        }

        private static void WriteFile(byte[] certificate, string fileLocation, string certName)
        {
            string fileFullName = Path.Combine(fileLocation, certName);
            File.WriteAllBytes(fileFullName, certificate);
        }
    }
}
