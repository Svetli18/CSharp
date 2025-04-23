namespace _02.FitGym
{
    using System.Collections.Generic;

    public class Trainer
    {
        public Trainer(int id, string name, int popularity)
        {
            this.Id = id;
            this.Name = name;
            this.Popularity = popularity;
            this.Members = new HashSet<Member>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int Popularity { get; set; }

        public HashSet<Member> Members { get; set; }

        public override bool Equals(object obj)
        {
            Trainer other = obj as Trainer;

            if (other == null)
            {
                return false;
            }

            return this.Id.Equals(other.Id);
        }
    }
}