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

    /// <summary>
    /// Represents an abstract monopoly dice pair which can be thrown.
    /// </summary>
    public interface IDice {

        /// <summary>
        /// The result from the last time the dice were thrown.
        /// </summary>
        DiceThrow LastThrow { get; }

        /// <summary>
        /// Throws the dice, returning the value of the throw.
        /// </summary>
        DiceThrow Throw ();
    }

    /// <summary>
    /// Tracks the game's dice.
    /// </summary>
    public class Dice : IDice {

        #region Private Variables

        /// <summary>
        /// The random source for these die.
        /// </summary>
        private Random random;

        #endregion // Private Variables

        #region Public Properties

        public DiceThrow LastThrow { get; private set; }

        #endregion // Public Properties

        #region Constructors

        public Dice () {
            random = new Random();
        }

        #endregion // Constructors

        #region Public Methods

        /// <summary>
        /// Throw the dice, setting a random value for the first and second die of 
        /// LastThrow, and return the value.
        /// </summary>
        public DiceThrow Throw () {
            DiceThrow t = new DiceThrow();

            t.FirstDie = random.Next(1, 7);
            t.SecondDie = random.Next(1, 7);

            LastThrow = t;
            return t;
        }

        /// <summary>
        /// Reseed the RNG from the current time.
        /// </summary>
        public void Reseed () {
            random = new Random();
        }

        /// <summary>
        /// Reseed the RNG with the specified seed.
        /// </summary>
        /// <param name="seed">The random seed.</param>
        public void Reseed (int seed) {
            random = new Random(seed);
        }

        #endregion // Public Methods
    }

}
