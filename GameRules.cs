namespace TrueOrFalse
{
    public class GameRules 
    {
        public string Question { get; set; }
        public string Answer { get; set; }
        public string Info { get; set; }

        public static GameRules ParseCsvForm(string line)
        {
            string[] formParts = line.Split(';');
            return new GameRules
            {
                Question = formParts[0],
                Answer = formParts[1],
                Info = formParts[2],
            };
        }
    }
}