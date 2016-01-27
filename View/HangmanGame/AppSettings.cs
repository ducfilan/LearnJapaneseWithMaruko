namespace Hoc_tieng_Nhat_cung_Maruko.View.HangmanGame
{
    public static class AppSettings
    {
        public enum GameLevel { Easy, Medium, Hard };

        // Properties to save in isolated storage
        public static PersistSettings<int> gameWon = new PersistSettings<int>("GameWon", 0);
        public static PersistSettings<int> gameLost = new PersistSettings<int>("GameLost", 0);
        public static PersistSettings<int> totalScore = new PersistSettings<int>("Score", 0);
        public static PersistSettings<string> level = new PersistSettings<string>("Level", "Easy");
        public static PersistSettings<bool> showWord = new PersistSettings<bool>("ShowWord", false);
    }
}
