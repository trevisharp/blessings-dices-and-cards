using System;

namespace BlessingsDicesAndCards;

[Flags]
public enum Side
{
    Empty       = 0b00000000,
    Attack      = 0b00000001,
    Defense     = 0b00000010,
    Critical    = 0b00000100,
    Double      = 0b00001000,
    NewDiceA    = 0b00010000,
    NewDiceB    = 0b00100000,
    Lucky       = 0b01000000,
    Curse       = 0b10000000,
}