using System;
using System.Collections.Generic;
using System.Text;

namespace Hangman
{
    public class Hangman
    {
        private WordBank wordbank;
        private PlayerInterface playerInterface;
        private Game game;
        public Hangman()
        {
            playerInterface = new PlayerInterface();
            wordbank = new WordBank();
            var answer = wordbank.GetWord();
            var guesses = 11;
            game = new Game(guesses, answer);
        }

        public void Run()
        {
            StartGame();
            LoopGuessing();
        }
            
        private void StartGame()
        {
            playerInterface.Tell("Welcome to hangman!");
            playerInterface.Tell($"The word is {game.GetAnswerLength()} letters long.");
        }

        private void LoopGuessing()
        {
            var continueGame = true;

            while(continueGame)
            {
                DisplayInformation();
                Guess();
                continueGame = CheckIfContinueGame();
            }
        }

        private void DisplayInformation()
        {
            var playerAnswer = game.GetAnswerStringToDisplayToUsers();
            playerInterface.Tell(playerAnswer);
            playerInterface.Tell($"You have { game.GetLives() } lives left.");
            playerInterface.Tell($"Your guesses are {game.GetGuesses()}");
        }

        private void Guess()
        {
            var guess = playerInterface.AskForChar("Guess a character!");
            var correct = game.IsLetterInAnswer(guess);
            
            if(correct)
            {
                playerInterface.Tell($"Your guess {guess} is correct!");
            }
            else
            {
                playerInterface.Tell($"Your guess {guess} is incorrect.");
                game.LoseLife();
            }
            
            game.AddGuess(guess);
        }

        private bool CheckIfContinueGame()
        {
            bool continueGame;
            
            if (game.CheckIfNoLives())
            {
                Loss();
                continueGame = false;
            }
            else if (game.CheckIfPlayerWon()) 
            {
                Won();
                continueGame = false;
            } 
            else
            {
                continueGame = true;
            }

            return continueGame;
        }

        private void Won()
        {
            playerInterface.Tell("You WON!!!  Run the program again to play again.");
        }
        private void Loss()
        {
            playerInterface.Tell("You have no lives.  Run the program again to play again.");
        }
    }
}
