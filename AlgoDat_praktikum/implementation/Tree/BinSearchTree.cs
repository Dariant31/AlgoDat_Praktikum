namespace AlgoDat_praktikum
{
    public class BinSearchTree : ServiceBinTree, ISetSorted
    {
        //public TreeElement data = new TreapElementObject();

        public bool Search(int element)
        {
            if (data == null)
            {
                return false;
            }

            return data.SearchElement(element).foundElement;
        }

        //public bool Insert(int element)
        //{
        //    if (data == null)
        //    {
        //        data = new TreeElement(element);
        //        return true;
        //    }

        //    return data.InsertElement(element);
        //}

        public bool Insert(int element)
        {
            if (data == null) return false;

            SearchResult res = data.SearchElement(element);

            if (res.foundElement) return false; // Element found

            if (res.found.GetContent() < element)
            {
                res.found.left = new TreeElement(element);
            }
            else
            {
                res.found.right = new TreeElement(element);
            }

            return true;
        }

        public bool Delete(int element)
        {
            SearchResult res = data.SearchElement(element);

            if (res.foundElement == false) return false; // Element not found

            if (res.found.left == null && res.found.right == null) // Element found is a leaf
            {
                if (res.previous == null) // Root (leaf) has to be removed
                {
                    data = null;
                    return true;
                }

                if (res.previous.left == res.found)
                {
                    res.previous.left = null;
                }
                else if (res.previous.right == res.found)
                {
                    res.previous.right = null;
                }

                return true;
            }

            if (res.found.left == null || res.found.right == null)
            {
                TreeElement tmp = null;

                if (res.found.left != null) tmp = res.found.left;
                else if (res.found.right != null) tmp = res.found.right;

                if (res.previous == null) // Root has to be removed
                {
                    data = tmp;
                }

                if (res.previous.left == res.found)
                {
                    res.previous.left = tmp;
                }
                else if (res.previous.right == res.found)
                {
                    res.previous.right = tmp;
                }

                return true;
            }

            if (res.found.left != null && res.found.right != null)
            {
                DelSymPred(res.found);
                return true;
            }

            return false; // Sth went wrong
        }

        private void DelSymPred(TreeElement node)
        {
            TreeElement biggestSuccessor, tmp;

            // Get biggest successor (symmetric predecessor)
            biggestSuccessor = node;
            if (biggestSuccessor.left.right != null)
            {
                biggestSuccessor = biggestSuccessor.left;
                while (biggestSuccessor.right.right != null)
                {
                    biggestSuccessor = biggestSuccessor.right;
                }
            }

            if (biggestSuccessor == node)
            {
                tmp = biggestSuccessor.left;
                biggestSuccessor.left = tmp.left;
            }
            else
            {
                tmp = biggestSuccessor.right;
                biggestSuccessor.right = tmp.left;
            }
            node.content = tmp.content;
        }
    }
}