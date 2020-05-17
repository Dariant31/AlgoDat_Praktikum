using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDat_praktikum
{
    public class SetUnsortedArray : MultiSetUnsortedArray, ISet
    {
        public new bool Insert(int elem)
        {
            if (!Search(elem))
            {
                base.Insert(elem);
                return true;
            }

            return false;
        }
    }
}
