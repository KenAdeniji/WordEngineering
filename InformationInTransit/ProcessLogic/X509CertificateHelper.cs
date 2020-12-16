using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.IO;

namespace InformationInTransit.ProcessLogic
{
    public static partial class X509CertificateHelper
    {
        public static void Main(string[] argv)
        {
            X509Certificate certificate1 = X509Certificate.CreateFromCertFile(@"C:\CAConfig\comfort.ephraimtech.com_Comfort.crt");
            X509Certificate2 certificate2 = new X509Certificate2(certificate1);
            
            /*
            PrintCertificateInfo(certificate1);
            PrintCertificateInfo(certificate2);
            */

            /*
            List<StoreName> storeNames = EnumHelper.ConvertEnumToList<StoreName>();
            foreach (StoreName storeName in storeNames)
            {
                EnumCertificates(storeName, StoreLocation.LocalMachine);
            }
            */

            EnumCertificates("My", StoreLocation.LocalMachine);
        }

        /// <code>
        /// X509Certificate certificate1 = X509Certificate.CreateFromCertFile(@"C:\CAConfig\comfort.ephraimtech.com_Comfort.crt");
        /// PrintCertificateInfo(certificate1);
        /// </code>
        public static void PrintCertificateInfo(X509Certificate certificate)
        {
            //Dump the Version 1 Fields of the X509 Certificate
            System.Console.WriteLine("Serial Number: {0}", certificate.GetSerialNumberString());
            System.Console.WriteLine("Effective Date: {0}", certificate.GetEffectiveDateString());
            System.Console.WriteLine("Expiration Date: {0}", certificate.GetExpirationDateString());
            /* Deprecated
            System.Console.WriteLine("Entity Name: {0}", certificate.GetName());
            */ 
            System.Console.WriteLine("Entity Name: {0}", certificate.Subject);
            System.Console.WriteLine("Entities Public Key: {0}", certificate.GetPublicKeyString());
            System.Console.WriteLine("Entities Key Algorithm: {0}", certificate.GetKeyAlgorithm());
            /* Deprecated
            System.Console.WriteLine("Issuers Name: {0}", certificate.GetIssuerName());
            */ 
            System.Console.WriteLine("Issuers Name: {0}", certificate.Issuer);
        }

        /// <code>
        /// X509Certificate certificate1 = X509Certificate.CreateFromCertFile(@"C:\CAConfig\comfort.ephraimtech.com_Comfort.crt");
        /// X509Certificate2 certificate2 = new X509Certificate2(certificate1);
        /// PrintCertificateInfo(certificate2);
        /// </code>
        public static void PrintCertificateInfo(X509Certificate2 certificate)
        {
            Console.WriteLine("Name: {0}", certificate.FriendlyName);
            Console.WriteLine("Issuer: {0}", certificate.IssuerName.Name);
            Console.WriteLine("Subject: {0}", certificate.SubjectName.Name);
            Console.WriteLine("Version: {0}", certificate.Version);
            Console.WriteLine("Valid from: {0}", certificate.NotBefore);
            Console.WriteLine("Valid until: {0}", certificate.NotAfter);
            Console.WriteLine("Serial number: {0}", certificate.SerialNumber);
            Console.WriteLine("Signature Algorithm: {0}", certificate.SignatureAlgorithm.FriendlyName);
            Console.WriteLine("Thumbprint: {0}", certificate.Thumbprint);
            Console.WriteLine();
        }

        /// <code>
        /// List<StoreName> storeNames = EnumHelper.ConvertEnumToList<StoreName>();
        /// foreach (StoreName storeName in storeNames)
        /// {
        ///     EnumCertificates(storeName, StoreLocation.LocalMachine);
        /// }
        /// </code>
        public static void EnumCertificates(StoreName name, StoreLocation location)
        {
            X509Store store = new X509Store(name, location);
            try
            {
                store.Open(OpenFlags.ReadOnly);
                foreach (X509Certificate2 certificate in store.Certificates)
                {
                    PrintCertificateInfo(certificate);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                store.Close();
            }
        }

        /// <code>
        /// EnumCertificates("My", StoreLocation.LocalMachine);
        /// </code>
        public static void EnumCertificates(string name, StoreLocation location)
        {
            X509Store store = new X509Store(name, location);
            try
            {
                store.Open(OpenFlags.ReadOnly);
                foreach (X509Certificate2 certificate in store.Certificates)
                {
                    PrintCertificateInfo(certificate);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                store.Close();
            }
        }

        public static bool CreateStore(string name, StoreLocation location)
        {
            bool success = false;
            X509Store store = new X509Store(name, location);
            try
            {
                store.Open(OpenFlags.ReadWrite);
                success = true;
                store.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return success;
        }

        public static bool ImportCertificate(X509Certificate2 certificate, StoreName name, StoreLocation location)
        {
            bool success = false;

            X509Store store = new X509Store(name, location);
            try
            {
                store.Open(OpenFlags.ReadWrite);
                store.Add(certificate);
                success = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                store.Close();
            }

            return success;
        }

        public static bool ImportCertificate(X509Certificate2 certificate, string name, StoreLocation location)
        {
            bool success = false;

            X509Store store = new X509Store(name, location);
            try
            {
                store.Open(OpenFlags.ReadWrite);
                store.Add(certificate);
                success = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                store.Close();
            }

            return success;
        }

        public static bool ImportCertificate(string path, StoreName name, StoreLocation location)
        {
            bool success = false;

            try
            {
                X509Certificate2 certificate = new X509Certificate2(path);
                success = ImportCertificate(certificate, name, location);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return success;
        }

        public static bool ImportCertificate(string path, string name, StoreLocation location)
        {
            bool success = false;

            try
            {
                X509Certificate2 certificate = new X509Certificate2(path);
                success = ImportCertificate(certificate, name, location);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return success;
        }

        public static bool ExportCertificate(
   string certificateName,
   string path,
   StoreName storeName,
   StoreLocation location)
        {
            bool success = false;

            X509Store store = new X509Store(storeName, location);
            store.Open(OpenFlags.ReadOnly);
            try
            {
                X509Certificate2Collection certs
                   = store.Certificates.Find(X509FindType.FindBySubjectName, certificateName, true);

                if (certs != null && certs.Count > 0)
                {
                    byte[] data = certs[0].Export(X509ContentType.Cert);
                    success = WriteFile(data, path);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                store.Close();
            }

            return success;
        }

        public static bool ExportCertificate(
           string certificateName,
           string path,
           string storeName,
           StoreLocation location)
        {
            bool success = false;

            X509Store store = new X509Store(storeName, location);
            store.Open(OpenFlags.ReadOnly);
            try
            {
                X509Certificate2Collection certs
                   = store.Certificates.Find(X509FindType.FindBySubjectName, certificateName, true);

                if (certs != null && certs.Count > 0)
                {
                    byte[] data = certs[0].Export(X509ContentType.Cert);
                    success = WriteFile(data, path);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                store.Close();
            }

            return success;
        }

        private static bool WriteFile(byte[] data, string filename)
        {
            bool ret = false;
            try
            {
                FileStream f = new FileStream(filename, FileMode.Create, FileAccess.Write);
                f.Write(data, 0, data.Length);
                f.Close();
                ret = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return ret;
        }

        public static bool DeleteCertificate(string certificateName, string storeName, StoreLocation location)
        {
            bool success = false;

            X509Store store = new X509Store(storeName, location);
            try
            {
                store.Open(OpenFlags.ReadWrite);

                X509Certificate2Collection certificates =
                   store.Certificates.Find(X509FindType.FindBySubjectName, certificateName, true);

                if (certificates != null && certificates.Count > 0)
                {
                    store.RemoveRange(certificates);
                    success = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                store.Close();
            }

            return success;
        }

        public static bool DeleteCertificate(
           string certificateName,
           string thumbprint,
           string storeName,
           StoreLocation location)
        {
            bool success = false;

            X509Store store = new X509Store(storeName, location);
            try
            {
                store.Open(OpenFlags.ReadWrite);

                X509Certificate2Collection certificates =
                   store.Certificates.Find(X509FindType.FindBySubjectName, certificateName, true);

                if (certificates != null && certificates.Count > 0)
                {
                    foreach (X509Certificate2 certificate in certificates)
                    {
                        if (certificate.Thumbprint == thumbprint)
                        {
                            store.Remove(certificate);
                            success = true;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                store.Close();
            }

            return success;
        }
    }
}
