﻿namespace Raiding.Contracts
{
    public interface IBaseHero
    {
        string Name { get; }

        int Power { get; }

        string CastAbility();
    }
}
