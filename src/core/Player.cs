using System;
using System.Collections.Generic;

namespace Monopoly.Core {

    /// <summary>
    /// Represents a player in the game.
    /// </summary>
    public class Player {

        /// <summary>
        /// The name of this player.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// How much money this player has.
        /// </summary>
        public int Money { get; set; }

        /// <summary>
        /// The collection of properties owned by this player.
        /// </summary>
        public List<Property> OwnedProperties { get; private set; }

        /// <summary>
        /// The space that the player is currently on.
        /// </summary>
        public Space CurrentSpace { get; private set; }

        /// <summary>
        /// Action cards that allow saving. (Get out of jail free).
        /// </summary>
        public List<SavableActionCard> SavedActions { get; private set; }

    }
}
