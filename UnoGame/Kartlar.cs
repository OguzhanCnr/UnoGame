using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnoGame
{
    class Kartlar
    {
        //Burada kartlar adında dizimiz var içinde oyundaki kartları içeriyor ve oyun 3 kişilik olduğu için 3 tanede oyuncu dizisi var.
        string[] kartlar = new string[18] { "S1", "S2", "S3", "S4", "S5", "M1", "M2", "M3", "M4", "M5", "K1", "K2", "K3", "K4", "K5", "RD", "RD", "RD", };
        public string[] oyuncu1 = new string[6];
        public string[] oyuncu2 = new string[6];
        public string[] oyuncu3 = new string[6];
        //kartları karıştırıyoruz.
        public void karistir()
        {
            string gecici;
            Random random = new Random();
            for (int k = 0; k < 18; k++)
            {
                int indis = random.Next(0, 18);
                gecici = kartlar[k];
                kartlar[k] = kartlar[indis];
                kartlar[indis] = gecici;
            }
        }
        //kartları dağıtıyoruz.
        public void dagit()
        {
            for (int i = 0; i < 6; i++)
            {
                oyuncu1[i] = kartlar[i];
                oyuncu2[i] = kartlar[i + 6];
                oyuncu3[i] = kartlar[i + 12];
            }
        }
    }
}
