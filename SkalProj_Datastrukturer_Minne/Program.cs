using System;
using System.Collections.Generic;
using System.Linq;

namespace Uppgift4_Josefin
{
    //Svar på frågor längst ner
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

        private static void ListStatus(List<string> collection)
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
                            ListStatus(theList);
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
                            ListStatus(theList);
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

            TestQueue(theQueue);

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

        private static void TestQueue(Queue<string> theQueue)
        {
            theQueue.Enqueue("Kalle");
            theQueue.Enqueue("Greta");
            theQueue.Dequeue();
            theQueue.Enqueue("Stina");
            theQueue.Dequeue();
            theQueue.Enqueue("Olle");
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
            
            string message = " ";
            var stackCheck = new Stack<char>();
            Dictionary<char, char> parantheses = new Dictionary<char, char> {
                {'(',')'},
                {'[',']'},
                {'{','}'}
            };
            do
            {
                string input = GetInput("Enter string with parentheses: ");
                switch (input)
                {
                    case "0":
                        running = false;
                        break;
                    default:
                        foreach (char c in input) //move up over switch
                        {
                            if (c == '(' || c == '[' || c == '{')
                            {
                                stackCheck.Push(c);                         //first bracket pushed
                            }
                            else if (c == ')' || c == ']' || c == '}')
                            {
                                if (stackCheck.Count > 0)                    //there is something in stack
                                {
                                    char key = stackCheck.Pop();          //get key from stack - trygetvalue by (stack-)key - if value =c - balanced
                                    if (c == parantheses[key])
                                    {
                                        message = "Balanced!";
                                    }
                                    else message = "Unbalanced.";
                                }
                                else message = "Unbalanced.";               //there is no pair in stack 
                            }
                            
                            }
                        message = stackCheck.Count > 0 ? "Unbalanced" : "Balanced!"; //if one bracket is left OR no parantheses at all
                        Console.WriteLine(message);
                        break;
                }
            } while (running);
            running = true;
        }   //ToDo: unittest
    }
}

/*Fråga 1: Stack och heap är två olika typer av minneshantering. 
 * Stack funkar som en stapel där sista värdet in, tas ut först, 
 * för att man sedan ska kunna komma åt nästa i stapeln. Det objekt  
 * eller den metod som tas fram är sedan förbrukat och tas bort ur minnet.
 * Minnet rensas självt.
 * Stack används för value types (int, bool..) 
 * 
 * Heap används vid reference types, då det går att ta fram ett objekt 
 * i vilken ordning som helst. Alla finns tillgänliga samtidigt genom en referens.
 * Heapen måste dock ha informationen aktuell hela tiden och kan inte
 * rensa minnet själv. Det kan göra att förbrukade/onödiga värden tar upp 
 * mycket plats i minnet och bidrar till sk. garbage collection.
 * 
 * Fråga 2: En value type håller värdet i sin egen variabel, och tar bara upp sin egen minnesplats.
 * Skickas en value type kommer den kopieras till den nya platsen, och nya ändringar 
 * påverkar inte den första variabeln.
 * Reference type refererar till ett värde någon annanstans i minnet. Flera variablar kan 
 * hänvisa till samma värde. Skickas en reference type skickas samma adress till värdet i minnet,
 * så ändringar gäller då alla referenser/variablar som pekar på ett värde.
 * 
 * Fråga 3: Första metoden skriver inte över x, utan värdet förblir detsamma y!=x
 * Andra metoden har två referenser som har samma adress till värdet. Ändras y så ändras också x. y=x
 * - - -
 * Fråga 1.2 efter add-metod
 * .3 ökar fr 4->8 
 * .4 Kapaciteten visar möjligt antal värden innan list-arrayen måste ändra storlek
 * .5 nej
 * .6 när antalet värden är känt från början bör man använda en array eller när man behöver 
 * en multidimensionell kollektion.
 * 
 * Fråga 2.
 */

