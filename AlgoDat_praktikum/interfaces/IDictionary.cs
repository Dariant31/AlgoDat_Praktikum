using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDat_praktikum
{
    public interface IDictionary
    {
        bool Search(int element);
        bool Insert(int element);
        bool Delete(int element);
        void Print();
    }
}
