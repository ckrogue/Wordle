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
				temp.HeightRequest = 100;
				temp.WidthRequest = 100;
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
		
		updateBoard(game.getText(typeBox.Text), game.row);
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


    void typeBox_Completed(System.Object sender, System.EventArgs e)
    {
		updateRowColors(game.row, game.getCorrect(typeBox.Text));
		game.row = game.row + 1;
		typeBox.Text = "";
		typeBox.Focus();
    }
	public void updateRowColors(int row, int[] correct)
	{
		for(int i = 0; i < correct.Count(); i++)
		{
			if (correct[i] == 0)
			{
				words[row][i].BackgroundColor = Colors.Red;
			}
            else if (correct[i] == 1)
            {
                words[row][i].BackgroundColor = Colors.Yellow;
            }
            else
            {
                words[row][i].BackgroundColor = Colors.Green;
            }


        }

    }

}


