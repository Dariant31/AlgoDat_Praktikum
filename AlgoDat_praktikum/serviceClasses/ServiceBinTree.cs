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

    public class ServiceBinTree
    {
        protected TreeElement data;

        public void Print()
        {
            if (data != null)
                data.PrintElement();
        }
    }
}
