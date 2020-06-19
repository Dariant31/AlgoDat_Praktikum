namespace AlgoDat_praktikum
{
    public class BinSearchTree : ServiceBinTree, ISetSorted
    {
        TreeElement data;

        public void Print()
        {
            base.Print(data);
        }

        public bool Search(int element) // (1)
        {
            return base.Search(data, element);
        }

        public bool Insert(int element)
        {
            InfoReturn res = base.Insert(data, new TreeElement(element));
            if (res.success)
                data = res.newRoot;
            return res.success;
        }

        public bool Delete(int element)
        {
            InfoReturn res = base.Delete(data, element);
            if (res.success)
                data = res.newRoot;
            return res.success;
        }
    }
}