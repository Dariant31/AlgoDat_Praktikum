using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDat_praktikum
{
    class TreapElement : AVLElement
    {

        public int heap;

        public TreapElement(int element, int heap) : base(element)
        {
            this.heap = heap;
        }
    }
}
