using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AlgoDat_praktikum
{
    class Program
    {
        static void Main(string[] args)
        {
            // Main to test Array
            IDictionary base_dict;

            base_dict = new BinSearchTree();

            base_dict.Insert(25);
            base_dict.Insert(98);
            base_dict.Insert(10);
            base_dict.Insert(56);
            base_dict.Insert(10);
            base_dict.Insert(11);
            base_dict.Insert(67);
            base_dict.Insert(2);
            base_dict.Insert(12);
            base_dict.Insert(25);
            base_dict.Insert(3);

            base_dict.Delete(25);
            base_dict.Delete(10);

            base_dict.Print();
        }
    }
}