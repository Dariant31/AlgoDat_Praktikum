using System;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Reflection;

namespace AlgoDat_praktikum
{
    public class MultiSetSortedLinkedList : IMultiSetSorted
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
        public void AddFirst(int element)
        {
            ElementObject neu = new ElementObject(element);
            if (first == null)
            {
                first = last = neu;
            }
            else
            {
                if (first.context >= element)

                {
                    neu.next = first;
                    first = neu;
                }
            }

        }
        public void AddLast(int element)
        {
            ElementObject neu = new ElementObject(element);
            if (first == null)
            {
                first = last = neu;
            }
            else
            {
                if (last.context < element)
                {
                    last = last.next = neu;

                }
                else if (last.context == element)
                {
                    last = neu;
                }
            }
        }

        public bool Insert(int element)
        {
            bool inserted = false;

            if (first == null || last.context <= element)
            {
                AddLast(element);
                inserted = true;
            }

            else if (first.context >= element)
            {

                AddFirst(element);
                inserted = true;
            }
            else
            {
                ElementObject neu = new ElementObject(element);
                ElementObject item = first;
                while (item.next !=null &&item.next.context < element)
                {
                    item = item.next;
                                  
                }
                if (item.next.context == element || item.next.context > element)
                {
                    neu.next = item.next;
                    item.next = neu;
                }

                inserted = true;

            }
            return inserted;
        }


        public bool Delete(int element)
        {
            bool deleted = false;
            if (first == null)
                throw new ArgumentNullException();
            if(first.context ==element)
            {
                while (first.next.context == element)
                    first = first.next;
                first = first.next;
                if (first == null)
                    last = null;
                deleted = true;
            }
            else
            {
                ElementObject item = first;
                while (item.next != null && item.next.context != element)
                    item = item.next;
                if(item.next!= null)
                {
                    item.next = item.next.next;
                    if(item.next !=null)
                    {
                        item.next = item.next.next;
                    }
                    if (item.next == null)
                        last = item;
                    deleted = true;
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