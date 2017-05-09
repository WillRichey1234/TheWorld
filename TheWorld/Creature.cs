using System;
using System.Collections.Generic;

namespace TheWorld
{
	/// <summary>
	/// A Creature that lives in the World.
	/// </summary>
	public class Creature
	{
		public String Name
		{
			get;
			set;
		}

		public String Description
		{
			get;
			set;
		}

		public StatChart Stats
		{
			get;
			set;
		}

		public Creature()
		{
		}
	}
}

