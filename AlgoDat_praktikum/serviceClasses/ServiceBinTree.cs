using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDat_praktikum
{
    public struct SearchResult
    {
        public SearchResult(bool foundElement, TreeElement found, TreeElement previous)
        {
            this.foundElement = foundElement;
            this.found = found;
            this.previous = previous;
        }

        public bool foundElement;
        public TreeElement found;
        public TreeElement previous;
    }

    public struct InfoReturn
    {
        public InfoReturn(bool success, TreeElement newRoot)
        {
            this.success = success;
            this.newRoot = newRoot;
        }

        public bool success;
        public TreeElement newRoot;
    }

    public class ServiceBinTree
    {
        public void Print(TreeElement root)
        {
            if (root != null)
                root.PrintElement();
        }

        public bool Search(TreeElement root, int element) // (1)
        {
            if (root == null)
            {
                return false;
            }

            return root.SearchElement(element).foundElement;
        }

        public InfoReturn Insert(TreeElement root, TreeElement e)
        {
            if (root == null)
                return new InfoReturn(true, e);

            SearchResult res = root.SearchElement(e.content);

            if (res.foundElement) return new InfoReturn(false, root); // Element found

            if (res.found.content > e.content)
            {
                res.found.left = e;
            }
            else
            {
                res.found.right = e;
            }

            return new InfoReturn(true, root);
        }

        public InfoReturn Delete(TreeElement root, int element)
        {
            SearchResult res = root.SearchElement(element);

            // Element not found
            if (res.foundElement == false) return new InfoReturn(false, root);

            // Element has no successors
            if (res.found.left == null && res.found.right == null) // Element found is a leaf
            {
                if (res.previous == null) // Root (leaf) has to be removed
                {
                    root = null;
                    return new InfoReturn(true, root);
                }

                DelFromLine(res.previous, res.found, null);
                return new InfoReturn(true, root);
            }

            // Element has only one successor
            if ((res.found.left == null) != (res.found.right == null))
            {
                TreeElement tmp = null;

                if (res.found.left != null) tmp = res.found.left;
                else if (res.found.right != null) tmp = res.found.right;

                if (res.previous == null) // Root has to be removed
                {
                    root = tmp;
                }

                DelFromLine(res.previous, res.found, tmp);
                return new InfoReturn(true, root);
            }

            // Element hast two successors
            if (res.found.left != null && res.found.right != null)
            {
                DelSymmetricPredecessor(res.found);
                return new InfoReturn(true, root);
            }

            return new InfoReturn(false, root); // Sth went wrong
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
