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
            IDictionary basis;
            basis = new MultiSetUnsortedArray();
            int userChoice = 0;
            int userInsertedNumber;

            while (userChoice != 4)
            {
                Console.WriteLine("what do you want to do?");
                Console.WriteLine("1. Insert");
                Console.WriteLine("2. Delete");
                Console.WriteLine("3. Print");
                Console.WriteLine("4. Exit");
                userChoice = int.Parse(Console.ReadLine() ?? "4");

                switch (userChoice)
                {
                    case 1:
                        Console.WriteLine("Type the Number to insert into Array :");
                        getUserInputValue();
                        GiveResponseFromAction(basis.Insert(userInsertedNumber));
                        break;
                    case 2:
                        Console.WriteLine("Type the number to be Deleted : ");
                        getUserInputValue();
                        GiveResponseFromAction(basis.Delete(userInsertedNumber));
                        break;
                    case 3:
                        Console.Write("Here is the Array : ");
                        basis.Print();
                        break;
                    default:
                        userChoice = 4;
                        break;
                }
                
                Console.WriteLine();
            }
            
            Console.WriteLine("Programm Finished");

            void GiveResponseFromAction(bool result)
            {
                Console.WriteLine(result ? "Operation Successfull" : "Operation Failed");
            }

            void getUserInputValue()
            {
                userInsertedNumber = int.Parse(Console.ReadLine());
            }
        }
    }
}