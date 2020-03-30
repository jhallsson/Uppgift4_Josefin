using System;
using System.Collections.Generic;
using System.Text;

namespace Uppgift4_Josefin
{
    class ParanthesesExperimenting
    {
        static void CheckParanthesis2()
        {
            bool running = true;
            string message = " ";
            var stackCheck = new Stack<char>();
            Dictionary<char, char> parantheses = new Dictionary<char, char> {
                {'(',')'},
                {'[',']'},
                {'{','}'}
            };
            do
            {
                Console.Write("Enter string with parentheses: ");
                string input = Console.ReadLine(); 
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
                            else message = "Balanced!";                       //no parantheses at all
                        }
                        Console.WriteLine(message);
                        break;
                }
            } while (running);
            running = true;
        }   //ToDo: unittest - ???
    }
}
