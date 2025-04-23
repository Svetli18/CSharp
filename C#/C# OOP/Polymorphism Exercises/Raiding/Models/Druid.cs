namespace Raiding.Models
{
    public class Druid : BaseHero
    {
        private const int Default_Druid_Power = 80;

        public Druid(string name) 
            : base(name, Default_Druid_Power)
        {

        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {base.Name} healed for {base.Power}";
        }
    }
}
