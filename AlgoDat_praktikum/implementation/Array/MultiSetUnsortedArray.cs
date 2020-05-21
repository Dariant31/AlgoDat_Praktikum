using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDat_praktikum
{
    public class MultiSetUnsortedArray : AbstractArrayServices, IMultiSet
    {
        private int _localisation;
        private int _nextFreePosition;

        public bool Delete(int elem)
        {
            if (!Search(elem)) return false;
            data[_localisation] = data[_nextFreePosition - 1];
            data[_nextFreePosition - 1] = 0;
            return true;
        }

        public bool Insert(int elem)
        {
            Search(elem);
            
            // 7 means there is no space left in the array
            // because the arrayLength is Fixed at 7
            if (_nextFreePosition == 7) return false;
            data[_nextFreePosition] = elem;
            return true;
        }

        public bool Search(int elem)
        {
            _nextFreePosition = 7;
            bool isFound = false;

            // Linear Search
            for (int i = 0; i < data.Length; i++)
            {
                // search for element
                if (elem == data[i])
                {
                    _localisation = i;
                    isFound = true;
                }

                // search for nextFreePosition
                if (data[i] != 0) continue;
                _nextFreePosition = i;
                break;
            }

            _localisation = (isFound) ? _localisation : _nextFreePosition;
            return isFound;
        }
    }
}
