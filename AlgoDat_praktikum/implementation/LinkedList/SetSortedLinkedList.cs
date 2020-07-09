using System;
using System.CodeDom;
using System.ComponentModel;

namespace AlgoDat_praktikum
{
    public class SetSortedLinkedList : MultiSetSortedLinkedList, ISetSorted
    {

        public new bool Insert(int element)
        {
            bool inserted = false;
            ElementObject neu = new ElementObject(element);


            //1. Fall Liste ist leer
            if (first == null || first.context > element)
            {
                AddFirst(element);
                inserted = true;
            }

            //3. Fall Liste besteht nicht in der Liste vorhanden
            else if (Search(element) == false)
            {


                ElementObject item = first;
                // Durchsuche der Liste bis die Position zum Hinzufügen gefunden wird
                while (item.next != null && item.next.context < element)
                {
                    item = item.next;
                }
                // die Position wird gefunden
                neu.next = item.next;
                item.next = neu;

            }
            else
            {
                throw new Exception("This Element already exists in the linked list");
            }
                

            inserted = true;
            return inserted;
        }
    }
}