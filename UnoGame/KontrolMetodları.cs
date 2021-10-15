using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnoGame
{
    class KontrolMetodları
    {
        public string renkdegisBilgisayar(string[] dizi1, string yerdekikart, string A, string B, int i)
        {
            int b = 0, a = 0;
            for (int j = 0; j < 6; j++)
            {   //eleman # da olabilir dikkat
                if (dizi1[j].Substring(0, 1) == A)
                {
                    a++;
                }
                else if (dizi1[j].Substring(0, 1) == B)
                {
                    b++;
                }
            }
            if (a >= b)
            {
                Console.WriteLine("Renk değişti");
                yerdekikart = A + yerdekikart.Substring(1, 1);
                dizi1[i] = "##";
                return yerdekikart;
            }
            else
            {
                Console.WriteLine("Renk değişti");
                yerdekikart = B + yerdekikart.Substring(1, 1);
                dizi1[i] = "##";
                return yerdekikart;
            }
        }
        //Bilgisayar için kontrol yapılıyor.
        public string kontrolBilgisayar1(string[] dizi1, string yerdekikart)
        {
            int i;
            for (i = 0; i < 6; i++)
            {
                if (dizi1[i].Substring(0, 1) == yerdekikart.Substring(0, 1))
                {
                    yerdekikart = dizi1[i];
                    dizi1[i] = "##";
                    return yerdekikart;
                }
            }
            for (i = 0; i < 6; i++)
            {
                if (dizi1[i].Substring(1, 1) == yerdekikart.Substring(1, 1))
                {
                    yerdekikart = dizi1[i];
                    dizi1[i] = "##";
                    return yerdekikart;
                }
            }

            for (i = 0; i < 6; i++)
            {
                if (dizi1[i] == "RD")
                {
                    if (yerdekikart.Substring(0, 1) == "S")
                    {
                        yerdekikart = renkdegisBilgisayar(dizi1, yerdekikart, "M", "K", i);
                        return yerdekikart;
                    }

                    else if (yerdekikart.Substring(0, 1) == "M")
                    {
                        yerdekikart = renkdegisBilgisayar(dizi1, yerdekikart, "S", "K", i);
                        return yerdekikart;
                    }

                    else if (yerdekikart.Substring(0, 1) == "K")
                    {
                        yerdekikart = renkdegisBilgisayar(dizi1, yerdekikart, "S", "M", i);
                        return yerdekikart;
                    }
                }
            }
            Console.WriteLine("PAS GEÇTİ-KART DEĞİŞMEDİ");
            return yerdekikart;
        }
        //sayi ve x i döngü kontrolleri için kullanıyoruz Oyuncuyu kontrol ediyoruz.
        public string kontrolOyuncu1(string bastus, string yerdekikart, ref int sayi, string[] dizi1)
        {
            int i, x = 0;
            for (i = 0; i < 6; i++)
            {
                if (bastus == dizi1[i])
                {
                    if (dizi1[i].Substring(0, 1) == yerdekikart.Substring(0, 1))
                    {
                        yerdekikart = dizi1[i];
                        dizi1[i] = "##";
                        sayi = 1;
                        return yerdekikart;
                    }

                    else if (dizi1[i].Substring(1, 1) == yerdekikart.Substring(1, 1))
                    {
                        yerdekikart = dizi1[i];
                        dizi1[i] = "##";
                        sayi = 1;
                        return yerdekikart;
                    }

                    else if (dizi1[i] == "RD")
                    {
                        while (x == 0)
                        {
                            string yenirenk;
                            Console.WriteLine("Hangi Rengi Seçiyorsun(-M -S -K)");
                            yenirenk = Console.ReadLine();
                            if (yenirenk.Substring(0, 1) == yerdekikart.Substring(0, 1))
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("Yerdeki kart ile aynı rengi seçemezsin,Lütfen tekrar renk seç.");
                                x = 0;
                                Console.ResetColor();
                            }

                            else if (yenirenk.Substring(0, 1) != yerdekikart.Substring(0, 1) && yenirenk.Substring(0, 1) == "S")
                            {
                                yerdekikart = "S" + yerdekikart.Substring(1, 1);
                                dizi1[i] = "##";
                                x = 1;
                                sayi = 1;
                                return yerdekikart;
                            }

                            else if (yenirenk.Substring(0, 1) != yerdekikart.Substring(0, 1) && yenirenk.Substring(0, 1) == "M")
                            {
                                yerdekikart = "M" + yerdekikart.Substring(1, 1);
                                dizi1[i] = "##";
                                x = 1;
                                sayi = 1;
                                return yerdekikart;
                            }

                            else if (yenirenk.Substring(0, 1) != yerdekikart.Substring(0, 1) && yenirenk.Substring(0, 1) == "K")
                            {
                                yerdekikart = "K" + yerdekikart.Substring(1, 1);
                                dizi1[i] = "##";
                                x = 1;
                                sayi = 1;
                                return yerdekikart;
                            }

                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("Hatalı Harf");
                                x = 0;
                                Console.ResetColor();
                            }
                        }
                    }
                }
            }
            if (bastus == "PAS")
            {
                Console.WriteLine("PAS GEÇTİ-KART DEĞİŞMEDİ");
                sayi = 1;
                return yerdekikart;
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Kart geçerli değil");
                sayi = 0;
                Console.ResetColor();
                return yerdekikart;
            }
        }
    }
}
