namespace MilitaryElite.Models
{
    using MilitaryElite.Contracts;
    using MilitaryElite.Enumarations;

    public class Mission : IMission
    {
        public Mission(string codeName, string strState)
        {
            this.CodeName = codeName;
            this.State = this.TryParseState(strState);
        }

        public string CodeName { get; private set; }

        public State State { get; private set; }

        public void CompleteMission()
        {
            if (this.State == State.finished)
            {
                throw new Exception("Mission already completed!");
            }

            this.State = State.finished;
        }

        private State TryParseState(string strState)
        {
            State state;
            bool parsed = Enum.TryParse(strState, out state);

            if (!parsed)
            {
                return 0;
            }

            return state;
        }

        public override string ToString()
        {
            return $"Code Name: {this.CodeName} State: {this.State.ToString()}";
        }
    }
}
