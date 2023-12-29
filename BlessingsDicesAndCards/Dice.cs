using System;

namespace BlessingsDicesAndCards;

public abstract class Dice
{
    public abstract Side[] Sides { get; }

    public Side Roll(int luck)
    {
        var sides = this.Sides;
        var last = sides.Length - 1;

        var rand = Random.Shared;
        var value = rand.Next(600);

        for (int i = 0; i < last; i++)
        {
            value += luck;
            value -= 100;
            if (value < 0)
                return sides[i];
        }

        return sides[last];
    }
}