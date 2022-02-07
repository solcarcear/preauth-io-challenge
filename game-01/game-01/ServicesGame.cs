using System;
using System.Collections.Generic;
using System.Linq;

namespace game_01
{
    public class ServicesGame : IServicesGame
    {

        public  int[] GetFirstPosibleArraySum(int[] arr, int target)
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
                if(result.TryGetValue(secondNumber, out int index))
                {
                    return new[] { secondNumber, firstNumber };
                }
                result[firstNumber] = i;
            }
            return Array.Empty<int>(); ;
        }
    }
}
