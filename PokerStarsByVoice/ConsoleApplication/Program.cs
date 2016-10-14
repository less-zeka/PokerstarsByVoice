using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    class Program
    {

        static void Main(string[] args)
        {
            PokerPlayer pokerPlayer = new PokerPlayer();


            Console.WriteLine("Press Enter to stop");
            do
            {
                while (!Console.KeyAvailable)
                {
                    // Do something
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Enter);
        }




          

    }
}
