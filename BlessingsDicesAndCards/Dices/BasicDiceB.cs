namespace BlessingsDicesAndCards.Dices;

public class BasicDiceB : Dice
{
    public override Side[] Sides => new Side[]{
        Side.Empty,
        Side.Empty,
        Side.Empty,
        Side.Attack,
        Side.Attack,
        Side.Attack | Side.NewDiceA,
    };
}