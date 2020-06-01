using System;
namespace AlgoDat_praktikum
{
    public class MultiSetSortedLinkedList : IMultiSetSorted
    {
        public ElementObject context;
        public ElementObject first;

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
                first = neu;
                inserted = true;
            }
            //2. Fall Liste besteht nicht in der Liste vorhanden
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
            //3. Fall Liste besteht aus mindesten einem Element
            // und die Element ist schon in der Liste vorhanden
            if (Search(element) == true)
            {
                ElementObject item = first;
                // Durchsuche der Liste bis die Position 
                // hinter der bereits vorhandender Element zum Hinzufügen gefunden wird
                while (item != null && item.next.context != element)
                {
                    item = item.next;
                }
                // die Position wird gefunden
                neu.next = item.next;
                item.next = neu;

            }
            
            return inserted;
        }

        public bool Delete(int element)
        {
            bool deleted = false;
            //1. Fall: Leere Liste
            if (first is null)
            {
                throw new ArgumentNullException("The Linked List is empty");

            }

            //2. Fall: Liste besteht aus mindestens 1 Element 
            // aber Element ist nicht vorhanden
            if (Search(element) == false)
            {
                deleted = false;
            }
            //3.Fall: Liste besteht aus mindestens 1 Element 
            // Element ist vorhanden
            else if (Search(element) == true)
            {
                ElementObject item = first;
                // wenn gesuchtes Element das erste Element ist
                if (first.context == element)
                    first = first.next;
                // Durchsuche in der Liste 
                // solange das Element nicht gefunden wird
                while (item != null && item.next.context != element)
                {
                    item = item.next;
                }
                // das Element wird in der Position gelöscht
                item = item.next.next;
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