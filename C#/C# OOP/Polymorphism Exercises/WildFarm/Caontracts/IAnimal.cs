﻿namespace WildFarm.Caontracts
{
    public interface IAnimal
    {
        string Name { get; }

        double Weight { get; }

        int FoodEaten { get; }

        string ProduceSound();
    }
}
