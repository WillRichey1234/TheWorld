using System;
using System.Collections.Generic;

namespace TheWorld
{
	class MainClass
	{
		private static Area currentArea;
		private static Player player;

		/// <summary>
		/// The command words.
		/// These are all the words that the game will accept as commands.
		/// You will need to add more words to make the game more interesting!
		/// </summary>
		private static List<String> CommandWords = new List<string> () {
			"go", "look", "help", "quit", "examine"
		};

		public static void Main( string[] args )
		{
			Console.WriteLine ("What is your name?");
			player = new Player (Console.ReadLine ());
			player.Stats = new StatChart () {
				Level=1,
				MaxHPs = Dice.Roll(Dice.Type.D10, 1),
				HPs = 10,
				Atk = 2,     //add speed. if higher than enemy's, you go first?
				Def = 1
			};

			currentArea = WorldBuilder.BuildWorld ();

			String command = "";

			Console.WriteLine (currentArea);

			while (!command.ToLower ().Equals ("quit"))
			{
				// Do the Game Loop!
				Console.Write (">> ");
				command = Console.ReadLine ();

				ParseCommand (command.ToLower ());
			}

			Console.WriteLine ("Bye!");
			Console.ReadKey ();
		}

		/// <summary>
		/// Parses the command and do any required actions.
		/// </summary>
		/// <param name="command">Command as typed by the user.</param>
		private static void ParseCommand( String command )
		{
			String[] parts = command.Split (' ');
			String cmdWord = parts [0];

			if (!CommandWords.Contains (cmdWord))
			{
				Console.WriteLine ("I don't understand... (type \"help\" to see a list of commands I know.)");
				return;
			}

			if (cmdWord.Equals ("look"))
			{
				ProcessLookCommand (parts);
			} 
			else if (cmdWord.Equals ("go"))
			{
				ProcessGoCommand (parts);
                Console.WriteLine("{0}", currentArea);
            }
            else if (cmdWord.Equals ("help"))
            {
                ProcessHelp(parts);
            }
       
		}

        protected static void ProcessHelp(String[]parts)
        {
            if (parts.Length == 1)
            {
                //generic help--list of commands
                Console.WriteLine("Available commands: look, look at, go, examine, attack, quit");
            }
            else if (parts[1].Equals("look"))
            {
                Console.WriteLine("'look' is used to look at an area.");
            }
            else if (parts[1].Equals("look at"))
            {
                Console.WriteLine("'look at' is used to look at a specific object in greater detail.");
            }
            else if (parts[1].Equals("go"))
            {
                Console.WriteLine("'go' is used to travel to a different area.");
            }
            else if (parts[1].Equals("quit"))
            {
                Console.WriteLine("'quit' is used to exit the program. Please don't. Like, ever. We put a lot of work into this.");
            }
        }






		/// <summary>
		/// What happens when the user types "look" as the command word.
		/// </summary>
		/// <param name="parts">Command Parts.</param>
		private static void ProcessLookCommand(String[] parts)
		{
			if (parts.Length == 1)
				Console.WriteLine (currentArea.LookAround ());
			else
			{
				try
				{
					Console.WriteLine (currentArea.LookAt (parts [1]));
				}
				catch(ArgumentException e)
				{
					Console.WriteLine (e.Message);
				}
			}
		}

		/// <summary>
		/// Processes the go command.
		/// </summary>
		/// <param name="parts">Parts.</param>
		private static void ProcessGoCommand(String[] parts)
		{
			if (parts.Length == 1)
				Console.WriteLine ("Go where?");
			else
			{
				try
				{
					currentArea = currentArea.GetNeighbor(parts[1]);
				}
				catch(ArgumentException e)
				{
					Console.WriteLine (e.Message);
				}
			}
		}


	}
}
