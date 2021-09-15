using System;
using System.Collections.Generic;
using System.Text;

namespace Hangman
{
    public class PlayerInterface
    {
        public void Tell(string tell)
        {
            Console.WriteLine(tell);
        }

        public string Ask(string ask)
        {
            Console.WriteLine(ask);
            return Console.ReadLine();
        }

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
            Console.WriteLine(ask);
            string result = Console.ReadLine();
            return Char.Parse(result);


        }
    }
}
