using System;
using System.Collections.Generic;
using System.Text;

namespace Hangman
{
    public class PlayerInterface
    {
        public void Tell(string tell)
        {
            // Writes the tell to the console
            Console.WriteLine(tell);
        }

        public string Ask(string ask)
        {
            // Writes the tell to the console
            // Then it prompts the user for the 
            Console.WriteLine(ask);
            return Console.ReadLine();
        }

        // This method is not used int the programm but it is an example.
        public int AskForInt(string ask)
        {
            Console.WriteLine(ask);
            var response = Console.ReadLine().ToLower();

            int number;
            if (!Int32.TryParse(response, out number))
            {
                Console.WriteLine("Invalid Entry");
                AskForChar(ask);
            }

            return number;
        }

        public char AskForChar(string ask)
        {
            // Writes the tell to the console
            // Then it prompts the user for a entry
            // Then it converts the string into a character
            // You can see in the above example that invalid entry repeats the method.  You may try this with Char.TryParse();
            // https://docs.microsoft.com/en-us/dotnet/api/system.char.tryparse?view=net-5.0
            Console.WriteLine(ask);
            string result = Console.ReadLine();
            return Char.Parse(result);


        }
    }
}
