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

            posisikaraktergame karakter = new posisikaraktergame();
            karakter.triggerAktif(trigger.tombolX);
            karakter.triggerAktif(trigger.tombolS);
            karakter.triggerAktif(trigger.tombolW);
            Console.ReadKey();
        }
    }
    public enum karakter
    {
        tengkurap,
        jongkok,
        berdiri,
        terbang
    }

    public enum trigger
    {
        tombolS,
        tombolW,
        tombolX
    }
    public class posisikaraktergame
    {
        public karakter currentstate = karakter.tengkurap;

        public class transisi
        {
            public karakter stateawal;
            public karakter stateakhir;
            public trigger Trigger;
            internal karakter stateAkhir;
            private karakter berdiri;
            private karakter terbang;
            private trigger tombolW;

            public transisi(karakter berdiri, karakter terbang, trigger tombolW)
            {
                this.berdiri = berdiri;
                this.terbang = terbang;
                this.tombolW = tombolW;
            }

            public transisi(karakter stateawal, karakter stateakhir, trigger trigger, karakter stateAkhir)
            {
                this.stateawal = stateawal;
                this.stateakhir = stateakhir;
                Trigger = trigger;
                this.stateAkhir = stateAkhir;
            }
        }
        transisi[] transisi2 =
        {
            new transisi (karakter.berdiri, karakter.terbang, trigger.tombolW),
            new transisi (karakter.berdiri, karakter.jongkok, trigger.tombolS),
            new transisi (karakter.terbang, karakter.berdiri, trigger.tombolS),
            new transisi (karakter.terbang, karakter.jongkok, trigger.tombolX),
            new transisi (karakter.jongkok, karakter.berdiri, trigger.tombolW),
            new transisi (karakter.jongkok, karakter.tengkurap,trigger.tombolS),
            new transisi (karakter.tengkurap, karakter.jongkok, trigger.tombolW)
        };
        
        private karakter getstateselanjutnya(karakter stateawal, trigger Trigger)
        {
            karakter stateAkhir = stateawal;
            for(int i = 0; i < transisi2.Length; i++)
            {
                transisi perubahan = transisi2[i];
                if(stateawal == perubahan.stateawal && Trigger == perubahan.Trigger){
                    stateAkhir= perubahan.stateAkhir;
                }
            }
            return stateAkhir;
        }
        public void triggerAktif(trigger trigger)
        {
            currentstate = getstateselanjutnya(currentstate, trigger);
            Console.WriteLine("state sekarang :" +currentstate );
            if(currentstate == karakter.berdiri)
            {
                Console.WriteLine("posisi standby");
            }else if (currentstate == karakter.tengkurap)
            {
                Console.WriteLine("posisi istirahat");
            }
        }
    }
}
