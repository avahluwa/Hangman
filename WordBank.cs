using System;
using System.Collections.Generic;
using System.Text;

namespace Hangman
{
    public class WordBank
    {
        private List<string> words;

        public WordBank()
        {
            words = new List<string>()
            {
                "coding",
                "racecar",
                "guess",
                "hangman",
            };
        }

        public string GetWord()
        {
            var random = new Random();
            var index = random.Next(words.Count);

            return words[index];
        }
    }
}
