namespace Exam.RePlay
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            HashSet<Track> tracks = new HashSet<Track>();

            Track track = new Track("asd", "bsd", "csd", 4000, 400);
            Track track2 = new Track("dsd", "esd", "fsd", 5000, 400);
            Track track3 = new Track("hsd", "isd", "jsd", 5000, 500);
            Track track4 = new Track("ksd", "lsd", "msd", 5000, 600);
            Track track5 = new Track("nsd", "osd", "psd", 6000, 100);

            tracks.Add(track);
            tracks.Add(track2);
            tracks.Add(track3);
            tracks.Add(track4);
            tracks.Add(track5);
        }
    }
}
