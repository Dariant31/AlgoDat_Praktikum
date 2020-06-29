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

        public override void LeftRotation()
        {
            TreapElement r = (TreapElement)right;

            int tmp = heap;
            heap = r.heap;
            r.heap = tmp;

            base.LeftRotation();
        }

        public override void RightRotation()
        {
            TreapElement l = (TreapElement)left;

            int tmp = heap;
            heap = l.heap;
            l.heap = tmp;
            

            base.RightRotation();
        }
    }
}
