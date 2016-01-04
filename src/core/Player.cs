using System;
using System.Collections.Generic;

namespace Monopoly.Core {

    /// <summary>
    /// Represents a player in the game.
    /// </summary>
    public class Player {

        #region Private Variables

        /// <summary>
        /// Internal storage for Money property.
        /// </summary>
        private int money;

        #endregion // Private Variables

        #region Public Properties

        /// <summary>
        /// The name of this player.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// How much money this player has.
        /// </summary>
        public int Money {
            get {
                return money;
            }
            set {
                var oldMoney = money;
                money = value;
                if (OnPlayerMoneyChanged != null) {
                    OnPlayerMoneyChanged(oldMoney, money);
                }
            }
        }

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

        #endregion PublicProperties

        #region Public Events

        /// <summary>
        /// Occurs when the amount of money held by the player changes.
        /// Called with the old amount of money then the new amount of money.
        /// </summary>
        public event Action<int, int> OnPlayerMoneyChanged;

        #endregion // Public Events

    }
}
