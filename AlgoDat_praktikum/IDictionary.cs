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
}
