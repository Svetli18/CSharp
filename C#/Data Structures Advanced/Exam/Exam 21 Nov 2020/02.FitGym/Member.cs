namespace _02.FitGym
{
    using System;

    public class Member : IComparable<Member>
    {
        public Member(int id, string name, DateTime registrationDate, int visits)
        {
            this.Id = id;
            this.Name = name;
            this.RegistrationDate = registrationDate;
            this.Visits = visits;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime RegistrationDate { get; set; }

        public int Visits { get; set; }

        public Trainer Trainer { get; set; }

        public override bool Equals(object obj)
        {
            Member other = obj as Member;

            if (other == null)
            {
                return false;
            }

            return this.Id.Equals(other.Id);
        }

        public int CompareTo(Member other)
        {
            return this.RegistrationDate.CompareTo(other.RegistrationDate);
        }
    }
}