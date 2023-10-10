using System;
namespace Wordle
{   /// <summary>
    /// This class keeps track of the internals of the word game.
    /// </summary>
    public class GameState
    {
        public int row;                //current row the game is on
        private List<string> wordBank; //potential words that could be the goal word
        private string word;           //the goal word
        
        /// <summary>
        /// Randomly chooses a goal word out of word bank. Sets row to 0
        /// </summary>
        public GameState()
        {
            row = 0;
            wordBank = new List<string>() {"audio", "below", "blade", "motor", "music", "power",
                "sharp", "slide" };
            Random rnd = new Random();
            word = wordBank[rnd.Next(0, wordBank.Count() - 1)];
        }
        /// <summary>
        /// parses input string into char array without spaces
        /// </summary>
        /// <param name="newText"></param>
        /// <returns></returns>
        public char[] getText(string newText)
        {
            //https://kodify.net/csharp/strings/remove-whitespace/
            newText = String.Concat(newText.Where(c => !Char.IsWhiteSpace(c)));
            char[] word = newText.ToCharArray();
            return word;
            
        }
        /// <summary>
        /// compares the input text with the correct word and returns an array that represents how correct
        /// the word is. Puts a 2 in the array if the letter that would go there is correct, a 1 if the letter is
        /// correct but it is in the wrong spot, and a 0 if the letter is completely wrong.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public int[] getCorrect(string text)
        {
            char[] userWord = text.ToCharArray();
            char[] correctWord = word.ToCharArray();
            int[] correct = new int[word.Length];
            for(int i = 0; i < word.Length; i++)
            {
                if (userWord[i] == correctWord[i])
                {
                    correct[i] = 2;
                }

                else if (word.Contains(userWord[i]))
                {
                    correct[i] = 1;
                }

                else
                {
                    correct[i] = 0;
                }
            }
            return correct;
        }
    }
}

