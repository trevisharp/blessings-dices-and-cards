using System;
using System.Linq;
using System.Collections.Generic;

namespace BlessingsDicesAndCards;

using Dices;

public class Game
{
    public int BaseLuck { get; set; }
    public int BaseAttack { get; set; }
    public int BaseCritical { get; set; }
    public int BaseDefense { get; set; }

    public List<Dice> Dices { get; set; }
    public List<Card> Cards { get; set; }
    public List<Blessing> Blessings { get; set; }

    public int Magic { get; set; }
    public int Gold { get; set; }
    public int Achievements { get; set; }

    public RollResult Roll()
    {
        int luck = BaseLuck;
        var rand = Random.Shared;
        var dices = this.Dices
            .OrderBy(d => rand.Next())
            .ToList();

        List<Side> sides = new List<Side>();
        for (int i = 0; i < dices.Count; i++)
        {
            var dice = dices[i];
            var side = dice.Roll(luck);

            if (side.HasFlag(Side.Lucky))
                luck++;
            
            if (side.HasFlag(Side.NewDiceA))
                dices.Insert(i + 1, new BasicDiceA());
            
            if (side.HasFlag(Side.NewDiceB))
                dices.Insert(i + 1, new BasicDiceB());
            
            sides.Add(side);
        }

        return getResult(sides);
    }

    private RollResult getResult(List<Side> sides)
    {
        List<int> att = new List<int>();
        List<int> def = new List<int>();
        List<int> crt = new List<int>();

        int acatt = BaseAttack;
        int acdef = BaseDefense;
        int accrt = BaseCritical;

        for (int i = 0; i < sides.Count; i++)
        {
            var side = sides[i];
            int weight = 1;

            if (side.HasFlag(Side.Double))
                weight *= 2;
            
            if (side.HasFlag(Side.Curse))
                weight *= -1;
            
            if (side.HasFlag(Side.Attack))
                acatt += weight;
            
            if (side.HasFlag(Side.Defense))
                acdef += weight;
            
            if (side.HasFlag(Side.Critical))
                accrt += weight;

            att.Add(acatt);
            def.Add(acdef);
            crt.Add(accrt);
        }
        
        return new(sides, att, crt, def);
    }
}