using System.Collections.Generic;

namespace Monopoly.Core {

    /// <summary>
    /// Represents a property which can be owned. Usually associated with a space on the board.
    /// </summary>
    public abstract class Property {

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
    }

    /// <summary>
    /// A normal property which can be owned and have houses/hotels built on it.
    /// </summary>
    public class ColorProperty : Property {

        /// <summary>
        /// The price to add a house to this property. (Hotels are basically just five houses).
        /// </summary>
        public int HousePrice { get; set; }

        /// <summary>
        /// The number of houses currently built on this property.
        /// </summary>
        public int NumHouses { get; set; }

        /// <summary>
        /// The value to buy the next house. (Also twice the sell value of the house).
        /// </summary>
        public int[] HouseValue { get; private set; }

    }

    /// <summary>
    /// A railroad property. The rent goes up the more railroads are owned.
    /// </summary>
    public class RailroadProperty : Property {

        /// <summary>
        /// Tells the rent per number of railroads owned by the player.
        /// </summary>
        public int[] OwnedCountPrice { get; private set; }

    }

    /// <summary>
    /// A utility. The rent is determined by a dice roll times a multiplier determined by how many utilities are owned.
    /// </summary>
    public class UtilityProperty : Property {

        /// <summary>
        /// Tells how much the dice roll is multiplied by to get the rent amount.
        /// </summary>
        public int[] OwnedCountMultiplier { get; private set; }

    }
}
