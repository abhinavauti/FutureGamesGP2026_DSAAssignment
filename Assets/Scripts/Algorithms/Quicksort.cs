using System;

namespace Algorithms
{
    public static class Quicksort
    {
        public static void Sort<T>(T[] items, int left, int right, Func<T, T, bool> isBefore)
        {
            if(left >= right)
            {
                return;
            }

            int middle = (left + right) / 2;
            T pivot = items[middle];

            int leftIndex = left;
            int rightIndex = right;

            while(leftIndex <= rightIndex)
            {
                while(isBefore(items[leftIndex], pivot))
                {
                    leftIndex++;
                }

                while(isBefore(pivot, items[rightIndex]))
                {
                    rightIndex--;
                }

                if(leftIndex <= rightIndex)
                {
                    T temp = items[leftIndex];
                    items[leftIndex] = items[rightIndex];
                    items[rightIndex] = temp;

                    leftIndex++;
                    rightIndex--;
                }
            }

            Sort(items, left, rightIndex, isBefore);
            Sort(items, leftIndex, right, isBefore);
        }
    }
}
