using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parduotuve.Core.Models
{
    public class Uzsakymas
    {
        public int UzsakymoId { get; set; }
        public int PardavejoId { get; set; }

        public int PirkejoId { get; set; }
        public int ProduktoId { get; set; }

        public DateOnly UzsakymoData { get; set; }

        public int Kiekis {  get; set; }



        public Uzsakymas(int uzsakymoId, int pardavejoId, int pirkejoId, int produktoId,  DateOnly uzsakymoData, int kiekis)
        {
            UzsakymoId = uzsakymoId;
            PardavejoId = pardavejoId;
            PirkejoId = pirkejoId;
            ProduktoId = produktoId;
            UzsakymoData = uzsakymoData;
            Kiekis = kiekis;

        }
        
        

    }
}
