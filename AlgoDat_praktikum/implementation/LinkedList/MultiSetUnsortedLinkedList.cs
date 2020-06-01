using Microsoft.Win32;
using System;

namespace AlgoDat_praktikum
{
    public class MultiSetUnsortedLinkedList : IMultiSet
    {

        public ElementObject first;
        public ElementObject last;

        public bool Search(int element)
        {

            for (ElementObject item = first; item != null; item = item.next)
            {
                if (item.context == element)
                {
                    return true;
                }

            }
            return false;
        }

        public bool Insert(int element)
        {
            bool inserted = false;
            ElementObject neu = new ElementObject();
            neu.context = element;

            //1. Fall Liste ist leer
            if (first == null)
            {
                first = last = neu;
                inserted = true;
            }
            //2. Das neue Element wird am Ende der Liste hinzugefügt
            else
            {
                last.next = neu;
                last = last.next;
            }

            return inserted;
        }

        public bool Delete(int element)
        {
            bool deleted = false;
            //1. Liste ist leer
            if (first == null)
            {

                deleted = false;
            }
            //2. Liste besteht aus einem Element
            else if (first == last)
            {
                first = last = null;
                deleted = true;
            }
            //3. Liste besteht aus mehreren Elementen
            else
            {
                ElementObject item = first;
                // Durchlauf der Liste
                // solange Elemente in Liste vorhanden und gesuchtes Element noch nicht gefunden
                while (item.next != null && item.next.context != element)
                    item = item.next;
                //das zu löschende Element ist in der Nth Stelle
                if (item.next != null)
                    item.next = item.next.next;
                // wenn letztes Element am Ende der Liste ist
                if (item.next == null)
                {
                    last = item;
                }

            }
            return deleted;
        }

        public void Print()
        {
            for (ElementObject item = first; item != null; item = item.next)
            {
                Console.WriteLine(item.context);
            }
        }


    }
}