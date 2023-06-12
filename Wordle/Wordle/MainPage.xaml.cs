namespace Wordle;

public partial class MainPage : ContentPage
{
	List<HorizontalStackLayout> words;
	GameState game;
	public MainPage()
	{
		InitializeComponent();
		initializeGame();
		game = new GameState();
	}

	private void initializeGame()
	{
        words = new List<HorizontalStackLayout>();
        for (int i = 0; i < 6; i++)
		{
			HorizontalStackLayout word = new HorizontalStackLayout();
			word.Spacing = 10;
			word.HorizontalOptions = LayoutOptions.Center;


            for (int j = 0; j < 5; j++)
			{
				Label temp = new Label();
				temp.HeightRequest = 100;
				temp.WidthRequest = 100;
				temp.BackgroundColor = Colors.MediumPurple;
				word.Add(temp);
			}
			
			Board.Add(word);
			words.Add(word);
		}
	}

    void typeBox_TextChanged(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e)
    {
    }

    void typeBox_Completed(System.Object sender, System.EventArgs e)
    {
    }
	public void slay() { }

}


