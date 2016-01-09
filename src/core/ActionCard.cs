using System;
using System.Collections.Generic;

namespace Monopoly.Core {

    /// <summary>
    /// A card which causes something to happen when drawn.
    /// </summary>
    public abstract class ActionCard {

        /// <summary>
        /// The game that this ActionCard is in.
        /// </summary>
        public Game Game { get; set; }

    }

    /// <summary>
    /// An action card that doesn't have an immediate effect. It can be saved by the player and used when it suits them.
    /// </summary>
    public abstract class SavableActionCard : ActionCard {

        /// <summary>
        /// The deck that this card is from. We need to know this so we can put it back after the player does use it.
        /// </summary>
        public ActionCardDeck SourceDeck { get; set; }

    }

    /// <summary>
    /// A deck of action cards. Either Chance or Community Chest.
    /// </summary>
    public class ActionCardDeck {

        /// <summary>
        /// The collection of cards to draw from.
        /// </summary>
        public List<ActionCard> Deck { get; private set; }

        /// <summary>
        /// The collection of cards that have been drawn and now discarded.
        /// </summary>
        public List<ActionCard> Discard { get; private set; }

    }

}

