using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnoGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Oyun oyun = new Oyun();
            oyun.baslat();
            oyun.oyunIslem();
            Console.ReadLine();
        }
    }
}
