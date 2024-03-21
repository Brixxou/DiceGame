namespace jeux
{
    public partial class MainPage : ContentPage
    {
        private int player1Score = 0;
        private int player2Score = 0;
        private int lancer1 = 0;
        private int lancer2 = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnLaunchClicked(object sender, EventArgs e) { 
            Random random = new Random();
            async Task LancerDes()
            {

                for (int i = 0; i < 10; i++)
                {
                    lancer1 = random.Next(1, 6);
                    lancer2 = random.Next(1, 6);
                    dice1.Text = lancer1.ToString();
                    dice2.Text = lancer2.ToString();
                    await Task.Delay(100); 
                }
            }
            await LancerDes();

            if (lancer1 > lancer2) {
                player1Score++;
                Player1ScoreLabel.Text = player1Score.ToString();
                Score10();
                Annonce.Text = ("le joueur 1 a gagné");
            }
            else if (lancer1 < lancer2)
            {
                player2Score++;
                Player2ScoreLabel.Text = player2Score.ToString();
                Score10();
                Annonce.Text = ("le joueur 2 a gagné");
            }
            else
            {
                Annonce.Text = ("égalité");
            }
        }
        public void OnResetClicked(object sender, EventArgs e) {
            player1Score = 0;
            player2Score = 0;
            Player1ScoreLabel.Text = player1Score.ToString();
            Player2ScoreLabel.Text = player2Score.ToString();
        }
        private void Score10()
        {
            if (player1Score == 5) {
                player1Score = 0;
                player2Score = 0;
                Player1ScoreLabel.Text = player1Score.ToString();
                Player2ScoreLabel.Text = player2Score.ToString();
                DisplayAlert("Victoire", "le joueur 1 à gagné la partie", "fermer");          
            }
            if (player2Score == 5)
            {
                player1Score = 0;
                player2Score = 0;
                Player1ScoreLabel.Text = player1Score.ToString();
                Player2ScoreLabel.Text = player2Score.ToString();
                DisplayAlert("Victoire", "le joueur 2 à gagné la partie", "fermer");              
            }
        }
    }
}


