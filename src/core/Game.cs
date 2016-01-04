using System;
using System.Collections.Generic;

namespace Monopoly.Core {

    public class Game {

        public Board Board { get; set; }

        public List<Player> Players { get; private set; }

        public Player CurrentPlayer { get; private set; }

    }

}
