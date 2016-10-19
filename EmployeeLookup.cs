using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerieTest
{
    public class EmployeeLookup
    {

        public KMD_FerieService.ZLPE_EMPLOYEE_INFO[] Employee_Info(string yyyyMMdd_MedBindestreger, string cpr)
        {

            //bruger endpoint kaldet HTTPS_Port fra App.config.
            //Være opmærksomme på at Config filen bliver autogeneret når man tilføjer KMD_LPT_VACAB_Service.wsdl som service reference, men endpoint urls og <transport clientCredentialType="Certificate"></transport> skal ændres/opsættes manuelt
            using (KMD_FerieService.LPT_VACAB_Service_OutClient webService = new KMD_FerieService.LPT_VACAB_Service_OutClient("HTTPS_Port"))
            {
                webService.ClientCredentials.ClientCertificate.SetCertificate(System.Security.Cryptography.X509Certificates.StoreLocation.LocalMachine, System.Security.Cryptography.X509Certificates.StoreName.My, System.Security.Cryptography.X509Certificates.X509FindType.FindBySubjectName, "NAVN på certifikat");
                try
                {
                    //OBS hvis en medarbejder har haft flere ansættelser vil der være flere resultater i result array'et <- nogle af disse vil være historiske, andre ansatte vil have flere aktive.

                    KMD_FerieService.ZLPE_EMPLOYEE_INFO[] result = webService.GET_EMPLOYEE_INFO(yyyyMMdd_MedBindestreger, cpr);

                    return result;

                }
                catch (Exception ex)
                {
                    string s = ex.Message + " INNEREXCEPTION: " + ex.InnerException.Message;
                    Console.WriteLine(s);
                    return null;
                }
            }
        }
    }
}
