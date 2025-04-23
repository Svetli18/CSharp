using System;
using System.Linq;
using System.Collections.Generic;

class Song
{
    public Song(string typeList, string name, string time)
    {
        this.TypeList = typeList;
        this.Name = name;
        this.Time = time;
    }

    public string TypeList { get; set; }
    public string Name { get; set; }
    public string Time { get; set; }
}

internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        List<Song> list = new List<Song>();

        for (int i = 0; i < n; i++)
        {
            string[] currentSong = Console.ReadLine()
                .Split('_', StringSplitOptions.RemoveEmptyEntries);

            string typeList = currentSong[0];
            string name = currentSong[1];
            string time = currentSong[2];

            list.Add(new Song(typeList, name, time));
        }

        string type = Console.ReadLine();

        if (type == "all")
        {
            list.ForEach(s => Console.WriteLine(s.Name));
        }
        else
        {
            list.Where(s => s.TypeList.Equals(type))
                .ToList()
                .ForEach(s => Console.WriteLine(s.Name));
        }
    }
}