using System;

namespace SkalProj_Datastrukturer_Minne
{
    internal class CheckString
    {
        internal static void NullCheck(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("The input value is empty");
            }
        }
    }
}