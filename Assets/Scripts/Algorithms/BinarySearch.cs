using System;

namespace Algorithms
{
    public static class BinarySearch
    {
        public static T[] FindRange<T, TKey>(T[] items, TKey min, TKey max, Func<T, TKey, int> compare)
        {
            int leftIndex = 0;
            int rightIndex = items.Length - 1;
            int foundIndex = -1;

            while(leftIndex <= rightIndex)
            {
                int middle = (leftIndex + rightIndex) / 2;

                if(compare(items[middle], min) < 0)
                {
                    leftIndex = middle + 1;
                }
                else if(compare(items[middle], max) > 0)
                {
                    rightIndex = middle - 1;
                }
                else
                {
                    foundIndex = middle;
                    break;
                }
            }

            if(foundIndex == -1)
            {
                return new T[0];
            }

            int firstIndex = foundIndex;

            while(firstIndex > 0 && compare(items[firstIndex - 1], min) >= 0)
            {
                firstIndex--;
            }

            int lastIndex = foundIndex;

            while(lastIndex < items.Length - 1 && compare(items[lastIndex + 1], max) <= 0)
            {
                lastIndex++;
            }

            T[] results = new T[lastIndex - firstIndex + 1];

            for(int i = 0; i < results.Length; i++)
            {
                results[i] = items[firstIndex + i];
            }

            return results;
        }
    }
}
