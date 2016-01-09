using System.Collections.Generic;
using System.Linq;

namespace Monopoly.Core {

    /// <summary>
    /// Represents a property which can be owned. Usually associated with a space on the board.
    /// </summary>
    public abstract class Property {

        #region Public Properties

        /// <summary>
        /// The name of this property.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The owner of this property.
        /// </summary>
        public Player Owner { get; set; }

        /// <summary>
        /// The price to buy this property.
        /// </summary>
        public int BuyPrice { get; set; }

        /// <summary>
        /// The amount of money received from mortgaging this property.
        /// </summary>
        public int MortgagePrice { get; set; }

        /// <summary>
        /// The collection of other properties in the same group as this one.
        /// </summary>
        public List<Property> PropertyGroup { get; private set; }

        /// <summary>
        /// Whether or not this property is currently mortgaged.
        /// </summary>
        public bool IsMortgaged { get; set; }

        /// <summary>
        /// Tells if all properties in this property's group are owned by the same player.
        /// </summary>
        public bool IsGroupOwned {
            get { return Owner != null && PropertyGroup.All(p => p.Owner == Owner); }
        }

        /// <summary>
        /// The game that the property belongs to.
        /// </summary>
        public Game Game { get; set; }

        #endregion // Public Properties

        #region Public Methods

        /// <summary>
        /// Computes the value of this property from the buy price, and any other value it may have.
        /// </summary>
        public virtual int GetWorth () {
            return BuyPrice;
        }

        /// <summary>
        /// Tells the largest amount of money that the player can get out of this property through mortgaging 
        /// and selling houses.
        /// </summary>
        public virtual int GetMaxExpenseValue () {
            return IsMortgaged ? 0 : MortgagePrice;
        }

        /// <summary>
        /// Tells the number of properties in this property's group that are owned by the specified player.
        /// </summary>
        /// <returns>The owned count.</returns>
        /// <param name="player">The player to count ownership for.</param>
        public int GetOwnedCount (Player player) {
            if (player == null || Owner == null) {
                return 0;
            }
            return PropertyGroup.Count(p => p.Owner == player);
        }

        /// <summary>
        /// Calculates the rent owed to the owner.
        /// </summary>
        /// <returns>The rent.</returns>
        public abstract int GetRent ();

        #endregion // Public Methods

    }

    /// <summary>
    /// A normal property which can be owned and have houses/hotels built on it.
    /// </summary>
    public class ColorProperty : Property {

        #region Public Properties

        /// <summary>
        /// The price to add a house to this property. (Hotels are basically just five houses).
        /// </summary>
        public int HousePrice { get; set; }

        /// <summary>
        /// The number of houses currently built on this property.
        /// </summary>
        public int NumHouses { get; set; }

        /// <summary>
        /// The rent for the number of houses.
        /// </summary>
        public int[] HouseValue { get; private set; }

        /// <summary>
        /// How much to multiply the base rent by when the whole property group is owned by the same
        /// player.
        /// </summary>
        public int GroupOwnershipMultiplier { get; set; }

        #endregion // Public Properties

        #region Public Methods

        /// <summary>
        /// The worth of a color property takes into account the houses on that property as well as the purchase price.
        /// </summary>
        /// <returns>The worth of this property.</returns>
        public override int GetWorth () {
            int worth = base.GetWorth();
            worth += HousePrice * NumHouses;
            return worth;
        }

        /// <summary>
        /// Tells the largest amount of money that the player can get out of this property through mortgaging 
        /// and selling houses.
        /// </summary>
        public override int GetMaxExpenseValue () {
            int value = base.GetMaxExpenseValue();
            value += (HousePrice / 2) * NumHouses;
            return value;
        }

        public override int GetRent () {
            if (NumHouses > 0) {
                return HouseValue[NumHouses];
            } else if (IsGroupOwned) {
                return GroupOwnershipMultiplier * HouseValue[0];
            } else {
                return HouseValue[0];
            }
        }

        #endregion // Public Methods
    }

    /// <summary>
    /// A railroad property. The rent goes up the more railroads are owned.
    /// </summary>
    public class RailroadProperty : Property {

        /// <summary>
        /// Tells the rent per number of railroads owned by the player.
        /// </summary>
        public int[] OwnedCountPrice { get; private set; }

        /// <summary>
        /// Rent for the railroad is computed from the number of railroads owned by that player.
        /// </summary>
        public override int GetRent () {
            return OwnedCountPrice[GetOwnedCount(Owner)];
        }
    }

    /// <summary>
    /// A utility. The rent is determined by a dice roll times a multiplier determined by how many utilities are owned.
    /// </summary>
    public class UtilityProperty : Property {

        /// <summary>
        /// Tells how much the dice roll is multiplied by to get the rent amount.
        /// </summary>
        public int[] OwnedCountMultiplier { get; private set; }

        public override int GetRent () {
            return OwnedCountMultiplier[GetOwnedCount(Owner)] * Game.Dice.LastThrow.ThrowTotal;
        }

    }
}
