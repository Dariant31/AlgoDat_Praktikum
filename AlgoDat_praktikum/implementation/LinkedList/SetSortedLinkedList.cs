using System;
using System.ComponentModel;

namespace AlgoDat_praktikum
{
    public class SetSortedLinkedList : MultiSetSortedLinkedList, ISetSorted
    {

        public new bool Insert(int element)
        {
            bool inserted = false;
            ElementObject neu = new ElementObject();
            neu.context = element;

            //1. Fall Liste ist leer
            if (first == null)
            {
                first = neu;
                inserted = true;
            }
            //2. Fall Liste besteht aus mindesten einem Element
            // und die Element ist schon in der Liste vorhanden
            if (Search(element) == true)
            {
                inserted = false;

            }
            //3. Fall Liste besteht nicht in der Liste vorhanden
            else if (Search(element) == false)
            {
                ElementObject item = first;
                // Durchsuche der Liste bis die Position zum Hinzufügen gefunden wird
                while (item != null && item.next.context < element)
                {
                    item = item.next;
                }
                // die Position wird gefunden
                neu.next = item.next;
                item.next = neu;

            }
            return inserted;
        }
    }
}