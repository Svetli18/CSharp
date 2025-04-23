namespace NauticalCatchChallenge.Models
{
    public class PredatoryFish : Fish
    {
        private const int TimeToCatchFish = 60;

        public PredatoryFish(string name, double points) 
            : base(name, points, TimeToCatchFish)
        {
        }
    }
}
