using System;

namespace Monopoly.Core {

    public class MonopolyException : Exception {

        public MonopolyException (string message)
            : base(message) {
        }

    }

    public class NoSubscriberException : MonopolyException {

        public NoSubscriberException (string message)
            : base(message) {
        }
        
    }

}
