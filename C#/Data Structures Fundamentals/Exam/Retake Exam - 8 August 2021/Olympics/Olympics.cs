using System;
using System.Collections.Generic;
public class Olympics : IOlympics
{
    private SortedDictionary<int, Competitor> competitors;
    private Dictionary<int, Competition> competitions;

    public Olympics()
    {
        this.competitors = new SortedDictionary<int, Competitor>();
        this.competitions = new Dictionary<int, Competition>();
    }
    public void AddCompetitor(int id, string name)
    {
        if (this.competitors.ContainsKey(id))
        {
            throw new ArgumentException();
        }

        this.competitors[id] = new Competitor(id, name);
    }

    public void AddCompetition(int id, string name, int participantsLimit)
    {
        if (this.competitions.ContainsKey(id))
        {
            throw new ArgumentException();
        }

        this.competitions[id] = new Competition(name, id, participantsLimit);
    }

    

    public void Compete(int competitorId, int competitionId)
    {
        if (!this.competitors.ContainsKey(competitorId) || !this.competitions.ContainsKey(competitionId))
        {
            throw new ArgumentException();
        }

        Competitor competitor = this.competitors[competitorId];

        this.competitions[competitionId].Competitors.Add(competitor);
    }

    public void Disqualify(int competitionId, int competitorId)
    {
        if (!this.competitions.ContainsKey(competitionId))
        {
            throw new ArgumentException();
        }

        bool isNotFaund = true;

        foreach (var competitor in this.competitions[competitionId].Competitors)
        {
            if (competitor.Id.Equals(competitorId))
            {
                competitor.TotalScore -= this.competitions[competitionId].Score;
                this.competitions[competitionId].Competitors.Remove(competitor);
                isNotFaund = false;
            }
        }

        if (isNotFaund)
        {
            throw new ArgumentException();
        }
    }

    public IEnumerable<Competitor> GetByName(string name)
    {
        List<Competitor> list = new List<Competitor>();

        foreach (var competitor in this.competitors.Values)
        {
            if (competitor.Name.Equals(name))
            {
                list.Add(competitor);
            }
        }

        if (0 == list.Count)
        {
            throw new ArgumentException();
        }

        return list;
    }

    public IEnumerable<Competitor> FindCompetitorsInRange(long min, long max)
    {
        List<Competitor> result = new List<Competitor>();

        foreach (var competitor in this.competitors.Values)
        {
            if (min <= competitor.TotalScore && competitor.TotalScore <= max)
            {
                result.Add(competitor);
            }
        }

        return result;
    }

    public IEnumerable<Competitor> SearchWithNameLength(int min, int max)
    {
        List<Competitor> result = new List<Competitor>();

        foreach (var competitor in this.competitors.Values)
        {
            if (min <= competitor.Name.Length && competitor.Name.Length <= max)
            {
                result.Add(competitor);
            }
        }

        return result;
    }

    public bool Contains(int competitionId, Competitor comp)
    {
        return this.competitions[competitionId].Competitors.Contains(comp);
    }

    public Competition GetCompetition(int id)
    {
        if (!this.competitions.ContainsKey(id))
        {
            throw new ArgumentException();
        }

        return this.competitions[id];
    }

    public int CompetitorsCount()
    {
        return this.competitors.Count;
    }

    public int CompetitionsCount()
    {
        return this.competitions.Count;
    }
}