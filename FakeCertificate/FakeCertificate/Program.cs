using FakeCertificate.RandomFactory;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FakeCertificate
{
    class Program
    {
        private static Dictionary<string, string> comands;

        static void Main(string[] args)
        {
            comands = args.Select(a => a.Split('='))
                          .ToDictionary(a => a[0], a => a.Length == 2 ? a[1] : null);

            switch (comands["type"])
            {
                case "ecpf":
                    GenareteECPF(args);
                    break;
                default:
                    Console.WriteLine("Option not implemented");
                    break;
            }
        }

        private static void GenareteECPF(string[] args)
        {
            validateRequiredParams("path", "password");

            if (!Directory.Exists(comands["path"]))
                throw new InvalidOperationException("destination folder does not exist");

            int number = FindValue("number") == string.Empty ? 1 : Convert.ToInt32(FindValue("number"));
            int validity = FindValue("validity") == string.Empty ? 1 : Convert.ToInt32(FindValue("validity"));

            ECertificateRandomFactory.Generate(comands["path"], comands["password"], number, validity);
        }

        private static string FindValue(string key)
        {
            if (!comands.ContainsKey(key))
                return string.Empty;

            return comands[key] == null ? string.Empty : comands[key];
        }

        private static void validateRequiredParams(params string[] requiredParams)
        {
            var paramsNull = requiredParams.Where(t => {
                
                string value = null;
                comands.TryGetValue(t, out value);

                return value == null;

            }).ToList();

            if (paramsNull.Count > 0)
            {
                string paramsConcat = string.Join(";", paramsNull);
                throw new InvalidOperationException($"the parameters {paramsConcat} are mandatory for the command");
            }
        }
    }
}
