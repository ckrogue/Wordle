namespace Wordle;

public partial class MainPage : ContentPage
{
	List<List<Label>> words;
	GameState game;
	public MainPage()
	{
		InitializeComponent();
		initializeGame();
		game = new GameState();
	}

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

    void typeBox_Completed(System.Object sender, System.EventArgs e)
    {
		updateRowColors(game.row, game.getCorrect(typeBox.Text));
		game.row = game.row + 1;
		if (game.row == 7)
		{
			gameOver(false);
		}
		else
		{
			typeBox.Text = "";
			typeBox.Focus();
		}
    }
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


