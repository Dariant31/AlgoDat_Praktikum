namespace AlgoDat_praktikum
{
    public class BinSearchTree : ServiceBinTree, ISetSorted
    {
        public bool Search(int element) // (1)
        {
            if (data == null)
            {
                return false;
            }

            return data.SearchElement(element).foundElement;
        }

        public bool Insert(int element)
        {
            if (data == null)
            {
                data = new TreeElement(element);
                return false;
            }

            SearchResult res = data.SearchElement(element);

            if (res.foundElement) return false; // Element found

            if (res.found.content > element)
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

            // Element not found
            if (res.foundElement == false) return false; 

            // Element has no successors
            if (res.found.left == null && res.found.right == null) // Element found is a leaf
            {
                if (res.previous == null) // Root (leaf) has to be removed
                {
                    data = null;
                    return true;
                }

                DelFromLine(res.previous, res.found, null);
                return true;
            }

            // Element has only one successor
            if ((res.found.left == null) != (res.found.right == null))
            {
                TreeElement tmp = null;

                if (res.found.left != null) tmp = res.found.left;
                else if (res.found.right != null) tmp = res.found.right;

                if (res.previous == null) // Root has to be removed
                {
                    data = tmp;
                }

                DelFromLine(res.previous, res.found, tmp);
                return true;
            }

            // Element hast two successors
            if (res.found.left != null && res.found.right != null)
            {
                DelSymmetricPredecessor(res.found);
                return true;
            }

            return false; // Sth went wrong
        }

        // Support Methods
        private void DelFromLine(TreeElement predecessor, TreeElement toBeDeleted, TreeElement successor)
        {
            if (predecessor.left == toBeDeleted)
            {
                predecessor.left = successor;
            }
            else
            {
                predecessor.right = successor;
            }
        }

        private void DelSymmetricPredecessor(TreeElement node)
        {
            TreeElement biggestSuccessor, tmp;

            // Get biggest successor (symmetric predecessor)
            biggestSuccessor = GetBiggestSuccessor(node);

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

        private TreeElement GetBiggestSuccessor(TreeElement node) // Get symmetric predecessor
        {
            TreeElement biggestSuccessor;

            biggestSuccessor = node;
            if (biggestSuccessor.left.right != null)
            {
                biggestSuccessor = biggestSuccessor.left;
                while (biggestSuccessor.right.right != null)
                {
                    biggestSuccessor = biggestSuccessor.right;
                }
            }

            return biggestSuccessor;
        }
    }
}