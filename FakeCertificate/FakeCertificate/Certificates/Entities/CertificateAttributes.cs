using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeCertificate.Certificates.Entities
{
    public class CertificateAttributes
    {
        public string Name { get; set; }
        public string Algorithm { get; set; }
        public int Validity { get; set; }
    }
}
