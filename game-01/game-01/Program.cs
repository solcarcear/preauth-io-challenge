using System;
using System.Linq;
using System.Collections.Generic;

namespace game_01
{
    public class Program
    {
        static void Main(string[] args)
        {     
            var m = GetArrayInt();
            var n = GetSumValue();
            var arrResult = GetFirstPosibleArraySum(m,n);//GAME-01

            Console.WriteLine($"<<<<<<<<<<ENTRIES>>>>>>>>>>");
            Console.WriteLine($"M=[{string.Join("|", m)}] | N={n}");
            Console.WriteLine($"<<<<<<<<<<RESULT>>>>>>>>>>");
            Console.WriteLine($"Result=[{string.Join("|", arrResult)}]");

            Console.ReadKey();
        }
        public static int[] GetArrayInt()
        {
            string arrStr = "";
            Console.WriteLine("Specify a number or several separated by Comma:");
            arrStr = Console.ReadLine();

            var result = new List<int>();
            try
            {
                result = arrStr.Split(",").Select(x => int.Parse(x)).ToList();
                return result.ToArray();
            }
            catch (Exception e)
            {
                //internalLog.Add(e);
                Console.WriteLine("Wrong entrie!");
                return GetArrayInt();
            }

        }

        public static int GetSumValue()
        {
            Console.WriteLine("Specify a number:");
            string num = Console.ReadLine();
            try
            {
                return int.Parse(num);
            }
            catch (Exception e)
            {
                //internalLog.Add(e);
                Console.WriteLine("Wrong entrie!");
                return GetSumValue();
            }

        }



        public static int[] GetFirstPosibleArraySum(int[] arr, int target)
        {
            var result = new Dictionary<int, int>();
            if (arr == null || arr.Length < 2)
            {
                return Array.Empty<int>();
            }
            for (int i = 0; i < arr.Length; i++)
            {
                int firstNumber = arr[i];
                int secondNumber = target - firstNumber;
                if (result.TryGetValue(secondNumber, out int index))
                {
                    return new[] { secondNumber, firstNumber };
                }
                result[firstNumber] = i;
            }
            return Array.Empty<int>(); ;
        }

 



    }
}
