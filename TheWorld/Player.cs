using System;
using System.Collections.Generic;

namespace TheWorld
{
	/// <summary>
	/// The Player playing the game!
	/// </summary>
	public class Player
	{
		public String Name
		{
			get;
			private set;
		}

		public StatChart Stats
		{
			get;
			set;
		}

		/// <summary>
		/// The items. In Stacks.  By Name.
		/// </summary>
		private Dictionary<String, List<Item>> Backpack;

		public Player( String name )
		{
			Name = name;
			Backpack = new Dictionary<string, List<Item>> ();
		}

		/// <summary>
		/// Put the Item in your backpack.
		/// </summary>
		/// <param name="item">Item.</param>
		public void PickUp( Item item )
		{
			if (Backpack.ContainsKey (item.Name))
				Backpack [item.Name].Add (item);
			else
				Backpack.Add (item.Name, new List<Item> () { item });
		}
	}
}

