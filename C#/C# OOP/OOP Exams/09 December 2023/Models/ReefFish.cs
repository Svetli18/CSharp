namespace NauticalCatchChallenge.Models
{
    public class ReefFish : Fish
    {
        private const int TimeToCatchFish = 30;

        public ReefFish(string name, double points) 
            : base(name, points, TimeToCatchFish)
        {
        }
    }
}
