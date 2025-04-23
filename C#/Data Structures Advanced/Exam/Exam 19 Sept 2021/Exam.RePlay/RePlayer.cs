namespace Exam.RePlay
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class RePlayer : IRePlayer
    {
        HashSet<string> tracks = new HashSet<string>();
        LinkedList<Track> queue = new LinkedList<Track>();
        OrderedDictionary<double, List<Track>> byDuration = new OrderedDictionary<double, List<Track>>();
        SortedDictionary<string, Dictionary<string, Track>> byAlbumAndTrack = new SortedDictionary<string, Dictionary<string, Track>>();
        Dictionary<string, Dictionary<string, HashSet<Track>>> byAlbumAndArtistAndTrackList = new Dictionary<string, Dictionary<string, HashSet<Track>>>();

        public int Count => this.tracks.Count;

        public void AddToQueue(string trackName, string albumName)
        {
            if (!this.byAlbumAndTrack.ContainsKey(albumName) || !this.byAlbumAndTrack[albumName].ContainsKey(trackName))
            {
                throw new ArgumentException();
            }

            Track track = this.byAlbumAndTrack[albumName][trackName];

            if (track == null || this.queue.Contains(track))
            {
                throw new ArgumentException();
            }

            this.queue.AddLast(track);
        }

        public void AddTrack(Track track, string album)
        {
            if (!this.byAlbumAndTrack.ContainsKey(album))
            {
                this.byAlbumAndTrack[album] = new Dictionary<string, Track>();
                this.byAlbumAndArtistAndTrackList[album] = new Dictionary<string, HashSet<Track>>();
            }

            if (!this.byAlbumAndArtistAndTrackList[album].ContainsKey(track.Artist))
            {
                this.byAlbumAndArtistAndTrackList[album][track.Artist] = new HashSet<Track>();
            }

            if (!this.byDuration.ContainsKey(track.DurationInSeconds))
            {
                this.byDuration[track.DurationInSeconds] = new List<Track>();
            }

            this.tracks.Add(track.Id);
            this.byDuration[track.DurationInSeconds].Add(track);

            if (!this.byAlbumAndTrack[album].ContainsKey(track.Title))
            {
                this.byAlbumAndTrack[album][track.Title] = track;
                
            }


            if (!this.byAlbumAndArtistAndTrackList[album][track.Artist].Any(t => t.Title == track.Title))
            {
                this.byAlbumAndArtistAndTrackList[album][track.Artist].Add(track);
            }
        }

        public bool Contains(Track track)
        {
            return this.tracks.Contains(track.Id);
        }

        public IEnumerable<Track> GetAlbum(string albumName)
        {
            if (!this.byAlbumAndTrack.ContainsKey(albumName))
            {
                throw new ArgumentException();
            }

            return this.byAlbumAndTrack[albumName].Values.OrderByDescending(t => t.Plays);
        }

        public Dictionary<string, List<Track>> GetDiscography(string artistName)
        {
            Dictionary<string, List<Track>> result = new Dictionary<string, List<Track>>();

            string[] albumsByNames = this.byAlbumAndTrack.Keys.ToArray();

            foreach (var albumByName in albumsByNames)
            {
                var collectionOfTracks = this.byAlbumAndTrack[albumByName].Values;

                foreach (var track in collectionOfTracks)
                {
                    if (track.Artist.Equals(artistName))
                    {
                        if (!result.ContainsKey(albumByName))
                        {
                            result[albumByName] = new List<Track>();
                        }

                        result[albumByName].Add(track);
                    }
                }
            }

            return result.Count > 0 ? result : throw new ArgumentException();
        }

        public Track GetTrack(string title, string albumName)
        {
            if (!this.byAlbumAndTrack.ContainsKey(albumName) || !this.byAlbumAndTrack[albumName].ContainsKey(title))
            {
                throw new ArgumentException();
            }

            return this.byAlbumAndTrack[albumName][title] != null ? this.byAlbumAndTrack[albumName][title] : throw new ArgumentException();
        }

        public IEnumerable<Track> GetTracksInDurationRangeOrderedByDurationThenByPlaysDescending(int lowerBound, int upperBound)
        {
            IEnumerable<Track> result = this.byDuration
                .Range(lowerBound, true, upperBound, true)
                .SelectMany(t => t.Value)
                .OrderBy(t => t.DurationInSeconds)
                .ThenByDescending(t => t.Plays);

            return result.Any() ? result : new List<Track>();
        }

        public IEnumerable<Track> GetTracksOrderedByAlbumNameThenByPlaysDescendingThenByDurationDescending()
        {
            var result = this.byAlbumAndTrack
                .SelectMany(t => t.Value)
                .Select(t => t.Value)
                .OrderByDescending(t => t.Plays)
                .ThenByDescending(t => t.DurationInSeconds);

            if (!result.Any())
            {
                return new List<Track>();
            }

            return result;
        }

        public Track Play()
        {
            if (this.queue.Count == 0)
            {
                throw new ArgumentException();
            }

            var track = this.queue.First();
            this.queue.RemoveFirst();
            track.Plays = track.Plays + 1;

            return track;
        }

        public void RemoveTrack(string trackTitle, string albumName)
        {
            if (!this.byAlbumAndTrack.ContainsKey(albumName) || !this.byAlbumAndTrack[albumName].ContainsKey(trackTitle))
            {
                throw new ArgumentException();
            }

            Track track = this.byAlbumAndTrack[albumName][trackTitle];

            if (this.queue.Contains(track))
            {
                this.queue.Remove(track);
            }

            this.tracks.Remove(track.Id);
            this.byDuration[track.DurationInSeconds].Remove(track);
            this.byAlbumAndTrack[albumName].Remove(track.Title);
            this.byAlbumAndArtistAndTrackList[albumName][track.Artist].Remove(track);

            if (this.byDuration[track.DurationInSeconds].Count == 0)
            {
                this.byDuration.Remove(track.DurationInSeconds);
            }

            if (this.byAlbumAndTrack[albumName].Count == 0)
            {
                this.byAlbumAndTrack.Remove(albumName);
            }

            if (this.byAlbumAndArtistAndTrackList[albumName][track.Artist].Count == 0)
            {
                this.byAlbumAndArtistAndTrackList[albumName].Remove(track.Artist);

                if (this.byAlbumAndArtistAndTrackList[albumName].Count == 0)
                {
                    this.byAlbumAndArtistAndTrackList.Remove(albumName);
                }
            }
        }
    }
}
