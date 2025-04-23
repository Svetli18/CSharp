namespace Raiding.Core
{
    using Raiding.Contracts;
    using Raiding.Core.Contracts;
    using Raiding.IO.Contracts;
    using Raiding.Models;

    public class Engine : IEngine
    {
        private IReader reader;

        private IWriter writer;

        private ICollection<IBaseHero> heroes;

        private Engine()
        {
            this.heroes = new List<IBaseHero>();
        }

        public Engine(IReader reader, IWriter writer)
            :this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            try
            {
                int n = int.Parse(this.reader.ReadLine());

                for (int i = 0; i < n; i++)
                {
                    string name = this.reader.ReadLine();
                    string type = this.reader.ReadLine();

                    switch (type)
                    {
                        case "Druid":
                            this.heroes.Add(new Druid(name));
                            break;
                        case "Paladin":
                            this.heroes.Add(new Paladin(name));
                            break;
                        case "Rogue":
                            this.heroes.Add(new Rogue(name));
                            break;
                        case "Warrior":
                            this.heroes.Add(new Warrior(name));
                            break;
                        default:
                            this.writer.WriteLine("Invalid hero!");
                            break;
                    }
                }

                int heroesTotalPower = 0;

                int bossPower = int.Parse(this.reader.ReadLine());

                foreach (var hero in this.heroes)
                {
                    this.writer.WriteLine(hero.CastAbility());

                    heroesTotalPower += hero.Power;
                }

                this.writer.WriteLine(bossPower <= heroesTotalPower
                    ? "Victory!"
                    : "Defeat...");
            }
            catch (Exception e)
            {
                this.writer.WriteLine(e.Message);
            }
        }
    }
}
