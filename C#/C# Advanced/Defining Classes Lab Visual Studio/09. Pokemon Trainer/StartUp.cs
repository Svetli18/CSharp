using System;
using System.Linq;
using System.Collections.Generic;

namespace _09._Pokemon_Trainer
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Trainer> traners = new Dictionary<string, Trainer>();

            string cmd;
            while ((cmd = Console.ReadLine()) != "Tournament")
            {
                string[] cmdArgs = cmd.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string trainerName = cmdArgs[0];

                string pokemonName = cmdArgs[1];

                string pokemonElement = cmdArgs[2];

                int pokemonHealth = int.Parse(cmdArgs[3]);

                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                if (!traners.ContainsKey(trainerName))
                {
                    Trainer trainer = new Trainer(trainerName);
                    traners[trainerName] = trainer;
                }

                traners[trainerName].AddPokemon(pokemon);

            }

            while ((cmd = Console.ReadLine()) != "End")
            {
                foreach (var trainer in traners.Values)
                {
                    if (trainer.Pokemons.Any(p => p.Element == cmd))
                    {
                        trainer.AddBadge();
                    }
                    else
                    {
                        trainer.Pokemons.ForEach(p => p.Health -= 10);

                        if (trainer.Pokemons.Any(p => p.Health <= 0))
                        {
                            trainer.Pokemons.RemoveAll(p => p.Health <= 0);
                        }
                    }
                }
            }

            foreach (var treiner in traners.Values.OrderByDescending(t => t.NumberOfBadges))
            {
                Console.WriteLine(treiner);
            }

        }
    }
}
