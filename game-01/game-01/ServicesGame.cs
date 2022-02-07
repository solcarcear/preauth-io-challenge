using System;
using System.Collections.Generic;
using System.Linq;

namespace game_01
{
    public class ServicesGame : IServicesGame
    {

        public  int[] GetFirstPosibleArraySum(int[] arr, int target)
        {
            var result = new List<int>();
            if (arr == null || arr.Length < 2)
            {
                return Array.Empty<int>();
            }
            for (int i = 0; i < arr.Length; i++)
            {
                int firstNumber = arr[i];
                int secondNumber = target - firstNumber;
                if(result.Any(x=>x == secondNumber))
                {
                    return new[] { secondNumber, firstNumber };
                }
                result.Add(firstNumber);
            }
            return Array.Empty<int>(); ;
        }
    }
}
