using System;
using System.Collections.Generic;
using System.Linq;

namespace Monopoly.Core {

    /// <summary>
    /// Stores the state of the game.
    /// </summary>
    public class Game {

        #region Private Variables

        /// <summary>
        /// The index of the current player.
        /// </summary>
        private int currentPlayerIndex;

        #endregion //Private Variables

        #region Public Properties

        /// <summary>
        /// The dice being used for this game.
        /// </summary>
        public IDice Dice { get; set; }

        /// <summary>
        /// The board being used for this game.
        /// </summary>
        /// <value>The board.</value>
        public Board Board { get; set; }

        /// <summary>
        /// The list of players in this game.
        /// </summary>
        public List<Player> Players { get; private set; }

        /// <summary>
        /// List of players who have been eliminated from the game.
        /// </summary>
        public List<Player> EliminatedPlayers { get; private set; }

        /// <summary>
        /// Retrieves the player whose turn it currently is.
        /// </summary>
        public Player CurrentPlayer { 
            get { 
                return Players[currentPlayerIndex]; 
            }
        }

        /// <summary>
        /// Gets the winner of the game -- once all other players have been eliminated, the winner
        /// is the one who is left.
        /// </summary>
        public Player Winner {
            get {
                if (Players.Count == 1)
                    return Players[0];
                else
                    return null;
            }
        }

        #endregion // Public Properties

        #region Public Events

        /// <summary>
        /// Called to query the player for an action to take in response to something happening.
        /// Called with the identity of the player to query, localization string id of the query, 
        /// and array of query string ids for each player option.
        /// Return value should be the index of the option that the player chose.
        /// </summary>
        public event Func<Player, string, string[], int> OnQueryPlayer;

        #endregion // Public Events

        #region Public Methods

        /// <summary>
        /// Checks if the current turn has been completed successfully, then ends the turn and
        /// </summary>
        public void EndTurn () {
            if (Players.All(p => p.PendingTransactions.Count == 0)) {
                currentPlayerIndex = (currentPlayerIndex + 1) % Players.Count;
            } else {
                throw new TurnIncompleteException("Players still had pending transactions.");
            }
        }

        #endregion // Public Methods

        #region Internal Methods

        internal int QueryPlayer (Player player, string query, string[] options) {
            if (OnQueryPlayer != null) {
                return OnQueryPlayer(player, query, options);
            }
            throw new NoSubscriberException("Tried to query players but OnQueryPlayer has no subscribers.");
        }

        #endregion // Internal Methods
    }

}
