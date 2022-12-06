namespace TrueOrFalse
{
    public class Game
    {
        public event Action AskQuestion;
        public event Action RightAnswerReaction;
        public event Action WrongAnswerReaction;

        public event Action LoseGame;
        public event Action WinGame;

        public GameRules Rules { get; private set; }
        public string YourAnswer { get; set; }
        private int Attempts { get; set; }


        public Game(int attempts = 2)
        {
            Attempts = attempts;
        }


        public void StartGame() 
        {
            List<GameRules> lines = File.ReadAllLines("Questions.csv")
                    .Select(x => GameRules.ParseCsvForm(x))
                    .ToList();
            for (int x = 0; x < lines.Count; x++)
            {
                Rules = lines[x];
                AskQuestion();
                if (YourAnswer == Rules.Answer)
                {
                    RightAnswerReaction();
                }
                else if (YourAnswer != Rules.Answer)
                {
                    Attempts--;
                    if (Attempts > 0)
                    {
                        WrongAnswerReaction();
                    }
                    else if (Attempts < 0)
                    {
                        LoseGame();
                        break;
                    }
                }
            }
            if (Attempts >= 0)
            {
                WinGame();
            }
        }
    }
}