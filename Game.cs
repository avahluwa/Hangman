using System;
using System.Collections.Generic;
using System.Text;

namespace Hangman
{
    /// <summary>
    /// Run hangman game 
    /// </summary>
    public class Game
    {
        private string answer;

        private List<char> guesses = new List<char>();
        
        private int lives;

        public Game (int lives, string answer)
        {
            this.answer = answer;
            this.lives = lives;
        }

        public int GetLives()
        {
            // Returns amount of lives
            return lives;
        }

        public void LoseLife()
        {
            // Reduces life total by one
            lives--;
        }

        public bool CheckIfNoLives()
        {
            // Returns true if lives is less than one.
            return lives < 1;
        }

        public int GetAnswerLength()
        {
            // Returns the length of the answer
            return answer.Length;

        }

        public void AddGuess(char guess)
        {
            // Adds the guess to list of guesses
            guesses.Add(guess);
        }

        public string GetGuesses()
        {
            // Returns all the guesses as a string
            // HINT: See GetAnswerStringToDisplayToUsers() 
            // Each character in the list is put into a string.
            return guesses.ToString();
        }

        public string GetAnswerStringToDisplayToUsers()
        {
            // Building strings with StringBuilder
            // https://www.linkedin.com/learning/c-sharp-essential-training-1-syntax-and-object-oriented-programming/building-strings-with-stringbuilder
            // https://docs.microsoft.com/en-us/dotnet/api/system.text.stringbuilder?view=net-5.0
            var builder = new StringBuilder();

            // Foreach
            // https://www.linkedin.com/learning/c-sharp-essential-training-2-flow-control-arrays-and-exception-handling/managing-ordered-data-with-lists
            // https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/statements/iteration-statements#the-foreach-statement
            foreach (var let in answer)
            {
                if (Contains(let))
                {
                    builder.Append($"{ let } ");
                }
                else
                {
                    builder.Append("_ ");
                }
            }

            return builder.ToString().Trim();
        }

        public bool IsLetterInAnswer(char letter)
        {
            // Returns true if the letter is in the answer
            // Hint: Loops through the answer string checking if the letter is in answer.  If there is a match it returns true.  If no match it returns false.
            return answer.Contains(letter);
        }

        public bool HasLetterBeenGuessed(char letter)
        {
            // Returns true if the letter is in guess collection
            // Hint: collections contain a contain method.
            return Contains(letter);
        }

        public bool CheckIfPlayerWon()
        {
            // Extra check.
            if (CheckIfNoLives()) return false;

            // How contains method works. 
            // https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.contains?view=net-5.0
            // This checks if every letter in the answer is in the guesses 
            foreach (var let in answer)
            {
                if (!guesses.Contains(let)) return false;
            }

            return true;

        }

        private bool Contains(char letter)
        {
            foreach (var let in guesses) 
            {
                if (let == letter) return true;          
            }
            return false;
        }

    }
}
