using System;
namespace Wordle
{
    public class GameState
    {
        public int row;
        
        public GameState()
        {
            row = 1;
        }

        public char[] textBoxChanged(string newText)
        {
            //https://kodify.net/csharp/strings/remove-whitespace/
            newText = String.Concat(newText.Where(c => !Char.IsWhiteSpace(c)));
            char[] word = newText.ToCharArray();
            return word;
            
        }

        
    }
}

