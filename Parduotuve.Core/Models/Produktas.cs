using Parduotuve.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parduotuve.Core.Models
{
    public class Produktas
    {
        public int ProduktoId { get; set; }
        public string Pavadinimas {  get; set; }

        public decimal Kaina { get; set; }

        public PrekiuKategorija Kategorija { get; set; }

        public int KiekisSandelyje { get; set; }


        public Produktas(int produktoId, string pavadinimas, decimal kaina, PrekiuKategorija prekiukategorija, int  kiekisSandelyje)
        {
            ProduktoId = produktoId;
            Pavadinimas = pavadinimas;
            Kaina = kaina;
            Kategorija = prekiukategorija;
            KiekisSandelyje = kiekisSandelyje;

        }



     }
}
