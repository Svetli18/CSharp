namespace Raiding.Models
{
    public class Paladin : BaseHero
    {
        private const int Default_Paladin_Power = 100;

        public Paladin(string name) 
            : base(name, Default_Paladin_Power)
        {

        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {base.Name} healed for {base.Power}";
        }
    }
}
