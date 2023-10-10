using System;
namespace Wordle
{
    public class GameState
    {
        public int row;
        private List<string> wordBank;
        private string word;
        
        
        public GameState()
        {
            row = 0;
            wordBank = new List<string>() {"audio", "below", "blade", "motor", "music", "power",
                "sharp", "slide" };
            Random rnd = new Random();
            word = wordBank[rnd.Next(0, wordBank.Count() - 1)];
        }

        public char[] getText(string newText)
        {
            //https://kodify.net/csharp/strings/remove-whitespace/
            newText = String.Concat(newText.Where(c => !Char.IsWhiteSpace(c)));
            char[] word = newText.ToCharArray();
            return word;
            
        }

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

