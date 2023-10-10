namespace Wordle;
/// <summary>
/// This class directly controls the view of the word game. This class represents the view of the game
/// and has methods which can update and keep track of the view of the game
/// </summary>
public partial class MainPage : ContentPage
{
	List<List<Label>> words;
	GameState game;
	/// <summary>
	/// This constructor initializes the board for the game and makes a new gamestate object
	/// which is used to keep track of the internals of the game
	/// </summary>
	public MainPage()
	{
		InitializeComponent();
		initializeGame();
		game = new GameState();
	}
	/// <summary>
	/// This method creates the board for the game.
	/// </summary>
	private void initializeGame()
	{
        words = new List<List<Label>>();
        for (int i = 0; i < 6; i++)
		{
			List<Label> labels = new List<Label>();
			HorizontalStackLayout word = new HorizontalStackLayout();
			word.Spacing = 10;
			word.HorizontalOptions = LayoutOptions.Center;
            for (int j = 0; j < 5; j++)
			{
				Label temp = new Label();
				temp.HeightRequest = 60;
				temp.WidthRequest = 60;
				temp.BackgroundColor = Colors.MediumPurple;
				temp.TextColor = Colors.Black;
				temp.HorizontalTextAlignment = TextAlignment.Center;
				temp.VerticalTextAlignment = TextAlignment.Center;
				temp.FontSize = 30;
				word.Add(temp);
				labels.Add(temp);
			}
			Board.Add(word);
			words.Add(labels);
		}
	}
	/// <summary>
	/// This method is called when the text in the typebox is changed.
	/// It updates the board with the new text. If the user has already filled up all the rows
	/// it makes the game quit
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
    void typeBox_TextChanged(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e)
    {
		if(game.row > 5)
		{
			gameOver(false);
		}
		else
		{
            updateBoard(game.getText(typeBox.Text), game.row);
        }
    }
	/// <summary>
	/// This method updates the board to have the current word being typed on it
	/// </summary>
	/// <param name="text">text to be put on board</param>
	/// <param name="row">row of the board</param>
	private void updateBoard(char[] text, int row)
	{
		int i = 0;
		int length = text.Count();
		foreach(Label letter in words[row])
		{
			if(i < length)
			{
                letter.Text = text[i].ToString();
            }
			else
			{
				letter.Text = "";
			}
			i++;
		}

	}
	/// <summary>
	/// This method gives the user a pop up when the game is over asking if they want to play again.
	/// If they select yes it restarts the game, if they select no nothing is done.
	/// </summary>
	/// <param name="winOrLose">send in true if the user won, false otherwise</param>
	private async void gameOver(bool winOrLose)
	{
		bool answer;
		if(winOrLose)
		{
            answer = await DisplayAlert("You Won!", "Play Again?", "Yes", "No");
        }
		else
		{
            answer = await DisplayAlert("You Lost", "The answer was  do you want to play again?", "Yes", "No");
        }
		if(answer)
		{
			game = new GameState();
			resetBoard();
		}
	}
	/// <summary>
	/// This method resets the board to its original state, without any words on it.
	/// </summary>
	private void resetBoard()
	{
		for(int row = 0; row < 6; row++)
		{
			for(int node = 0; node < 5; node++)
			{
				words[row][node].BackgroundColor = Colors.MediumPurple;
				words[row][node].Text = "";
            }
		}
	}
	/// <summary>
	/// Upon enter being pressed in the typebox, this method updates the colors on the board to reflect
	/// how correct each of the letters are
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
    void typeBox_Completed(System.Object sender, System.EventArgs e)
    {
		updateRowColors(game.row, game.getCorrect(typeBox.Text));
		game.row = game.row + 1;
		if (game.row == 6)
		{
			gameOver(false);
		}
		else
		{
			typeBox.Text = "";
			typeBox.Focus();
		}
    }
	/// <summary>
	/// This method updates the colors of the row to match how correct the word
	/// put in is. If the word is completely correct this method ends the game
	/// </summary>
	/// <param name="row">number of row currently on</param>
	/// <param name="correct">This array has a 0 if a letter is false, 1 if it is right but in the wrong spot
	/// and 2 if correct</param>
	public void updateRowColors(int row, int[] correct)
	{
		bool win = true;
		for(int i = 0; i < correct.Count(); i++)
		{
			if (correct[i] == 0)
			{
				words[row][i].BackgroundColor = Colors.Red;
				win = false;
			}
            else if (correct[i] == 1)
            {
                words[row][i].BackgroundColor = Colors.Yellow;
				win = false;
            }
            else
            {
                words[row][i].BackgroundColor = Colors.Green;
            }
        }
		if(win)
		{
			gameOver(true);
		}

    }

}


