using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDat_praktikum
{
    public interface IDictionary
    {
        bool search(int element);
        bool insert(int element);
        bool delete(int element);
        void print();
    }
}
