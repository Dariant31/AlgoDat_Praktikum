using System;

namespace AlgoDat_praktikum
{
    public class TreeElement
    {
        public TreeElement left;
        public TreeElement right;
        public int content;

        public TreeElement(int c)
        {
            content = c;
        }

        public void PrintElement()
        {
            if (left != null)
            {
                left.PrintElement();
            }

            Console.WriteLine(content);

            if (right != null)
            {
                right.PrintElement();
            }
        }

        public SearchResult SearchElement(int e, TreeElement prev = null)
        {
            if (e < content)
            {
                if (left != null)
                {
                    return left.SearchElement(e, this);
                }
                return new SearchResult(false, this, prev);
            }
            else if (e > content)
            {
                if (right != null)
                {
                    return right.SearchElement(e, this);
                }
                return new SearchResult(false, this, prev);
            }

            // Element found
            return new SearchResult(true, this, prev);
        }
    }
}