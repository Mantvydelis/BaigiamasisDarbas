using Parduotuve.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parduotuve.Core.Models
{
    public class Vartotojas
    {

        public string Vardas {  get; set; }

        public string Pavarde { get; set; }
        public string ElPastas { get; set; }
        public int TelNumeris { get; set; }
    



        public Vartotojas (string vardas, string pavarde, string elPastas, int telNumeris)
        {
            Vardas = vardas;
            Pavarde = pavarde;
            ElPastas = elPastas;
            TelNumeris = telNumeris;      
        }


        public Vartotojas() { }








    }
}
