namespace Raiding.Models
{
    public class Rogue : BaseHero
    {
        private const int Default_Rogue_Power = 80;

        public Rogue(string name) 
            : base(name, Default_Rogue_Power)
        {

        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {base.Name} hit for {base.Power} damage";
        }
    }
}
