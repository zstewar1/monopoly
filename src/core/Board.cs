using System;

namespace Monopoly.Core {

    /// <summary>
    /// A space on the Monopoly board.
    /// </summary>
    public abstract class Space {

        /// <summary>
        /// The game that this space is in.
        /// </summary>
        public Game Game { get; set; }

    }

    /// <summary>
    /// A space that triggers an action when the player lands on it.
    /// </summary>
    internal interface ILandActionSpace {
        /// <summary>
        /// Action that happens when the player lands on this space.
        /// </summary>
        /// <param name="player">The player who landed on the space.</param>
        void OnPlayerLanded (Player player);
    }

    /// <summary>
    /// A space which triggers an action when the player passes over it.
    /// </summary>
    internal interface IPassActionSpace {
        /// <summary>
        /// The action that happens when a player passes (or lands on) this space.
        /// </summary>
        /// <param name="player">The player who passed the space.</param>
        void OnPlayerPassed (Player player);
    }

    /// <summary>
    /// A space which is an ownable property.
    /// </summary>
    public class PropertySpace : Space {

        /// <summary>
        /// The property associated with this space on the board.
        /// </summary>
        public Property Property { get; set; }

    }

    /// <summary>
    /// A space which causes an action to happen.
    /// </summary>
    public class ActionCardSpace : Space {

        /// <summary>
        /// The deck of action cards associated with this space.
        /// </summary>
        public ActionCardDeck Deck { get; set; }

    }

    public class GoSpace : Space, IPassActionSpace {

        /// <summary>
        /// How much money players get for passing go.
        /// </summary>
        public int PassGoValue { get; set; }

        public void OnPlayerPassed (Player player) {
            player.Money += PassGoValue;
        }

    }

    /// <summary>
    /// Just visiting! You hope.
    /// </summary>
    public class JailSpace : Space {

        /// <summary>
        /// How much players have to pay to get out of jail if they don't get doubles or a get out of jail free card.
        /// </summary>
        public int Bail { get; set; }

    }

    /// <summary>
    /// Go directly to Jail. Do not pass Go. Do not collect $200.
    /// </summary>
    public class GoToJailSpace : Space {
    }

    /// <summary>
    /// Do nothing. Get nothing. You're just safe.
    /// </summary>
    public class FreeParkingSpace : Space {
    }

    /// <summary>
    /// 10% or $200, and you don't get to calculate your worth first.
    /// </summary>
    public class TaxSpace : Space {
    }

    /// <summary>
    /// $75.
    /// </summary>
    public class JewleryTaxSpace : Space {
    }

    /// <summary>
    /// The Monopoly board. A collection of spaces.
    /// </summary>
    public class Board {

        /// <summary>
        /// A back reference to the game that owns this board.
        /// </summary>
        /// <value>The game.</value>
        public Game Game { get; set; }

        /// <summary>
        /// The collection of spaces which make up the board.
        /// </summary>
        public Space[] Spaces { get; private set; }

    }

}
