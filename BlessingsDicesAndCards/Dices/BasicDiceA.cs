namespace BlessingsDicesAndCards.Dices;

public class BasicDiceA : Dice
{
    public override Side[] Sides => new Side[]{
        Side.Empty,
        Side.Empty,
        Side.Empty,
        Side.Critical,
        Side.Defense,
        Side.Attack
    };
}