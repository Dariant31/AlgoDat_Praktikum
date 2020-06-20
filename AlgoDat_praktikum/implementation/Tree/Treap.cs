using System;
using System.Runtime;

namespace AlgoDat_praktikum
{
    public class Treap : ServiceBinTree, IDictionary
    {
        TreapElement data;

        public void Print()
        {
            base.Print(data);
        }

        public bool Search(int element)
        {
            return base.Search(data, element);
        }

        public bool Insert(int element)
        {
            int heap = Convert.ToInt32((Console.ReadLine()));
            InfoReturn res = base.Insert(data, new TreapElement(element, heap));
            if (res.success)
                data = (TreapElement)res.newRoot;

            DownHeap(element);
           
            return res.success;
        }

        public bool Delete(int element)
        {
            // Pruefen, ob Element Exist
            if (!base.Search(data, element)) //Element nicht gefunden
                return false;

            // Element zu Blatt machen
            UpHeap(element);

            // Element loeschen
            InfoReturn res = base.Delete(data, element);
            if (res.success)
               data = (TreapElement)res.newRoot;
            
            return res.success;
        }

        // Support methods
        private void DownHeap(int element)
        {
            SearchResult s = data.SearchElement(element);
            TreapElement current = (TreapElement)s.previous;
            bool isLeft;

            while (!HeapReq(current))
            { 
                isLeft = (current.left == s.found) ? true : false;

                if (isLeft)
                    current.LeftRotation();
                else
                    current.RightRotation();

                s = data.SearchElement(element);
                current = (TreapElement)s.previous;
            }
        }

        private bool HeapReq(TreapElement e)
        {
            TreapElement l = null, r = null;

            if (e == null)
                return true;

            if (e.left != null)
                l = (TreapElement)e.left;

            if (e.right != null)
                r = (TreapElement)e.right;

            if ((l == null || l.heap > e.heap) && (r == null || r.heap > e.heap))
                return true;
            else
                return false;
        }

        private void UpHeap(int element)
        {
            SearchResult s = data.SearchElement(element);
            TreapElement current = (TreapElement)s.found;
            TreapElement l = (TreapElement)current.left, r = (TreapElement)current.right;

            while (current.left != null && current.right != null)
            {

                if (l != null && l.heap <= r.heap)
                    current.LeftRotation();
                else
                    current.RightRotation();


                s = data.SearchElement(element);
                current = (TreapElement)s.found;
                l = (TreapElement)current.left;
                r = (TreapElement)current.right;
            }
        }
    }
}