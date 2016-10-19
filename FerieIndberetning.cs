using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerieTest
{
    /// <summary>
    /// Indberetning af ferie til KMD's snitflade
    /// <author>Jacob Hansen</author>
    /// </summary>
    public class FerieIndberetning
    {
        public string Set_Absence_Plus(string iv_begda, string iv_begda_old, string iv_begti, string iv_begti_old, string iv_endda, string iv_endda_old, string iv_endti, string iv_endti_old,
            string iv_extra_data, string iv_opera, string iv_pernr, string iv_subty, string iv_subty_old)
        {

            //bruger endpoint kaldet HTTPS_Port fra App.config.
            //Være opmærksomme på at Config filen bliver autogeneret når man tilføjer KMD_LPT_VACAB_Service.wsdl som service reference, men endpoint urls og <transport clientCredentialType="Certificate"></transport> skal ændres/opsættes manuelt
            using (KMD_FerieService.LPT_VACAB_Service_OutClient webService = new KMD_FerieService.LPT_VACAB_Service_OutClient("HTTPS_Port"))
            {
                webService.ClientCredentials.ClientCertificate.SetCertificate(System.Security.Cryptography.X509Certificates.StoreLocation.LocalMachine, System.Security.Cryptography.X509Certificates.StoreName.My, System.Security.Cryptography.X509Certificates.X509FindType.FindBySubjectName, "NAVN på cert");
                try
                {
                    KMD_FerieService.BAPIRET2 response = webService.SET_ABSENCE_PULS(iv_begda, iv_begda_old, iv_begti, iv_begti_old, iv_endda, iv_endda_old, iv_endti, iv_endti_old, iv_extra_data, iv_opera, iv_pernr, iv_subty, iv_subty_old);
                    //Console.WriteLine(response.MESSAGE);
                    return response.MESSAGE + " ### " + response.FIELD + " ### " + response.LOG_NO + " ### " + response.LOG_MSG_NO + " ### " + response.TYPE + " ### " + response.MESSAGE_V1;

                }
                catch (Exception ex)
                {
                    string s = ex.Message;
                    //Console.WriteLine(s);
                    return s;
                }
            }
        }
    }
}
