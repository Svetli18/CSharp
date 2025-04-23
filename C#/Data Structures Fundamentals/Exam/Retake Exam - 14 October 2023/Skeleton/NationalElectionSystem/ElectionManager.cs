namespace NationalElectionSystem
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class ElectionManager : IElectionManager
    {
        private Dictionary<string, Candidate> _candidates;
        private Dictionary<string, Voter> _voters;
        //private Dictionary<string, int> _candidateAndHisVotersCnt;
        private Dictionary<string, List<Candidate>> _candidateAndHisParty;
        private HashSet<string> _votersWhoAreVotedData;

        public ElectionManager()
        {
            this._candidates = new Dictionary<string, Candidate>();
            this._voters = new Dictionary<string, Voter>();
            //this._candidateAndHisVotersCnt = new Dictionary<string, int>();
            this._candidateAndHisParty = new Dictionary<string, List<Candidate>>();
            this._votersWhoAreVotedData = new HashSet<string>();
        }

        public void AddCandidate(Candidate candidate)
        {
            if (!this._candidates.ContainsKey(candidate.Id))
            {
                this._candidates[candidate.Id] = candidate;
                //this._candidateAndHisVotersCnt[candidate.Id] = 0;

                if (!this._candidateAndHisParty.ContainsKey(candidate.Party))
                {
                    this._candidateAndHisParty[candidate.Party] = new List<Candidate>();
                }

                this._candidateAndHisParty[candidate.Party].Add(candidate);
            }
        }

        public void AddVoter(Voter voter)
        {
            if (!this._voters.ContainsKey(voter.Id))
            {
                this._voters[voter.Id] = voter;
            }
        }

        public bool Contains(Candidate candidate)
        {
            return this._candidates.ContainsKey(candidate.Id);
        }

        public bool Contains(Voter voter)
        {
            return this._voters.ContainsKey(voter.Id);
        }

        public IEnumerable<Candidate> GetCandidates()
        {
            return _candidates.Values;
        }

        public IEnumerable<Voter> GetVoters()
        {
            return _voters.Values;
        }

        public void Vote(string voterId, string candidateId)
        {
            Voter voter = this._voters[voterId];

            if (!this._voters.ContainsKey(voterId) || !this._candidates.ContainsKey(candidateId) || 
                this._votersWhoAreVotedData.Contains(voterId) || voter.Age < 18)
            {
                throw new ArgumentException();
            }

            Candidate candidate = this._candidates[candidateId];
            candidate.Voters++;
            //this._candidateAndHisVotersCnt[candidateId]++;
            this._votersWhoAreVotedData.Add(voterId);
        }

        public int GetVotesForCandidate(string candidateId)
        {
            return this._candidates[candidateId].Voters;
        }

        public IEnumerable<Candidate> GetWinner()
        {//TODO tuk ne e gotovo
            PriorityQueue<Candidate> queue = new PriorityQueue<Candidate>();

            foreach (Candidate candidate in this._candidates.Values)
            {
                queue.Add(candidate);
            }

            ;
            if (queue.Peek().Voters == 0)
            {
                return null;
            }

            List<Candidate> candidates = new List<Candidate>(queue.GetValues());

            if (1 < candidates.Count && candidates[0].Voters == candidates[1].Voters)
            {
                int cnt = 1;
                for (int i = 1; i < candidates.Count; i++)
                {
                    if (candidates[0].Voters == candidates[i].Voters)
                    {
                        cnt++;
                    }

                    break;
                }

                return candidates.Take(cnt);
            }

            return queue.GetValues().Take(1);
        }

        public IEnumerable<Candidate> GetCandidatesByParty(string party)
        {
            List<Candidate> candidates = new List<Candidate>(this._candidateAndHisParty[party]);

            return candidates;            
        }
    }
}