using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDat_praktikum
{
    public class SetSortedArray : MultiSetSortedArray, ISetSorted
    {
        public new bool Insert(int elem)
        {
            if (base.Search(elem)) return false;
            base.Insert(elem);
            return true;

        }
    }
}