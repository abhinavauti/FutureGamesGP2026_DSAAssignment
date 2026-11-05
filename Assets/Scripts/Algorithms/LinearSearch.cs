using System;

namespace Algorithms
{
    public static class LinearSearch
    {
        public static T[] FindRange<T, TKey>(T[] items, TKey min, TKey max, Func<T, TKey, int> compare)
        {
            T[] matches = new T[items.Length];
            int count = 0;

            for(int i = 0; i < items.Length; i++)
            {
                if(compare(items[i], min) >= 0 && compare(items[i], max) <= 0)
                {
                    matches[count] = items[i];
                    count++;
                }
            }

            T[] results = new T[count];

            for(int i = 0; i < count; i++)
            {
                results[i] = matches[i];
            }

            return results;
        }
    }
}
