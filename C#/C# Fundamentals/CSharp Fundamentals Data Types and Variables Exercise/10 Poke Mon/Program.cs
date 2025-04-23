namespace PokeMon
{
    using System;

    internal class Program
    {
        private static void Main(string[] args)
        {
            int pokemonPower = int.Parse(Console.ReadLine());
            int targetDistance = int.Parse(Console.ReadLine());
            int exzastion = int.Parse(Console.ReadLine());

            double halfPokemonPower = pokemonPower / 2.0;
            int targetsCount = 0;

            while (targetDistance <= pokemonPower)
            {

                if (pokemonPower == halfPokemonPower && exzastion != 0)
                
                {
                    pokemonPower /= exzastion;

                    if (pokemonPower < targetDistance)
                    {
                        break;
                    }

                }

                pokemonPower -= targetDistance;
                targetsCount++;

            }

            Console.WriteLine(pokemonPower);
            Console.WriteLine(targetsCount);

        }
    }
}