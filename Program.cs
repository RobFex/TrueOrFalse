namespace TrueOrFalse
{
    internal class Program
    {
        static Game game;
        static void Main(string[] args)
        {
            game = new Game();

            game.AskQuestion += HandleOfAsking;
            game.RightAnswerReaction += HandleOfRightAnswer;
            game.WrongAnswerReaction += HandleOfWrongAnswer;
            game.LoseGame += HandleOfLose;
            game.WinGame += HandleOfWin;

            game.StartGame();
        }
        private static void HandleOfAsking()
        {
            Console.WriteLine("Is it true: " + game.Rules.Question);
            Console.WriteLine("Write \"Yes\" or \"No\"");
            do
            {
                game.YourAnswer = Console.ReadLine();
            }
            while (game.YourAnswer != "Yes" && game.YourAnswer != "No");
        }
        private static void HandleOfRightAnswer()
        {
            Console.WriteLine("Yes, you are right:");
            Console.WriteLine(game.Rules.Info);
            Console.WriteLine();
        }
        private static void HandleOfWrongAnswer()
        {
            Console.WriteLine("Oh, you are wrong:");
            Console.WriteLine(game.Rules.Info);
            Console.WriteLine();
        }
        
        private static void HandleOfLose()
        {
            Console.WriteLine("\nYou lose");
        }
        private static void HandleOfWin()
        {
            Console.WriteLine("\nCongratulations, you win!");
        }
    }
}