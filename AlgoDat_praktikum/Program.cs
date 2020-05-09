using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDat_praktikum
{
    public interface IDictionary
    {
        bool search(int elem);
        bool insert(int elem);
        bool delete(int elem);
        void print();
    }

    public interface IMultiSet : IDictionary
    {

    }
    public interface IMultiSetSorted : IDictionary

    {

    }
    public interface ISet : IMultiSet
    {

    }
    public interface ISetSorted : IMultiSetSorted
    {

    }

    public class SetSortedArray : ISetSorted
    {
        public bool delete(int elem)
        {
            throw new NotImplementedException();
        }

        public bool insert(int elem)
        {
            throw new NotImplementedException();
        }

        public void print()
        {
            throw new NotImplementedException();
        }

        public bool search(int elem)
        {
            throw new NotImplementedException();
        }
    }

    public class SetUnsortedArray : ISet
    {
        public bool delete(int elem)
        {
            throw new NotImplementedException();
        }

        public bool insert(int elem)
        {
            throw new NotImplementedException();
        }

        public void print()
        {
            throw new NotImplementedException();
        }

        public bool search(int elem)
        {
            throw new NotImplementedException();
        }
    }

    public class MultiSetSortedArray : IMultiSetSorted
    {
        public bool delete(int elem)
        {
            throw new NotImplementedException();
        }

        public bool insert(int elem)
        {
            throw new NotImplementedException();
        }

        public void print()
        {
            throw new NotImplementedException();
        }

        public bool search(int elem)
        {
            throw new NotImplementedException();
        }
    }

    public class MultiSetUnortedArray : IMultiSet
    {
        public bool delete(int elem)
        {
            throw new NotImplementedException();
        }

        public bool insert(int elem)
        {
            throw new NotImplementedException();
        }

        public void print()
        {
            throw new NotImplementedException();
        }

        public bool search(int elem)
        {
            throw new NotImplementedException();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
