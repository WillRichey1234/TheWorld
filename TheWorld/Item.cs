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

		public Money Value
		{
			get;
			set;
		}

		public Item()
		{
		}
	}
}

