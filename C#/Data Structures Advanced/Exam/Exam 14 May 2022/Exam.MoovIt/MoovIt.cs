namespace Exam.MoovIt
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class MoovIt : IMoovIt
    {
        Dictionary<string, Route> byId = new Dictionary<string, Route>();

        public int Count => this.byId.Count;

        public void AddRoute(Route route)
        {
            if (this.byId.ContainsKey(route.Id)) //&& x.LocationPoints.Count == route.LocationPoints.Count)) //|| 
                //this.byId.Values.Any(x => x.LocationPoints[0] == route.LocationPoints[0] && 
                //x.LocationPoints[x.LocationPoints.Count - 1] == route.LocationPoints[route.LocationPoints.Count - 1] && 
                //x.LocationPoints.Count == route.LocationPoints.Count))
            {
                throw new ArgumentException();
            }

            this.byId[route.Id] = route;
        }

        public void RemoveRoute(string routeId)
        {
            Route route = this.GetRoute(routeId);

            string distance = route.LocationPoints[0] + " " + route.LocationPoints[route.LocationPoints.Count - 1];

            this.byId.Remove(routeId);
        }

        public bool Contains(Route route)
        {
            return this.byId.Values.Contains(route);
        }

        public Route GetRoute(string routeId)
        {
            if (!this.byId.ContainsKey(routeId))
            {
                throw new ArgumentException();
            }

            return this.byId[routeId];
        }

        public void ChooseRoute(string routeId)
        {
            Route route = this.GetRoute(routeId);

            route.Popularity += 1;
        }

        public IEnumerable<Route> SearchRoutes(string startPoint, string endPoint)
        {
            return this.byId.Values
                .Where(x => x.LocationPoints.Contains(startPoint) && x.LocationPoints.Contains(endPoint) && x.LocationPoints.IndexOf(startPoint) < x.LocationPoints.IndexOf(endPoint))
                .OrderBy(x => x.IsFavorite)
                .ThenBy(x => x.LocationPoints.IndexOf(endPoint) - x.LocationPoints.IndexOf(startPoint) - 1)
                .ThenByDescending(x => x.Popularity);
            //List<Route> result = new List<Route>();

            //foreach (var route in this.byId.Values)
            //{
            //    if (!route.LocationPoints.Contains(startPoint) || !route.LocationPoints.Contains(endPoint))
            //    {
            //        continue;
            //    }

            //    int indexOfStartPoint = route.LocationPoints.IndexOf(startPoint);
            //    int indexOfEndPoint = route.LocationPoints.IndexOf(endPoint);

            //    if (indexOfStartPoint < indexOfEndPoint)
            //    {
            //        result.Add(route);
            //    }
            //}

            //return result
            //    .OrderBy(x => x.IsFavorite)
            //    .ThenBy(x => x.LocationPoints.IndexOf(endPoint) - x.LocationPoints.IndexOf(startPoint) - 1)
            //    .ThenByDescending(x => x.Popularity);
        }

        public IEnumerable<Route> GetFavoriteRoutes(string destinationPoint)
        {
            return this.byId.Values
                .Where(x => x.IsFavorite && x.LocationPoints[x.LocationPoints.Count - 1].Equals(destinationPoint))
                .OrderBy(x => x.Distance)
                .ThenByDescending(x => x.Popularity);

        }

        public IEnumerable<Route> GetTop5RoutesByPopularityThenByDistanceThenByCountOfLocationPoints()
        {
            return this.byId.Values
                .OrderByDescending(x => x.Popularity)
                .ThenBy(x => x.Distance)
                .ThenBy(x => x.LocationPoints.Count)
                .Take(5);
        }
    }
}
