using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnoGame
{
    class Oyun
    {
        KontrolMetodları kontrolMetodları = new KontrolMetodları();
        public int son1 = 0;
        public int son2 = 0;
        public int son3 = 0;
        public int x = 0;
        Kartlar kartlar = new Kartlar();
        public void baslat()
        {
            kartlar.karistir();
            kartlar.dagit();
        }
        //Dizide yere atılan kartın yerine ## koyulur sonucbelirle metodu ile dizideki ## elemanı kontrol ediyoruz.
        public int sonucbelirle(string[] dizi1, string[] dizi2, string[] dizi3)
        {
            for (int i = 0; i < 6; i++)
            {
                if (dizi1[i] == "##")
                {
                    son1++;
                    if (son1 == 6)
                    {
                        x = 24;
                        return x;
                    }
                }
                else
                {
                    son1 = 0;
                }
            }
            for (int i = 0; i < 6; i++)
            {
                if (dizi2[i] == "##")
                {
                    son2++;
                    if (son2 == 6)
                    {
                        x = 24;
                        return x;
                    }
                }
                else
                {
                    son2 = 0;
                }
            }
            for (int i = 0; i < 6; i++)
            {
                if (dizi3[i] == "##")
                {
                    son3++;
                    if (son3 == 6)
                    {
                        x = 24;
                        return x;
                    }
                }
                else
                {
                    son3 = 0;
                }
            }
            return x;
        }
        //Oyuncudan kart isteme ve bunu kontrol etme işlemi oyuncuKartAl ile yapılır.
        public string oyuncuKartAl(string yerdekikart)
        {
            string bastus;
            int sayi = 1;
            do
            {
                Console.WriteLine("yerdeki kart : {0}", yerdekikart);
                Console.WriteLine();
                Console.WriteLine("Kartlarınız:");
                foreach (var item in kartlar.oyuncu1)
                {
                    Console.Write(" " + item);
                }
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Atacağınız Kartı girininiz:");
                bastus = Console.ReadLine();
                yerdekikart = kontrolMetodları.kontrolOyuncu1(bastus, yerdekikart, ref sayi, kartlar.oyuncu1);

            } while (sayi == 0);
            return yerdekikart;
        }
        //yerdeki kart değişmezse beraberkontrol deki sayaç artıyor eğer sayaç 3 olursa hepsi pas geçmiş oluyor ve berabere bitiyor.
        public int beraberkontrol(string yerdekikart, string yerdekikart2, ref int sayac)
        {
            if (yerdekikart == yerdekikart2)
            {
                sayac += 1;
                return sayac;
            }
            else
            {
                sayac = 0;
                return sayac;
            }
        }

        //Oyuncuların işlemleri
        public string oyuncu1islem(string yerdekikart, string yerdekikart2, ref int sayac)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow; Console.Beep();
            yerdekikart2 = yerdekikart;
            yerdekikart = oyuncuKartAl(yerdekikart);
            Console.WriteLine("1. oyuncu " + yerdekikart);
            beraberkontrol(yerdekikart, yerdekikart2, ref sayac);
            return yerdekikart;
        }
        public string oyuncu2islem(string yerdekikart, string yerdekikart2, ref int sayac)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            yerdekikart2 = yerdekikart;
            yerdekikart = kontrolMetodları.kontrolBilgisayar1(kartlar.oyuncu2, yerdekikart);
            Console.WriteLine("2. oyuncu " + yerdekikart);
            beraberkontrol(yerdekikart, yerdekikart2, ref sayac);
            return yerdekikart;
        }
        public string oyuncu3islem(string yerdekikart, string yerdekikart2, ref int sayac)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            yerdekikart2 = yerdekikart;
            yerdekikart = kontrolMetodları.kontrolBilgisayar1(kartlar.oyuncu3, yerdekikart);
            Console.WriteLine("3. oyuncu " + yerdekikart);
            beraberkontrol(yerdekikart, yerdekikart2, ref sayac);
            return yerdekikart;
        }
        //a = 24 olunca oyun bitiyor. sayac 3 olunca berabere biter.
        public void oyunIslem()
        {
            //Oyuna başlayacak kişi random olarak atanıyor.
            //Oyun başında pas yada RD kartı kullanılamıyor.
            Random random = new Random();
            int a = 0, sayac = 0, o = 0;
            string yerdekikart = "", yerdekikart2 = "";
            ConsoleKeyInfo tus;
            int baslangıc = random.Next(0, 3);
            int baslangıcdeger = 0;
            do
            {
                Console.WriteLine("-----OYUN KURALLARI-----");
                Console.WriteLine("-- Oyunda 5 sarı 5 mavi 5 kırmızı ve 3 renk değiştirme kartı bulunmaktadır.");
                Console.WriteLine("-- Yerdeki kart'ın rengi ile aynı renk kart veya kartın yanındaki rakam ile aynı rakama sahip kart atabilirsiniz.");
                Console.WriteLine("Örneğin: Yerdeki S1 ise S kartlarını ve M1,K1,RD kartlarını atabiliriz.");
                Console.WriteLine("-- Elinizde atacak kart yoksa Renk değiştirme işlemi yapabilirsiniz.Seçtiğiniz renk yerdeki kartın rakamıyla birleşir");
                Console.WriteLine("Örneğin: Yerdeki kart M1 ve oyuncu rengi Kırmızı yapmak isterse yerdekikart K1 olur.");
                Console.WriteLine("-- Elinizde atacak kart ve RD yoksa PAS diyebilirsiniz.");
                Console.WriteLine("-- Oyun oyunculardan birinin elindeki kartın bitmesi ile ya da oyuncuların 3 kere pas demesi ile sona erer.");
                Console.WriteLine("-- Oyun başında RD atamaz ve PAS diyemezsiniz.");
                Console.WriteLine("-- Oyuna başlayacak oyuncu random olarak seçilir ve oyun o şekilde devam eder.");
                Console.WriteLine("Örneğin: 2. başlarsa oyuncular 2-3-1 sırası 3. başlarsa 3-1-2 sırası ile kart atarlar.");
                Console.WriteLine("-- Lütfen Büyük Harf Kullanın");
                Console.WriteLine("Kuralları Kapatmak İçin Lütfen Enter Tuşuna Basın");
                tus = Console.ReadKey();
                Console.Clear();
            } while (tus.Key != ConsoleKey.Enter);
            if (baslangıc == 1)
            {
                do
                {

                    string yenikart = "";
                    int p = 0;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("OYUNA 1.OYUNCU BAŞLIYOR");
                    Console.WriteLine("Oyuna hangi kart ile başlıyorsun:");
                    foreach (var item in kartlar.oyuncu1)
                    {
                        Console.Write(" " + item);
                    }
                    Console.WriteLine();
                    yenikart = Console.ReadLine();
                    //RD yada pas girilirse o sayısı 0 olmaz ve döngü devam eder.
                    for (int i = 0; i < 6; i++)
                    {
                        if (yenikart == kartlar.oyuncu1[i])
                        {
                            if (yenikart == "RD")
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("Oyuna RD ile başlayamazsın."); Console.Beep();
                                o = 1;
                                Console.ResetColor();
                                break;
                            }
                            else
                            {
                                yerdekikart = yenikart;
                                kartlar.oyuncu1[i] = "##";
                                o = 0;
                                p = 1;
                            }
                        }
                        else if (yenikart == "PAS")
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("Oyuna pas ile başlayamazsın."); Console.Beep();
                            o = 1;
                            Console.ResetColor();
                            break;
                        }
                    }

                    if (p == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Hatalı Kart Girişi:"); Console.Beep();
                        o = 1;
                        Console.WriteLine();
                        Console.ResetColor();
                    }
                } while (o == 1);
                Console.WriteLine("1.OYUNCU: {0}", yerdekikart);
                Console.ResetColor();

                yerdekikart = oyuncu2islem(yerdekikart, yerdekikart2, ref sayac);
                yerdekikart = oyuncu3islem(yerdekikart, yerdekikart2, ref sayac);
                //a sayısı 24 olursa oyundaki bir oyuncunun elinde kart kalmamıltır yada 3 kere pas geçilmiştir.
                //a 24 olunca döngü biter.
                do
                {
                    sayac = 0;
                    Console.WriteLine("--------------------------------------------");
                    yerdekikart = oyuncu1islem(yerdekikart, yerdekikart2, ref sayac);
                    a = sonucbelirle(kartlar.oyuncu1, kartlar.oyuncu2, kartlar.oyuncu3);
                    if (a == 24)
                    {
                        break;
                    }

                    yerdekikart = oyuncu2islem(yerdekikart, yerdekikart2, ref sayac);
                    a = sonucbelirle(kartlar.oyuncu1, kartlar.oyuncu2, kartlar.oyuncu3);
                    if (a == 24)
                    {
                        break;
                    }

                    yerdekikart = oyuncu3islem(yerdekikart, yerdekikart2, ref sayac);
                    a = sonucbelirle(kartlar.oyuncu1, kartlar.oyuncu2, kartlar.oyuncu3);
                    if (sayac == 3)
                    {
                        a = 24;
                    }

                } while (a != 24);
            }

            else if (baslangıc == 2)
            {
                do
                {
                    baslangıcdeger = random.Next(0, 6);
                    yerdekikart = kartlar.oyuncu2[baslangıcdeger];
                } while (yerdekikart == "RD");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("OYUNA 2.OYUNCU BAŞLIYOR");
                Console.WriteLine("2.OYUNCU " + yerdekikart);
                kartlar.oyuncu2[baslangıcdeger] = "##";
                Console.ResetColor();

                yerdekikart = oyuncu3islem(yerdekikart, yerdekikart2, ref sayac);
                yerdekikart = oyuncu1islem(yerdekikart, yerdekikart2, ref sayac);
                do
                {
                    sayac = 0;
                    Console.WriteLine("--------------------------------------------");
                    yerdekikart = oyuncu2islem(yerdekikart, yerdekikart2, ref sayac);
                    a = sonucbelirle(kartlar.oyuncu1, kartlar.oyuncu2, kartlar.oyuncu3);
                    if (a == 24)
                    {
                        break;
                    }

                    yerdekikart = oyuncu3islem(yerdekikart, yerdekikart2, ref sayac);
                    a = sonucbelirle(kartlar.oyuncu1, kartlar.oyuncu2, kartlar.oyuncu3);
                    if (a == 24)
                    {
                        break;
                    }

                    yerdekikart = oyuncu1islem(yerdekikart, yerdekikart2, ref sayac);
                    a = sonucbelirle(kartlar.oyuncu1, kartlar.oyuncu2, kartlar.oyuncu3);
                    if (sayac == 3)
                    {
                        a = 24;
                    }

                } while (a != 24);
            }

            else
            {
                do
                {
                    baslangıcdeger = random.Next(0, 6);
                    yerdekikart = kartlar.oyuncu3[baslangıcdeger];
                } while (yerdekikart == "RD");

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("OYUNA 3.OYUNCU BAŞLIYOR");
                Console.WriteLine("3.OYUNCU " + yerdekikart);
                kartlar.oyuncu3[baslangıcdeger] = "##";
                Console.ResetColor();

                yerdekikart = oyuncu1islem(yerdekikart, yerdekikart2, ref sayac);
                yerdekikart = oyuncu2islem(yerdekikart, yerdekikart2, ref sayac);
                do
                {
                    sayac = 0;
                    Console.WriteLine("--------------------------------------------");
                    yerdekikart = oyuncu3islem(yerdekikart, yerdekikart2, ref sayac);
                    a = sonucbelirle(kartlar.oyuncu1, kartlar.oyuncu2, kartlar.oyuncu3);
                    if (a == 24)
                    {
                        break;
                    }

                    yerdekikart = oyuncu1islem(yerdekikart, yerdekikart2, ref sayac);
                    a = sonucbelirle(kartlar.oyuncu1, kartlar.oyuncu2, kartlar.oyuncu3);
                    if (a == 24)
                    {
                        break;
                    }

                    yerdekikart = oyuncu2islem(yerdekikart, yerdekikart2, ref sayac);
                    a = sonucbelirle(kartlar.oyuncu1, kartlar.oyuncu2, kartlar.oyuncu3);
                    if (sayac == 3)
                    {
                        a = 24;
                    }

                } while (a != 24);
            }
            if (sayac == 3)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed; Console.Beep();
                Console.WriteLine("Oyun berabere bitti.");
            }
            else
            {
                if (son1 > son2 && son1 > son3)
                {
                    Console.WriteLine("Son turda elindeki kartı ilk 1.Oyuncu bitirdi");
                    Console.WriteLine("1.OYUNCU KAZANDI");
                }
                else if (son2 > son1 && son2 > son3)
                {
                    Console.WriteLine("Son turda elindeki kartı ilk 2.Oyuncu bitirdi");
                    Console.WriteLine("2.OYUNCU KAZANDI");
                }
                else
                {
                    Console.WriteLine("Son turda elindeki kartı ilk 3.Oyuncu bitirdi");
                    Console.WriteLine("3.OYUNCU KAZANDI");
                }
            }
            Console.ReadLine();
        }
    }
}
