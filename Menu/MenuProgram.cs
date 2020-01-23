using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DogGame;

namespace Menu
{
	class MenuProgram
	{
		static void Main(string[] args)
		{
			Menu();
		}

		static void Menu()
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("Welcome");
			Console.WriteLine();
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.WriteLine("Press \"1\" to choose the Dog Game");
			Console.WriteLine("Press \"2\" to choose the Snake-like Game");
			Console.WriteLine("Then press \"Enter\" twice");
			Console.WriteLine("To exit press \"Esc\"");
			Console.ForegroundColor = ConsoleColor.White;
			string userInput = Console.ReadLine();

			ConsoleKey toEscape = Console.ReadKey().Key;

			if (toEscape == ConsoleKey.Escape)
			{
				return;
			}
			else
			{
				if (userInput != "1" && userInput != "2")
				{
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("There are two games to coose");
					Console.WriteLine("You can't use keys exept 1 and 2!");
					Console.WriteLine("To exit press \"Esc\"");
					Console.ForegroundColor = ConsoleColor.White;
					for (int i = 0; i < 2; i++)
					{
						Console.Beep(950, 100);
						Console.Beep();
					}
				}
				else 
				{
					if (userInput == "1")
					{
						DogGameProgram.Main(null);
					}
					if (userInput == "2")
					{
						SnakeLikeGame.SnakeLikeGameProgram.Main(null); 
					}
				}
			}
		}
	}
}
