using System;

namespace TheWorld
{
	public class StatChart
	{
		/// <summary>
		/// Gets or sets the Hit Points.
		/// </summary>
		public int HPs
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the max Hit points.
		/// </summary>
		public int MaxHPs
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the level.
		/// </summary>
		public int Level
		{
			get;
			set;
		}

		/// <summary>
		/// Attack Power
		/// </summary>
		public int Atk
		{
			get;
			set;
		}

		/// <summary>
		/// Defense Modifier.
		/// </summary>
		/// <value>The def.</value>
		public int Def
		{
			get;
			set;
		}

		/// <summary>
		/// Calculates the attack against an opponent.
		/// </summary>
		/// <returns>The attack value in HPs.</returns>
		/// <param name="opponent">Opponent's stat chart.</param>
		public int CalculateAttack( StatChart opponent )
		{
			// To Do: You need to write some calculations here.
			// Ideally, your calculations should have to do with
			// this object's attack power and the opponent's defense 
			// modifier.  You should also involve a dice roll probably!

			return this.Atk - opponent.Def;
		}

        /// <summary>
        /// Print a nice human readable stat chart!
        /// </summary>
        /// <returns></returns>
		public override string ToString()
		{
			return string.Format("HPs={0}/{1}, Level={2}, Atk={3}, Def={4}", HPs, MaxHPs, Level, Atk, Def);
		}
	}
}

