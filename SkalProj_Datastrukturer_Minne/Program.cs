﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        static bool running = true;
        static char nav;
        static string value;


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

        private static void ListStatus(List<string> collection/*, string value*/)
        {
            Console.Write($"Count: {collection.Count}\nValues:\n");
            collection.ForEach(m => Console.WriteLine($"{m}")); //check list
        }
        private static bool CheckNull(string inputValue)
        {
            bool isNull = false;
            if (string.IsNullOrEmpty(inputValue))
            {
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
            List<string> theList = new List<string>{ "one", "two", "three", "four" };

            do
            {
                string input = GetInput("Add value with + or remove with - : ");

                if(!CheckNull(input))
                {
                    nav = input[0];
                    value = input.Substring(1);
                    switch (nav)
                    {
                        case '+':
                            if (!CheckNull(value))
                            {                            
                                theList.Add(value);         
                                Console.WriteLine($"{value} added to the list\n");
                            }
                            ListStatus(theList/*, value*/); //ToDo: remove unused value
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
                            ListStatus(theList/*, value*/);
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
            running = true;
        }
        
        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
           // ICollection<string> nnnn = new Queue<string>().ToArray();
            var theQueue = new Queue<string>();
            theQueue.Enqueue("one");        //ToDo: Other way?
            theQueue.Enqueue("two");
            theQueue.Enqueue("three");

            do
            {
                string input = GetInput("Enter + for enqueue and - for dequeue: ");
                if (!CheckNull(input))
                {
                    nav = input[0];
                    value = input.Substring(1);
                    switch (nav)
                    {
                        case '+':
                            if (!CheckNull(value))
                            {
                                theQueue.Enqueue(value);
                                Console.WriteLine($"{value} added to the queue\n");
                                
                                string[] queueCopy = theQueue.ToArray();
                                foreach (var item in queueCopy)
                                {
                                    Console.WriteLine(item);
                                }
                            }
                            break;
                        case '-': 
                            if (theQueue.Count > 0)
                            {
                                string removedObj = theQueue.Dequeue();     //removes ""and returns"" obj at beginning
                                Console.WriteLine($"{removedObj} removed from the queue\n");
                                
                                string[] queueCopy = theQueue.ToArray();
                                foreach (var item in queueCopy)
                                {
                                    Console.WriteLine(item);
                                }
                            }
                            else
                            {
                                Console.WriteLine("There is no element in the queue");
                            }
                            break;
                        case '0':
                            running = false;
                            break;
                        default://ToDo: generic method
                            Console.WriteLine("Please enter some valid input");
                            break;
                    }
                }
            } while (running);
            running = true;         //reset "global value" until next use
        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            Stack<string> theStack = new Stack<string>();
            theStack.Push("example");
            theStack.Push("example");
            theStack.Push("example");
            theStack.Push("example");

            

            do
            {
                string input = GetInput("push value with + or pop with - : ");

                if (!CheckNull(input))
                {
                    nav = input[0];
                    value = input.Substring(1);
                    switch (nav)
                    {
                        case '+':
                            if (!CheckNull(value))
                            {
                                theStack.Push(value);
                                Console.WriteLine($"{value} pushed to the stack");
                            }
                            string[] stackCopy = theStack.ToArray();
                            foreach (var item in stackCopy)
                            {
                                Console.WriteLine(item);
                            }
                            break;
                        case '-':                            
                            if (theStack.Count > 0)
                            {
                                string removedObj = theStack.Pop();     //removes ""and returns"" obj at beginning
                                Console.WriteLine($"{removedObj} removed from the stack\n");

                                stackCopy = theStack.ToArray(); //error: deklarerar två arrays med samma namn                                foreach (var item in stackCopy)
                                foreach(var item in stackCopy)
                                {                                       //säger till här men inte i queue? 
                                    Console.WriteLine(item);
                                }
                            }
                            else
                            {
                                Console.WriteLine("There is no element in the stack");
                            }
                            break;
                        case '0': running = false;
                            break;
                        default://ToDo: generic method
                            Console.WriteLine("Please enter some valid input");
                            break;
                    }
                }
            } while (running);
            running = true;
        }

        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */
            
            //FILO stack takes out first value
            //FIFO queue takes out last value

            var stackCheck = new Stack<char>(); //looks for left
            var queueCheck = new Queue<char>(); //looks for right
            
            var leftList = new List<char>();    //SAVES PARANTHESeS
            var rightList = new List<char>();

            string input = GetInput("Enter string with parantheses: ");
            if (!CheckNull(input))
            {
                
                foreach( char character in input)
                {
                    stackCheck.Push(character);
                    queueCheck.Enqueue(character);
                }

                for (int i = 0; i < input.Length; i++)
                {
                    char left, right;
                    left = stackCheck.Pop();

                    switch (left)
                    {
                        case '(':
                            right = queueCheck.Dequeue();
                            if (right== ')')
                            {
                                Console.WriteLine("It's a match!");
                            }
                            break;
                        case '[':
                            right = queueCheck.Dequeue();
                            if (right == ']')
                            {
                                Console.WriteLine("It's a match!");
                            }
                            break;
                        case '{':
                            right = queueCheck.Dequeue();
                            if (right == '}')
                            {
                                Console.WriteLine("It's a match!");
                            }
                            break;
                        default:
                            Console.WriteLine("No match:(");
                            break;
                    }
                    /*if (left == '(' || left == '{' || left == '[')
                    {
                        leftList.Add(left);

                    }
                    right = queueCheck.Dequeue();
                    if (right == ')' || right == '}' || right == ']')
                    {
                        rightList.Add(right);
                    }*/
                }
                //Console.WriteLine($"{leftList.Count} {leftList.Count}");






                /*foreach (var item in stackCheck)
                {
                    if (item == '(' || item == '{' || item == '[')
                    {
                        leftList.Add(item);
                        //Console.WriteLine(leftList[item]);
                    }
                    *//*else continue;*//*

                }
                Console.WriteLine(leftList.Count);

                foreach (var item in queueCheck)
                {
                    if (item == ')' || item == '}' || item == ']')
                    {
                        rightList.Add(item);
                    }
                    //Console.WriteLine(rightList[item]);
                }*/
                
                //for each char in input add to queue and stack
            }

            /*char lastChar = input.Last();
            Console.WriteLine(lastChar);*/

            //look for first paranthes
            //input.Contains('('); or ('{') or ([)
            //loop through all? find ALL starting parantheses - stack?
            //find second
            //find corresponding  if match remove and next


        }
    }
}

