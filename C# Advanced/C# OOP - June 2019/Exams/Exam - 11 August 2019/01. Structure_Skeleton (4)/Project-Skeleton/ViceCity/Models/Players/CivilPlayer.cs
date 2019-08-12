namespace ViceCity.Models.Players
{
    public class CivilPlayer : Player
    {
        private const int INITIAL_LIFEPOINTS = 100;

        public CivilPlayer(string name) 
            : base(name, INITIAL_LIFEPOINTS)
        {
        }
    }
}