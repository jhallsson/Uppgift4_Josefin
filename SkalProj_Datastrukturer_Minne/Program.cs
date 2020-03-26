using System;
using System.Collections.Generic;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParanthesis"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()[0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }
        private static string GetInput(string message)
        {
            Console.Write(message);
            string input = Console.ReadLine();
            return input;
        }

        private static void ListStatus(List<string> collection, string value)
        {
            Console.Write($"Count: {collection.Count}\nValues:\n");
            collection.ForEach(m => Console.WriteLine($"{m}")); //check list
        }
        private static bool CheckNull(string inputValue)
        {
            bool isNull=false;
            if (string.IsNullOrEmpty(inputValue)) { 
                Console.WriteLine("Please enter some valid input");
                isNull = true;
            } 

            return isNull;
        }
        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            /*
             * x Loop this method untill the user inputs something to exit to main menue.
             * x Create a switch statement with cases '+' and '-'
             * x '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * x '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * x ToDo: In both cases, look at the count and capacity of the list
             * x As a default case, tell them to use only + or -
             * x Below you can see some inspirational code to begin working.
            */

            List<string> theList = new List<string>{ "one", "two", "three", "four" };

            //ToDo: internal? npt when static?
            char nav;
            string value;
            bool running = true;

            do
            {
                string input = GetInput("Add value with + or remove with - : ");

                //nav = input[0];
                //CheckString.NullCheck(input);
                /*if (CheckNull(input))
                {   //ToDo: make generic/method
                    Console.WriteLine("Please enter some valid input (+ or -)");
                }*/
                if(!CheckNull(input))
                {
                    nav = input[0];
                    value = input.Substring(1);
                    switch (nav)
                    {
                        case '+':
                            /*if (string.IsNullOrEmpty(value))
                            {//ToDo: make generic/method
                                Console.WriteLine("The input value is empty");
                            }*/
                            if (CheckNull(value))
                            {                            //check value?
                                theList.Add(value);         //add value to theList
                                Console.WriteLine($"{value} added to the list\n");
                            }
                            ListStatus(theList, value);
                            break;
                        case '-':
                            if (theList.Contains(value))    //if value exists in the list
                            {
                                theList.Remove(value);      //removes value (first of same values) to theList
                                Console.WriteLine($"{value} removed from the list");
                            }
                            else
                            {
                                Console.WriteLine($"'{value}' does not exist in the list!");
                            }
                            //variable = (condition) ? expressionTrue : expressionFalse;
                            //string message = theList.Contains(value) ? $"{value} removed from the list" : $"'{value}' does not exist in the list!";
                            //Console.WriteLine(message);
                            ListStatus(theList, value);
                            break;
                        case '0':
                            running = false;            //exit to main menu - bool=false
                            break;
                        default:
                            Console.WriteLine("Please enter some valid input (+ or -)");
                            break;
                    }
                }
                //theList.ForEach(m => Console.WriteLine($"{m}, ")); //check list
            } while (running);
            
        }

        

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            /*
             * x Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */
            var theQueue = new Queue<string>();
            theQueue.Enqueue("one");
            theQueue.Enqueue("two");
            theQueue.Enqueue("three");

            //ToDo: make internal?
            char nav;
            string value;
            bool running = true;
            do
            {
                string input = GetInput("Enter + for enqueue and - for dequeue: ");
                if (string.IsNullOrEmpty(input))
                {   //ToDo: make generic
                    Console.WriteLine("Please enter some valid input");
                }
                else
                {
                    nav = input[0];
                    value = input.Substring(1);
                    switch (nav)
                    {
                        case '+':
                            theQueue.Enqueue(value);         
                            Console.WriteLine($"{value} added to the queue\n");
                            break;
                        case '-': //ToDo: if queue empty
                            string removedObj=theQueue.Dequeue();     //removes ""and returns"" obj at beginning
                            Console.WriteLine($"{removedObj} removed from the queue\n");
                            break;
                        case '0':
                            running = false;          
                            break;
                        default://ToDo: generic method
                            Console.WriteLine("Please enter some valid input");
                            break;
                    }
                }
                var queueCopy = new string[theQueue.Count]; //Other way? only peek for first value
                int n= 0;
                theQueue.CopyTo(queueCopy,n);
                foreach (var item in queueCopy)
                {
                    Console.WriteLine(item);
                }
            } while (running);
        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */
            bool running = true;
            do
            {
                string input = GetInput("Add value with + or remove with - : ");
            } while (running);
        }

        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

        }

    }
}

