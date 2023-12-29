using System.Collections.Generic;

namespace BlessingsDicesAndCards;

public record RollResult(
    IEnumerable<Side> Sides,
    IEnumerable<int> Attack, 
    IEnumerable<int> Critial, 
    IEnumerable<int> Defense
);