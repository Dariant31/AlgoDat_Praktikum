using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDat_praktikum
{
    class TreapElement : AVLElement
    {
        int prio;

        public TreapElement(int element, int prio) : base(element)
        {
            this.prio = prio;
        }
    }
}
