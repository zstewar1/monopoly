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

        #region Public Methods

        /// <summary>
        /// Gets the total value of this player in cash, property, and buildings.
        /// </summary>
        /// <returns>The player's total worth.</returns>
        public int GetWorth () {
            int worth = Money;
            foreach (var prop in OwnedProperties) {
                worth += prop.GetWorth();
            }
            return worth;
        }

        /// <summary>
        /// Gets the largest amount of money this player can owe without going bankrupt, based on mortgaging all 
        /// owned properties, selling all houses/hotels, and using up all cash on hand. Doesn't take into account 
        /// the possibility of the player making a trade deal with another player for money.
        /// </summary>
        /// <returns>The max possible amount of money this player can pay without going bankrupt.</returns>
        public int GetMaxPossibleExpense () {
            int value = Money;
            foreach (var prop in OwnedProperties) {
                value += prop.GetMaxExpenseValue();
            }
            return value;
        }

        #endregion // Public Methods

    }
}
