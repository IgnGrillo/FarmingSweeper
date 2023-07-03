namespace Features.Gameplay.Scripts.Domain
{
    public class GameConfiguration
    {
        public BoardConfiguration BoardConfiguration;
    }
    
    public enum BoardConfiguration
    {
        Board5X5 = 0,
        Board6X6 = 1,
        Board7X7 = 2,
        Board8X8 = 3,
        Board9X9 = 4
    }
}