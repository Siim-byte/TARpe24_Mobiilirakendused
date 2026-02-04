namespace TARpe24_Mobiilirakendused
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object? sender, EventArgs e)
        {
            count++;
            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                  if (count == 10)
            {
                BotImage.IsVisible = false;
                CounterLabel.Text = "Pilt kadus ära, mine tagasi";
            }
            CounterBtn.Text = $"Clicked {count} times";

            BotImage.Rotation += 20; //pöörab pilti iga vajutusega 20 kraadi

            var rnd = new Random();
            var rndColor = Color.FromRgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            BackgroundColor = rndColor; //muutab taustavärvi juhuslikuks värviks

            if (count == 5)
            {
                CounterBtn.BackgroundColor = Colors.Red;
                CounterBtn.TextColor = Colors.White;
            }
            if (BotImage.HorizontalOptions == LayoutOptions.Start)
            {
                BotImage.HorizontalOptions = LayoutOptions.End;
            }
            else
            {
                BotImage.HorizontalOptions = LayoutOptions.Start;
            }
            BotImage.Opacity -= 0.1; //teeb pildi läbipaistvamaks iga vajutusega
            BotImage.Scale += 0.1; // teeb pildi suuremaks iga vajutusega
            CounterBtn.CornerRadius = 10;//teeb nuppude ääred ühtlaseks

            SemanticScreenReader.Announce(CounterBtn.Text);
        }

        private void ResetBtn_Clicked(object sender, EventArgs e)
        {
            count = 0;
            CounterBtn.Text = "Alustame uuesti!";
            BotImage.Rotation = 0; //lähtestab pildi pöörde nulli     
            BotImage.IsVisible = true; //teeb pildi uuesti nähtavaks
            CounterLabel.Text = "Pilt on tagasi!";

            BackgroundColor = Colors.White; //muudame värv valgeks
            ResetBtn.ClearValue(BackgroundColorProperty); //eemaldame nupu taustavärvi
            CounterBtn.BackgroundColor = Colors.Blue;
            BotImage.Opacity = 1;
            BotImage.Scale = 0.5;
        }
    }
}
