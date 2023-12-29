using System;
using System.Linq;
using System.Collections.Generic;

namespace BlessingsDicesAndCards;

public class Game
{
    public int BaseLuck { get; set; }
    public List<Dice> Dices { get; set; }
    public List<Card> Cards { get; set; }
    public List<Blessing> Blessings { get; set; }

    public int Magic { get; set; }
    public int Gold { get; set; }
    public int Achievements { get; set; }

    public IEnumerable<Side> Roll()
    {
        int luck = BaseLuck;
        var rand = Random.Shared;
        var dices = this.Dices
            .OrderBy(d => rand.Next());

        foreach (var dice in dices)
        {
            var side = dice.Roll(luck);

            if ((side & Side.Lucky) > 0)
                luck++;
            
            yield return side;
        }
    }
}