using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDat_praktikum
{
    public class MultiSetSortedArray : AbstractArrayServices, IMultiSetSorted
    {
        private int _localisation;

        public bool Delete(int elem)
        {
            if (Search(elem))
            {
                for (int i = 0; i < data.Length; i++)
                {
                    if (i >= _localisation)
                    {
                        data[i] = (data.LongLength - 1 > i) ? data[i + 1] : 0;
                    }
                }

                return true;
            }

            return false;
        }

        public bool Insert(int elem)
        {
            Search(elem);
            for (int i = data.Length - 1; i >= 0; i--)
            {
                if (i == _localisation)
                {
                    data[i] = elem;
                    break;
                }

                data[i] = data[i - 1];
            }

            return true;
        }

        public bool Search(int elem)
        {
            int min = 0;
            int max = getMax();
            int mid = 0;
            bool isFound = false;

            // Binary Search
            while (min <= max)
            {
                mid = (min + max) / 2;
                if (elem == data[mid])
                {
                    isFound = true;
                    break;
                }
                else if (elem < data[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }

            _localisation = mid;
            return isFound;
        }

        private int getMax()
        {
            int j = 0;
            for (int i = data.Length - 1; i >= 0; i--)
            {
                j++;
                if (data[i] == 0) continue;
                return (j > 1) ? i + 1 : i;
            }

            return (data.Length == j)? 0 : data.Length;
        }
    }
}