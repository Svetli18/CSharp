namespace _02.FitGym
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FitGym : IGym
    {
        Dictionary<int, Member> byMember = new Dictionary<int, Member>();
        Dictionary<int, Trainer> byTrainer = new Dictionary<int, Trainer>();

        public void AddMember(Member member)
        {
            if (this.byMember.ContainsKey(member.Id))
            {
                throw new ArgumentException();
            }

            this.byMember[member.Id] = member;
        }

        public void HireTrainer(Trainer trainer)
        {
            if (this.byTrainer.ContainsKey(trainer.Id))
            {
                throw new ArgumentException();
            }

            this.byTrainer[trainer.Id] = trainer;
        }

        public void Add(Trainer trainer, Member member)
        {
            if (!this.byTrainer.ContainsKey(trainer.Id))
            {
                throw new ArgumentException();
            }

            if (member.Trainer != null)
            {
                throw new ArgumentException();
            }

            this.byTrainer[trainer.Id].Members.Add(member);

            if (!this.byMember.ContainsKey(member.Id))
            {
                this.byMember[member.Id] = member;
            }

            member.Trainer = trainer;
        }

        public bool Contains(Member member)
        {
            return this.byMember.ContainsKey(member.Id);
        }

        public bool Contains(Trainer trainer)
        {
            return this.byTrainer.ContainsKey(trainer.Id);
        }

        public Trainer FireTrainer(int id)//tuk moje da se nalaga da zapazim memberite!!!
        {
            if (!this.byTrainer.ContainsKey(id))
            {
                throw new ArgumentException();
            }

            Trainer trainer = this.byTrainer[id];

            foreach (var member in trainer.Members)
            {
                member.Trainer = null;
            }

            this.byTrainer.Remove(id);

            return trainer;
        }

        public Member RemoveMember(int id)
        {
            if (!this.byMember.ContainsKey(id))
            {
                throw new ArgumentException();
            }

            Member member = this.byMember[id];
            this.byMember.Remove(id);

            if (member.Trainer != null)
            {
                member.Trainer.Members.Remove(member);
            }

            return member;
        }

        public int MemberCount { get { return this.byMember.Count; } }
        public int TrainerCount { get { return this.byTrainer.Count; } }

        public IEnumerable<Member> GetMembersInOrderOfRegistrationAscendingThenByNamesDescending()
        {
            return this.byMember.Values.OrderBy(m => m.RegistrationDate).ThenByDescending(m => m.Name);
        }

        public IEnumerable<Trainer> GetTrainersInOrdersOfPopularity()
        {
            if (this.byTrainer.Count == 0)
            {
                return new List<Trainer>();
            }

            ICollection<Trainer> trainers = this.byTrainer.Values.OrderBy(t => t.Popularity).ToList();

            return trainers;
        }

        public IEnumerable<Member> GetTrainerMembersSortedByRegistrationDateThenByNames(Trainer trainer)
        {
            return this.byTrainer[trainer.Id].Members
                .OrderBy(m => m.RegistrationDate)
                .ThenBy(m => m.Name);
        }

        public IEnumerable<Member> GetMembersByTrainerPopularityInRangeSortedByVisitsThenByNames(int lo, int hi)
        {
            return this.byMember.Values
                .Where(m => lo <= m.Trainer.Popularity && m.Trainer.Popularity <= hi)
                .OrderBy(m => m.Visits)
                .ThenBy(m => m.Name);

            //var result = this.byTrainer.Values
            //    .Where(t => lo <= t.Popularity && t.Popularity <= hi)
            //    .OrderBy(t => t.Members.OrderBy(m => m.Visits).ThenBy(m => m.Name)).ToList();
        }

        public Dictionary<Trainer, HashSet<Member>> GetTrainersAndMemberOrderedByMembersCountThenByPopularity()
        {
            //return this.byTrainer.Values.OrderBy(t => t.Members.Count).ThenBy(t => t.Popularity);
            Dictionary<Trainer, HashSet<Member>> result = new Dictionary<Trainer, HashSet<Member>>();

            foreach (var trainer in this.byTrainer.Values.OrderBy(t => t.Members.Count).ThenBy(t => t.Popularity))
            {
                result[trainer] = trainer.Members;
            }

            return result;
        }
    }
}