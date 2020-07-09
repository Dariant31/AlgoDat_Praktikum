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
            ElementObject neu = new ElementObject(element);

            //1. Fall Liste ist leer
            if (first == null)
            {
                first = last = neu;
               
            }
            //2. Das neue Element wird am Ende der Liste hinzugefügt
            else
            {
                last.next = neu;
                last = last.next;
            }
            inserted = true;

            return inserted;
        }

        public bool Delete(int element)
        {
            bool deleted = false;
            if (first == null)
            {
                throw new ArgumentException("The Linked List is empty");
            }

            if (first.context == element)
            {

                if (first.next.context == element)
                {
                    first = first.next.next;
                }
                else
                    first = first.next;           

            }
                
            else
            {
                ElementObject item = first;
                while (item.next != null && item.next.context != element)
                    item = item.next;
                if (item.next != null)
                {
                    if (item.next.next.context == element)
                    {
                        item.next = item.next.next.next;
                    }
                    else
                    {
                        item.next = item.next.next;
                    }
                    if (item.next == null)
                        last = item;
                }
               

            }

            deleted = true;
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