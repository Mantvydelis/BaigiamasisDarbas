using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parduotuve.Core.Models
{
    public class Pirkejas : Vartotojas
    {
        [Key]
        public int PirkejoId { get; set; }

        public Pirkejas(int pirkejoId, string vardas, string pavarde, string elPastas, int telNumeris): base (vardas, pavarde, elPastas, telNumeris)
        {
            PirkejoId = pirkejoId;

        }



    }
}
