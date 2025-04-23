namespace LongestIncreasingSubsequence
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    internal class Program
    {
        private static void Main(string[] args)
        {
            int[] nums = { 3, 14, 5, 12, 15, 7, 8, 9, 11, 10, 1 };//Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[] len = new int[nums.Length];

            int[] perv = new int[nums.Length];
            int previousPosition = -1;
            int index = 0;

            List<int> list = Recursion(nums, len, perv, previousPosition, index);


            //for (int i = 0; i < nums.Length; i++)
            //{
                
            //    int closerElement = int.MaxValue;
            //    int index = -1;

            //    List<int> currList = new List<int>();

            //    for (int j = i; j < nums.Length; j++)
            //    {
            //        int element = nums[i];
            //        int currElement = nums[j];
            //        int currListElement = currList[currList.Count - 1];

            //        if (element == currElement)
            //        {
            //            continue;
            //        }

            //        if (element < currElement && currList[currList.Count - 1] < currElement)
            //        {
            //            closerElement = currElement;
            //            currList.Add(element);
            //            len[i] = currList.Count;
            //            perv[i] = index;
            //            index = i;

            //        }
            //        else if (element < currElement && currElement < closerElement 
            //            && currElement < currList[currList.Count - 1])
            //        {
            //            currList.RemoveAt(currList.Count - 1);
            //            currList.Add(currElement);

            //        }
            //    }
            //}

        }

        private static List<int> Recursion(int[] nums, int[] len, int[] perv, int previousPosition, int index)
        {
            List<int> list = new List<int>();

            if (index == nums.Length)
            {
                return list;
            }



            for (int i = 0; i < nums.Length; i++)
            {
                
            }

            return list;
        }
    }
}