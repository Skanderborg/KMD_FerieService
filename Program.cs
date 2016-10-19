using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerieTest
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeLookup empInfo = new EmployeeLookup();
            FerieIndberetning ferieInd = new FerieIndberetning();

            // se mere i KMDs snitflade beskrivelse
            string iv_begda = "yyyy-mm-dd"; //krævet
            string iv_begda_old = ""; //ikke krævet - til opdateringer af gammel ferie
            string iv_begti = ""; // ikke krævet - benyttes hvis ferien starter efter begyndt arbejdstid den pågældende dag
            string iv_begti_old = ""; //ikke altid krævet - til opdateringer af gammel ferie - skal med hvis den tidligere ferie havde tidspunkt
            string iv_endda = "yyyy-mm-dd"; // krævet
            string iv_endda_old = ""; //ikke krævet - til opdateringer af gammel ferie
            string iv_endti = ""; // ikke krævet - benyttes hvis ferien afsluttes før endt arbejdstid den pågædende dag
            string iv_endti_old = ""; //ikke altid krævet - til opdateringer af gammel ferie - skal med hvis den tidligere ferie havde tidspunkt
            string iv_extra_data = ""; //ikke krævet
            string iv_opera = "INS"; // krævet - operationen hos kmd
            string iv_pernr = "medarbejdernummer"; //krævet - tal f.eks. 000123456
            string iv_subty = "FE"; // krævet -  type af fravær
            string iv_subty_old = ""; // den tidligere type af fravær, hvis der f.eks. skiftes mellem Ferie og 6 ferieuge



            //indberet ferie
            ferieInd.Set_Absence_Plus(iv_begda, iv_begda_old, iv_begti, iv_begti_old, iv_endda, iv_endda_old, iv_endti, iv_endti_old, iv_extra_data, iv_opera, iv_pernr, iv_subty, iv_subty_old);

            //get employee nr
            empInfo.Employee_Info("yyyy-mm-dd", "CPR uden bindestreg");

            Console.WriteLine("Done");
            Console.ReadKey();
        }
    }
}
