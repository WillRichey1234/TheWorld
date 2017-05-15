using System;

namespace TheWorld
{
    /// <summary>
    /// Represents a Dice for a DnD style game!
    /// </summary>
	public static class Dice
	{
		/// <summary>
		/// The random number generator for the dice!
		/// </summary>
		private static Random rand = new Random ();

		/// <summary>
		/// Type of Die to throw.
		/// Enums can be used to limit the number of possible values for a variable.
		/// In this case, the enum will be treated like an Integer, but only the defined values
		/// are allowed.
		/// </summary>
		public enum Type
		{
			Coin = 2,
			D4 = 4,
			D6 = 6,
			D8 = 8,
			D10 = 10,
			D12 = 12,
			D20 = 20
		}

		/// <summary>
		/// Roll a number of the specified type of dice.
		/// </summary>
		/// <param name="type">Type.</param>
		/// <param name="count">numbre of dice to throw.</param>
		/// <returns>The Sum of all dice thrown</returns>
		public static int Roll( Dice.Type type, int count )
		{
			int total = 0;
			for (int i = 0; i < count; i++)
			{
				total += rand.Next ((int)type) + 1;
			}
			return total;
		}
	}
}

