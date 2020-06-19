namespace AlgoDat_praktikum
{
    public class AvlTree : ServiceBinTree, ISetSorted
    {
        // Data
        // Bereits in der ServiceBinTree-Klasse definiert
        // Achtung: beim 'insert' darauf achten ein AvlTreeElement zu erstellen
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
        // Der Ausgabe-Algorithmus (der in ServiceBinTree aufgerufen wird) ist Teil der AvlTreeElement-Klasse (rekusriv geloest) [TreeElement.cs Z16ff]

        // Tipp:
        // Die meisten Algorithmen koennen in Pseudo-Code-Form in den Aufzeichnungen der VL gefunden werden!

        private AVLElement data;

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
            InfoReturn res = base.Insert(data, new AVLElement(element));
            if (res.success == false)
                return false;

            data = (AVLElement)res.newRoot;

            BalanceTree();

            return true;
        }

        public bool Delete(int element)
        {
            // delete from class BinSearchTree
            InfoReturn res = base.Delete(data, element);
            if (res.success == false)
                return false;

            data = (AVLElement)res.newRoot;
            do BalanceTree();
            while (data.BFSearch() != null);

            return true;
        }


        // Support Methods
        private void BalanceTree()
        {
            data.HeightCalc();
            AVLElement e = data.BFSearch();
            
            if (e == null)
                return;


            AVLElement l = (AVLElement)e.left;
            AVLElement r = (AVLElement)e.right;

            if (e.BalanceFactor() == -2)
            {   // -- and - (single rotation)
                if (l.BalanceFactor() == -1)
                {
                    e.RightRotation();
                }
                
                // -- and + (double rotation)
                else if (l.BalanceFactor() == 1)
                {
                    l.LeftRotation();
                    e.RightRotation();
                }
            }

            else if (e.BalanceFactor() == 2)
            {   // ++ and + (single rotation)
                if (r.BalanceFactor() == 1)
                {
                    e.LeftRotation();
                }             

                // ++ and - (double rotation)
                else if (r.BalanceFactor() == -1)
                {
                    r.RightRotation();
                    e.LeftRotation();
                }
            }
        }

        //public AVLElement RightRotation(AVLElement e)
        //{
        //    AVLElement temp = new AVLElement(0);
        //    AVLElement clone = ((AVLElement)left);
        //    temp = (AVLElement)clone.right;
        //    clone.right = e;
        //    clone.right.left = temp;
        //    return clone;
        //}

        //        public AVLElement LeftRotation()
        //{
        //    AVLElement temp = new AVLElement(0);
        //    AVLElement clone = ((AVLElement)right);
        //    temp = (AVLElement)clone.left;
        //    clone.left = this;
        //    clone.left.right = temp;
        //    return clone;
        //}
    }
}