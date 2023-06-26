namespace Features.Gameplay.Scripts.Domain
{
    public class GameConfiguration
    {
        public BoardConfiguration BoardConfiguration;
    }
    
    public enum BoardConfiguration
    {
        Board3X3 = 0,
        Board6X6 = 1,
        Board9X9 = 2
    }
}