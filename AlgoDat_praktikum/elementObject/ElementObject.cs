using System;

namespace AlgoDat_praktikum
{
    public class ElementObject : Object
    {
        public int context;
        public ElementObject next;

        public ElementObject(int context)
        {
            this.context = context;
        }

    }
}