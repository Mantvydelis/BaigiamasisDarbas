using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parduotuve.Core.Models
{
    public class Pardavejas : Vartotojas
    {
        public int PardavejoId { get; set; }

        public Pardavejas(int pardavejoId, string vardas, string pavarde, string elPastas, int telNumeris) : base (vardas, pavarde, elPastas, telNumeris)
        {
            PardavejoId = pardavejoId;
        }
    }
}
