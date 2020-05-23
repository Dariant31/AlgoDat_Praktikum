using System;

namespace AlgoDat_praktikum
{
    public class TreeElement
    {
        public TreeElement left;
        public TreeElement right;
        public int content;

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
    }
}