using Parduotuve.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parduotuve.Core.Models
{
    public class Produktas
    {
        [Key]
        public int ProduktoId { get; set; }
        public string Pavadinimas {  get; set; }

        public decimal Kaina { get; set; }

        public PrekiuKategorija Kategorija { get; set; }

        public int KiekisSandelyje { get; set; }


        public Produktas(int produktoId, string pavadinimas, decimal kaina, PrekiuKategorija kategorija, int kiekisSandelyje)
        {
            ProduktoId = produktoId;
            Pavadinimas = pavadinimas;
            Kaina = kaina;
            Kategorija = kategorija;
            KiekisSandelyje = kiekisSandelyje;

        }

        public Produktas()
        {
        }



    }
}
