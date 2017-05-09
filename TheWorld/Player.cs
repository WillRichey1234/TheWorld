using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWorld
{
    /// <summary>
    /// A player in TheWorld
    /// </summary>
    public class Player
    {
        /// <summary>
        /// The player's name
        /// </summary>
        public String Name { get; protected set; }

        /// <summary>
        /// What level is the player.
        /// </summary>
        public int Level { get; protected set; }

        /// <summary>
        /// Player's wallet
        /// </summary>
        public Money MoneyPouch { get; protected set; }

        /// <summary>
        /// The area that the player is currently in.
        /// </summary>
        public Area CurrentArea { get; protected set; }

        /// <summary>
        /// Create a new Player for the game.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="startArea"></param>
        public Player(String name, ref Area startArea)
        {
            this.Name = name;
            this.CurrentArea = startArea;
            this.Level = 1;

        }
    }
}
