
using System;
using System.Collections.Generic;
using System.Linq;

namespace game_01
{
 
    public class Services
    {
        private readonly IServicesGame _ServicesGame;
        public Services(IServicesGame servicesGame)
        {
            _ServicesGame = servicesGame;
        }

        public int[] GetSubsetArraySum(int[]m,int n) {
            return _ServicesGame.GetFirstPosibleArraySum(m,n);
        }

         
        public  int[] GetArrayInt()
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

        public  int GetSumValue()
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

    }
}
