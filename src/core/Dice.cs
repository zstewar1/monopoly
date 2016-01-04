using System;

namespace Monopoly.Core {

    /// <summary>
    /// Represents a throw of the dice in terms of the score on the first die, score on the 
    /// second die, and a property to access the total value of the throw.
    /// </summary>
    public struct DiceThrow {
        public int FirstDie;
        public int SecondDie;

        public int ThrowTotal {
            get { return FirstDie + SecondDie; }
        }

    }

    public class Dice {
        
    }

}
