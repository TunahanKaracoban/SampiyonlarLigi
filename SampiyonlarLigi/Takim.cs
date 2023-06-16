using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampiyonlarLigi
{
    public class Takim
    {
        public string Ad { get; set; }
        public string Ulke { get; set; }
        public int Puan { get; set; }
        public int Averaj { get; set; }
        public int AtılanGol { get; set; }
        public int YenilenGol { get; set; }

        public Takim(string ad, string ulke)
        {
            Ad = ad;
            Ulke = ulke;
        }

       
    }
}
