using System;
using System.Runtime.Serialization;

namespace modul4_13002213034
{
    internal class program
    {
        public enum buah
        {
            apel,
            aprikot,
            alpukat,
            pisang,
            paprika,
            blackberry,
            ceri,
            kelapa,
            jagung,
            kurma,
            durian,
            anggur,
            melon,
            semangka,         
        };
        public class getkodebuah
        {
            public static string getkode(buah buah)
            {
                string[] kodebuah = { "A00", "B00", "C00", "D00", "E00", "F00", "H00", "I00", "J00", "K00", "L00", "M00", "N00", "O00" };
                return kodebuah[(int)buah];
            }
        }

        public static void Main(string[] args)
        {
            buah buah = buah.kelapa;
            string kode = getkodebuah.getkode(buah);
            Console.WriteLine("buah :"+ buah + "\ndengan kode :"+kode);
        }
    }
}
