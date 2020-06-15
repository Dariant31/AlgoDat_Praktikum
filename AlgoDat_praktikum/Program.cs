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
            string userTypeChoiceStr = "";
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
                    case 2:
                        Console.WriteLine("Select your Linked-List Type : ");
                        Console.WriteLine("------------------------");
                        Console.WriteLine("1. Multiset    - Sorted    Linked-List");
                        Console.WriteLine("2. Multiset    - Unsorted  Linked-List");
                        Console.WriteLine("3. Set         - Sorted    Linked-List");
                        Console.WriteLine("4. Set         - Unorted   Linked-List");
                        Console.WriteLine("------------------------");
                        Console.Write("Your input : ");
                        userDataTypeChoice = int.Parse(userDataTypeChoice + Console.ReadLine());
                        break;
                        // case 3 : for tree
                }

                switch (userDataTypeChoice)
                {
                    case 11:
                        userDataTypeChoiceStr = "Array";
                        userTypeChoiceStr = "MultiSet - Sorted";
                        return new MultiSetSortedArray();
                        break;
                    case 12:
                        userDataTypeChoiceStr = "Array";
                        userTypeChoiceStr = "MultiSet - Unsorted";
                        return new MultiSetUnsortedArray();
                        break;
                    case 13:
                        userDataTypeChoiceStr = "Array";
                        userTypeChoiceStr = "Set - Sorted";
                        return new SetSortedArray();
                        break;
                    case 14:
                        userDataTypeChoiceStr = "Array";
                        userTypeChoiceStr = "Set - Unsorted";
                        return new SetUnsortedArray();
                        break;
                    case 21:
                        userDataTypeChoiceStr = "Linked-List";
                        userTypeChoiceStr = "MultiSet - Sorted";
                        return new MultiSetSortedLinkedList();
                    case 22:
                        userDataTypeChoiceStr = "Linked-List";
                        userTypeChoiceStr = "MultiSet - Unsorted";
                        return new MultiSetUnsortedLinkedList();
                    case 23:
                        userDataTypeChoiceStr = "Linked-List";
                        userTypeChoiceStr = "Set - Sorted";
                        return new SetSortedLinkedList();
                    case 24:
                        userDataTypeChoiceStr = "Linked-List";
                        userTypeChoiceStr = "Set - Unsorted";
                        return new SetUnsortedLinkedList();

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
                    Console.WriteLine(userTypeChoiceStr + " " + userDataTypeChoiceStr);
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
                            Console.WriteLine("Type the Number to insert into your " + userDataTypeChoiceStr + " :");
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
                            Console.Write("Here is the " + userDataTypeChoiceStr + " :");
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