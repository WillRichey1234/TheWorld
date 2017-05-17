using System;
using System.Collections.Generic;

namespace TheWorld
{
	/// <summary>
	/// A Creature that lives in the World.
	/// </summary>
	public class Creature
	{
        /// <summary>
        /// Creature's name
        /// </summary>
		public String Name
		{
			get;
			set;
		}

        /// <summary>
        /// Creature's description.
        /// </summary>
		public String Description
		{
			get;
			set;
		}

        /// <summary>
        /// Stats of the creature.
        /// </summary>
		public StatChart Stats
		{
			get;
			set;
		}
		public override string ToString()
		{
			return string.Format("Creature: Name={0} \n {1} \n Stats={2}", Name, Description, Stats);
		}


	}
}

