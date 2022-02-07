using System;
using System.Linq;
using System.Collections.Generic;

namespace game_01
{
    public class Program
    {
        static void Main(string[] args)
        {
            var services = new Services(new ServicesGame());

            var m = services.GetArrayInt();
            var n = services.GetSumValue();
            var arrResult = services.GetSubsetArraySum(m,n);

            Console.WriteLine($"<<<<<<<<<<ENTRIES>>>>>>>>>>");
            Console.WriteLine($"M=[{string.Join("|", m)}] | N={n}");
            Console.WriteLine($"<<<<<<<<<<RESULT>>>>>>>>>>");
            Console.WriteLine($"Result=[{string.Join("|", arrResult)}]");

            Console.ReadKey();
        }



    }
}
