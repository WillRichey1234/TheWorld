using System;
using System.Collections.Generic;

namespace TheWorld
{
	/// <summary>
	/// An Item in the world.
	/// Some Items might do things!
	/// </summary>
	public class Item
	{
        /// <summary>
        /// Name of the Item
        /// </summary>
		public String Name
		{
			get;
			set;
		}

        /// <summary>
        /// A description of the item.
        /// </summary>
		public String Description
		{
			get;
			set;
		}

        /// <summary>
        /// How much is the Item worth?
        /// </summary>
		public Money Value
		{
			get;
			set;
		}
	}
}

