namespace AlgoDat_praktikum
{
    public class SetUnsortedLinkedList : SetSortedLinkedList, ISet
    {
        public ElementObject last;
        
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
                // das neue Element wird am Ende hinzu gefügt
                last.next = neu;
                last = last.next;

            }
            return inserted;
        }
    }      
    
}