using System;

namespace Monopoly.Core {

    /// <summary>
    /// The base exception for this library.
    /// </summary>
    public class MonopolyException : Exception {

        public MonopolyException (string message)
            : base(message) {
        }

    }

    /// <summary>
    /// Exception raised when an even is triggered which requires a subscriber to receive it, but it
    /// has no subscribers.
    /// </summary>
    public class NoSubscriberException : MonopolyException {

        public NoSubscriberException (string message)
            : base(message) {
        }
        
    }

    /// <summary>
    /// Raised when you attempt to end the current turn before the turn is complete.
    /// </summary>
    public class TurnIncompleteException : MonopolyException {
        public TurnIncompleteException (string message)
            : base(message) {
        }
    }

}
