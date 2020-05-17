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
            int userActionChoice = 0;
            int userDataTypeChoice = 0;
            string userDataTypeChoiceStr = "";
            int userInsertedNumber;

            basis = SelectDataType();
            SelectActionLoops();

            Console.WriteLine("Programm Finished");

            void GiveResponseFromAction(bool result)
            {
                Console.Clear();
                Console.WriteLine(result ? "Operation Successfull" : "Operation Failed");
            }

            IDictionary SelectDataType()
            {
                userDataTypeChoice = 0;
                
                Console.Clear();
                Console.WriteLine("Select your Data Type : ");
                Console.WriteLine("------------------------");
                Console.WriteLine("1. Array");
                Console.WriteLine("2. Linked List");
                Console.WriteLine("3. Tree");
                Console.WriteLine("------------------------");
                Console.Write("Your input : ");
                userDataTypeChoice = int.Parse(Console.ReadLine() ?? "4");
                Console.Clear();

                switch (userDataTypeChoice)
                {
                    case 1:
                        Console.WriteLine("Select your Array Type : ");
                        Console.WriteLine("------------------------");
                        Console.WriteLine("1. Multiset    - Sorted    Array");
                        Console.WriteLine("2. Multiset    - Unsorted  Array");
                        Console.WriteLine("3. Set         - Sorted    Array");
                        Console.WriteLine("4. Set         - Unorted   Array");
                        Console.WriteLine("------------------------");
                        Console.Write("Your input : ");
                        userDataTypeChoice = int.Parse(userDataTypeChoice + Console.ReadLine());
                        break;
                    // case 2 : for Linked List
                    // case 3 : for tree
                }

                switch (userDataTypeChoice)
                {
                    case 11:
                        userDataTypeChoiceStr = "MultiSet - Sorted - Array";
                        return new MultiSetSortedArray();
                        break;
                    case 12:
                        userDataTypeChoiceStr = "MultiSet - Unsorted - Array";
                        return new MultiSetUnsortedArray();
                        break;
                    case 13:
                        userDataTypeChoiceStr = "Set - Sorted - Array";
                        return new SetSortedArray();
                        break;
                    case 14:
                        userDataTypeChoiceStr = "Set - Unsorted - Array";
                        return new SetUnsortedArray();
                        break;
                    // all other data type in here
                    
                }
                
                return new MultiSetSortedArray();
            }

            void GetUserInputValue()
            {
                userInsertedNumber = int.Parse(Console.ReadLine());
            }

            void SelectActionLoops()
            {
                Console.Clear();
                while (userActionChoice != 4)
                {
                    Console.WriteLine(userDataTypeChoiceStr);
                    Console.WriteLine("-----------------------");
                    Console.WriteLine("Please Select Your Action :");
                    Console.WriteLine("1. Insert");
                    Console.WriteLine("2. Delete");
                    Console.WriteLine("3. Print");
                    Console.WriteLine("4. Exit");
                    Console.WriteLine("-----------------------");
                    Console.Write("Your Input : ");
                    userActionChoice = int.Parse(Console.ReadLine() ?? "4");
                    Console.Clear();

                    switch (userActionChoice)
                    {
                        case 1:
                            Console.WriteLine("Type the Number to insert into Array :");
                            GetUserInputValue();
                            GiveResponseFromAction(basis.Insert(userInsertedNumber));
                            break;
                        case 2:
                            Console.WriteLine("Type the number to be Deleted : ");
                            GetUserInputValue();
                            GiveResponseFromAction(basis.Delete(userInsertedNumber));
                            break;
                        case 3:
                            Console.WriteLine("-----------------------");
                            Console.Write("Here is the Array : ");
                            basis.Print();
                            Console.WriteLine();
                            Console.WriteLine("-----------------------");
                            break;
                        default:
                            userActionChoice = 4;
                            break;
                    }

                    Console.WriteLine();
                    Console.Write("Press Enter to Proceeds");
                    Console.ReadLine();

                    Console.Clear();
                }
            }
        }
    }
}