using System.Collections.Generic;

namespace Exam.MoovIt
{
    public class Route
    {
        public Route(string id, double distance, int popularity, bool isFavorite, List<string> locationPoints)
        {
            this.Id = id;
            this.Distance = distance;
            this.Popularity = popularity;
            this.IsFavorite = isFavorite;
            this.LocationPoints = locationPoints;
        }

        public string Id { get; set; }

        public double Distance { get; set; }

        public int Popularity { get; set; }

        public bool IsFavorite { get; set; }

        public List<string> LocationPoints { get; set; } = new List<string>();

        public override bool Equals(object obj)
        {
            Route other = obj as Route;

            if (other == null)
            {
                return false;
            }

            var thisLocationPoints = this.LocationPoints[0] + " " + this.LocationPoints[this.LocationPoints.Count - 1];
            var otherLocationPoints = other.LocationPoints[0] + " " + other.LocationPoints[other.LocationPoints.Count - 1];

            return thisLocationPoints.Equals(otherLocationPoints);
        }

        public override int GetHashCode()
        {
            return this.GetHashCode();
        }
    }
}
