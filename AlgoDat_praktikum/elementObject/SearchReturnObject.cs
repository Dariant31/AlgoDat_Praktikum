namespace AlgoDat_praktikum
{
    public class SearchReturnObject
    {
        public int position;
        public bool isFound;

        public SearchReturnObject(int position, bool isFound)
        {
            this.position = position;
            this.isFound = isFound;
        }
    }
}