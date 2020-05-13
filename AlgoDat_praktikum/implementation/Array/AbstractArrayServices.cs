namespace AlgoDat_praktikum
{
    public abstract class AbstractArrayServices
    {
        public int[] data;
        
        public SearchReturnObject search()
        {
            SearchReturnObject retValue = new SearchReturnObject(1, true);
            return retValue;
        }
    }
}