using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAg_Predictor
{
    internal class Converter
    {
        public static int binarToDecimal(string numarBinar)
        {
            return Convert.ToInt32(numarBinar, 2);
        }

        public static string decimalToBinar(long numarDecimal, int numarBiti)
        {
            string rezultat = "";
            int n;
            long masca;
            int k;
            string ch;

            if (numarBiti == 0)
            {
                rezultat = "";
            }

            for(k=0, masca=1; k<numarBiti; k++)
            {
                if((numarDecimal&masca)!=0)
                {
                    ch = "1";
                }
                else
                {
                    ch = "0";
                }
                rezultat = ch + rezultat;
                masca *= 2;
            }

            if (numarBiti == 33)
            {
                n = rezultat.IndexOf('1', 0);
                if (n == -1)
                {
                    rezultat = "0";
                }
                else
                {
                    rezultat = rezultat.Substring(n);
                }
            }

            return rezultat;
        }
    }
}
