namespace PlayersAndMonsters
{
    using System;
    using PlayersAndMonsters.Elfs;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            Hero hero = new MuseElf("bo", -11);

            Console.WriteLine(hero);
        }
    }
}