namespace Raiding.Models
{
    public class Warrior : BaseHero
    {
        private const int Default_Warrior_Power = 100;

        public Warrior(string name) 
            : base(name, Default_Warrior_Power)
        {

        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {base.Name} hit for {base.Power} damage";
        }
    }
}
