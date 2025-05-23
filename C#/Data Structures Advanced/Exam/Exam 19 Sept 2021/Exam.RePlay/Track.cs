﻿using System;

namespace Exam.RePlay
{
    public class Track
    {
        public Track(string id, string title, string artist, int plays, int durationInSeconds)
        {
            this.Id = id;
            this.Title = title;
            this.Artist = artist;
            this.Plays = plays;
            this.DurationInSeconds = durationInSeconds;
        }

        public string Id { get; set; }

        public string Title { get; set; }

        public string Artist { get; set; }

        public int Plays { get; set; }

        public int DurationInSeconds { get; set; }

        public override bool Equals(object obj)
        {
            Track other = obj as Track;

            if (other == null)
            {
                return false;
            }

            return this.Id.Equals(other.Id);
        }
    }
}
