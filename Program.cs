using System;
using System.Collections;
using System.Collections.Generic;

namespace MaxTest
{
    class MyArr : IList<int>
    {
        private readonly int[] firstArr;
        private readonly int[] secondArr;
        private readonly int firstLength;
        private readonly int secondLength;
        public MyArr(int[] a, int[] b)
        {
            firstArr = a;
            secondArr = b;
            firstLength = a.Length;
            secondLength = b.Length;
        }
        public int this[int index] { get => index < firstLength ? firstArr[index] : secondArr[index - firstLength]; set { if (index < firstLength) firstArr[index] = value; else secondArr[index - firstLength] = value; } }

        public int Count => firstArr.Length + secondArr.Length;

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(int item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(int item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(int[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<int> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public int IndexOf(int item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, int item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
    class Program
    {
        static int Partition(IList<int> array, int minIndex, int maxIndex)
        {
            var pivot = minIndex - 1;
            for (var i = minIndex; i < maxIndex; i++)
            {
                if (array[i] < array[maxIndex])
                {
                    pivot++;
                    var tmp2 = array[pivot];
                    array[pivot] = array[i];
                    array[i] = tmp2;
                }
            }

            pivot++;
            var tmp = array[pivot];
            array[pivot] = array[maxIndex];
            array[maxIndex] = tmp;
            return pivot;
        }

        static IList<int> QuickSort(IList<int> array, int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex)
            {
                return array;
            }

            var pivotIndex = Partition(array, minIndex, maxIndex);
            QuickSort(array, minIndex, pivotIndex - 1);
            QuickSort(array, pivotIndex + 1, maxIndex);

            return array;
        }
        static IList<int> Merge(int[] firstArr, int[] secondArr)
        {
            if (firstArr == null)
                throw new ArgumentNullException("firstArr");
            if (secondArr == null)
                throw new ArgumentNullException("secondArr");
            var merged = new MyArr(firstArr, secondArr);
            QuickSort(merged, 0, firstArr.Length + secondArr.Length - 1);
            return merged;
        }
        static void Main(string[] args)
        {
            var first = new int[] { 2, 4, 5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27 };
            var second = new int[] { 1, 3,28,29,30 };
            var res = Merge(first,second);
            for (int i = 0; i < res.Count; i++)
                Console.WriteLine(res[i]);
        }
    }
}
