using System;
using System.Collections.Generic;

namespace TheWorld
{
	/// <summary>
	/// Area represents a location in The World.
	/// Areas can be traveled between and are linked to their neighbors.
	/// Areas can contain objects which can be looked at or even interacted with.
	/// </summary>
	public class Area
	{
		/// <summary>
		/// The neighboring areas, indexed by Keyword for travel.
		/// </summary>
		protected Dictionary<String, Area> NeighboringAreas;

		/// <summary>
		/// The items found in this Area, indexed by Unique Name.
		/// </summary>
		protected Dictionary<String, Item> Items;

		/// <summary>
		/// The creatures found in this Area, indexed by Unique Name.
		/// </summary>
		protected Dictionary<String, Creature> Creatures;

        /// <summary>
        /// Name of this Area.
        /// </summary>
		public String Name
		{
			get;
			set;
		}

        /// <summary>
        /// Description of this Area.
        /// </summary>
		public String Description
		{
			get;
			set;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="TheWorld.Area"/> class.
		/// </summary>
		public Area()
		{
			NeighboringAreas = new Dictionary<string, Area> ();
			Items = new Dictionary<string, Item> ();
			Creatures = new Dictionary<string, Creature> ();
		}

		/// <summary>
		/// Looks at thing.
		/// </summary>
		/// <returns>The Description of the thing you are looking at.</returns>
		/// <param name="thing">Thing.</param>
		public String LookAt( String thing )
		{
			if (Items.ContainsKey (thing))
			{
				return String.Format ("{0} - {1}", Items [thing].Name, Items [thing].Description);
			} else if (Creatures.ContainsKey (thing))
			{
				return String.Format ("{0} - {1}", Creatures [thing].Name, Creatures [thing].Description);
			} else if (NeighboringAreas.ContainsKey (thing))
			{
				return NeighboringAreas [thing].Name;
			}
				
			throw new WorldException("I don't see anything like that...");
		}

		/// <summary>
		/// Looks around.
		/// </summary>
		/// <returns>The around.</returns>
		public String LookAround()
		{
			String longDescription = this.ToString () + Environment.NewLine;
			foreach (String key in Items.Keys)
			{
				longDescription += String.Format ("There is a [{0}]. {1}", key, Environment.NewLine);
			}
			foreach (String key in Creatures.Keys)
			{
				longDescription += String.Format ("You see a [{0}]. {1}", key, Environment.NewLine);
			}

			foreach (String keyword in NeighboringAreas.Keys)
			{
				longDescription += String.Format ("If you go [{0}] there is a {1}.{2}",
				                                  keyword,
				                                  NeighboringAreas [keyword].Name,
				                                  Environment.NewLine);
			}
			return longDescription;
		}

		/// <summary>
		/// Returns a string that represents the current object.
		/// </summary>
		/// <returns>A string that represents the current object.</returns>
		public override String ToString()
		{
			return String.Format ("{0}{1}{2}", Name, Environment.NewLine, Description);
		}

		/// <summary>
		/// Adds the neighbor.
		/// </summary>
		/// <param name="neighbor">Neighbor.</param>
		/// <param name="keyword">Keyword. Must be unique in this area.</param>
		/// <exception cref="WorldException">Throws an WorldException if the keyword is already used in this area.</exception>
		public void AddNeighbor( Area neighbor, String keyword )
		{
			if (NeighboringAreas.ContainsKey (keyword))
				throw new WorldException ("That keyword is already taken");
			
			NeighboringAreas.Add (keyword, neighbor);
		}

		/// <summary>
		/// Gets the neighbor with the given keyword.
		/// </summary>
		/// <returns>The neighbor.</returns>
		/// <param name="keyword">Keyword.</param>
		/// <exception cref="WorldException">If there is no neighbor with the given keyword.</exception>
		public Area GetNeighbor( String keyword )
		{
			if (!NeighboringAreas.ContainsKey (keyword))
				throw new WorldException ("I can't go that way...");

			return NeighboringAreas [keyword];
		}

		/// <summary>
		/// Adds the item.
		/// </summary>
		/// <param name="item">Item.</param>
		/// <param name="uid">Unique Name for the item.  Must be unique in this area.</param>
		/// <exception cref="WorldException">Throws an WorldException if the uid is already used in this area.</exception>
		public void AddItem( Item item, String uid )
		{
			if (Items.ContainsKey (uid))
				throw new WorldException ("There is already an Item in this area with that Unique Name.");
			
			Items.Add (uid, item);
		}

		/// <summary>
		/// Gets the item.
		/// </summary>
		/// <returns>The item.</returns>
		/// <param name="uid">Uid.</param>
		public Item GetItem( String uid )
		{
			if (!Items.ContainsKey (uid))
				throw new WorldException ("I don't see anything like that...");

			return Items [uid];
		}

		/// <summary>
		/// Adds the creature.
		/// </summary>
		/// <param name="creature">Creature.</param>
		/// <param name="uid">Unique name for the creature.  Must be unique in this area.</param>
		/// <exception cref="WorldException">Throws an WorldException if the uid is already used in this area.</exception>
		public void AddCreature( Creature creature, String uid )
		{
			if (Creatures.ContainsKey (uid))
				throw new WorldException ("There is already a Creature with that unique name in this area.");

			Creatures.Add (uid, creature);
		}

		/// <summary>
		/// Gets the creature.
		/// </summary>
		/// <returns>The creature.</returns>
		/// <param name="uid">Uid.</param>
		public Creature GetCreature( String uid )
		{
			if (!Creatures.ContainsKey (uid))
				throw new WorldException ("I don't see that around here...");

			return Creatures [uid];
		}

		/// <summary>
		/// Determines whether this instance can go the specified direction.
		/// </summary>
		/// <returns><c>true</c> if this instance can go the specified direction; otherwise, <c>false</c>.</returns>
		/// <param name="direction">Direction.</param>
		public bool CanGo( String direction )
		{
			return NeighboringAreas.ContainsKey (direction);
		}
	}
}

