using System;
using System.Runtime;

namespace AlgoDat_praktikum
{
    public class Treap : ServiceBinTree, IDictionary
    {
        // Data
        // Bereits in der ServiceBinTree-Klasse definiert
        // Achtung: beim 'insert' darauf achten ein TreapElement zu erstellen
        //
        // Die Element-Klasse erbt von der TreeElement-Klasse; Methoden muessen wenn noetig ueberschrieben werden.

        // Search
        // Die 'richtige' search-fkt soll nur bool zurueck geben.
        // Da es fuer andere anwendungen praktisch ist mehr rueckgabewerte zu haben lieber 2 search fkt
        // Hier: Nur auswertung des rueckgabewerts der anderen search-Funktion [In BinSearchTree.cs: Zeile 5ff]
        // Andere search-Fkt: Gibt struct zurueck, die in der service Klasse definiert ist. [Habe ich rekursiv geloest -> Siehe TreeElement.cs Z.31ff]

        // Insert
        // Iterative Lsg in der Hauptklasse [BinSearchTree Z.15ff]

        // Delete
        // Iterative Lsg in der Hauptklasse [BinSearchTree Z. 39ff]

        // Print
        // -> Bereits in der ServiceBinTree-Klasse erstellt;
        // Der Ausgabe-Algorithmus (der in ServiceBinTree aufgerufen wird) ist Teil der TreapElement-Klasse (rekusriv geloest) [TreeElement.cs Z16ff]

        // Allgemein:
        // Die meisten Algorithmen koennen in Pseudo-Code-Form in den Aufzeichnungen der VL gefunden werden!
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