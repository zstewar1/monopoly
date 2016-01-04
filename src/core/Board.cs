using System;

namespace Monopoly.Core {

    /// <summary>
    /// A space on the Monopoly board.
    /// </summary>
    public abstract class Space {

        /// <summary>
        /// The action that happens when a player lands on this space.
        /// </summary>
        /// <param name="player">The player that landed on this space.</param>
        public abstract void OnPlayerLanded (Player player);

        /// <summary>
        /// The action that happens when a player passes over this space.
        /// </summary>
        /// <param name="player">The player who passed the space.</param>
        public abstract void OnPlayerPassed (Player player);

    }

    /// <summary>
    /// A space which is an ownable property.
    /// </summary>
    public class PropertySpace : Space {

        /// <summary>
        /// The property associated with this space on the board.
        /// </summary>
        public Property Property { get; set; }

        public virtual void OnPlayerLanded (Player player) {
            // Owner need not do anything.
            if (Property.Owner == player)
                return;
            else if (Property.Owner == null) {
                // TODO(zstewar1): Query the player to buy or auction the property.
            } else {
                // Maybe charge rent, but needs to be able to gain additional finances (mortgage or sell houses) to meet cost.
                // Also, may want to implement players needing to request payment.
            }
        }

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

    public class GoSpace : Space {

        /// <summary>
        /// How much money players get for passing go.
        /// </summary>
        public int PassGoValue { get; set; }

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
        /// The collection of spaces which make up the board.
        /// </summary>
        public Space[] Spaces { get; private set; }

    }

}
