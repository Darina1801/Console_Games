using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogGame
{
	public class DogGameProgram
	{
		public static void Main(string[] args)
		{
			DogGame();
		}

		static void DogGame()
		{
			//game rules
			Console.WriteLine("Welcome to Dog Game");
			Console.WriteLine("Using your arrow keys move the dog wherever you want");
			Console.WriteLine("If you want to finish this game session press \"Enter\"");
			Console.ReadLine(); 
			Console.Clear();

			//setting the table
			for (int i = 0; i < 10; i++)
			{
				for (int y = 0; y < 10; y++)
				{
					Console.Write(" *");
				}
				Console.WriteLine();
			}

			//seting the dog initial place
			Console.SetCursorPosition(1, 0);
			Console.Write("@");

			//creating the dog initial place markers
			int leftPosition = 1;
			int upPosition = 0;

			//dog movements logic
			while (true)
			{
				var key = Console.ReadKey();

				if (key.Key == ConsoleKey.UpArrow)
				{
					if (upPosition == 0)
					{
						Console.Clear();
						Console.WriteLine("Game over: the dog is lost");
						Console.ReadLine();
						break;
					}
					else
					{
						Console.SetCursorPosition(leftPosition, upPosition);
						Console.Write("*");
						upPosition = upPosition - 1;
						Console.SetCursorPosition(leftPosition, upPosition);
						Console.Write("@");
					}
				}

				if (key.Key == ConsoleKey.DownArrow)
				{
					if (upPosition == 9)
					{
						Console.Clear();
						Console.WriteLine("Game over: the dog is lost");
						Console.ReadLine();
						break;
					}
					else
					{
						Console.SetCursorPosition(leftPosition, upPosition);
						Console.Write("*");
						upPosition = upPosition + 1;
						Console.SetCursorPosition(leftPosition, upPosition);
						Console.Write("@");
					}
				}

				if (key.Key == ConsoleKey.LeftArrow)
				{
					if (leftPosition == 1)
					{
						Console.Clear();
						Console.WriteLine("Game over: the dog is lost");
						Console.ReadLine();
						break;
					}
					else
					{
						Console.SetCursorPosition(leftPosition, upPosition);
						Console.Write("*");
						leftPosition = leftPosition - 2;
						Console.SetCursorPosition(leftPosition, upPosition);
						Console.Write("@");
					}
				}

				if (key.Key == ConsoleKey.RightArrow)
				{
					if (leftPosition == 19)
					{
						Console.Clear();
						Console.WriteLine("Game over: the dog is lost");
						Console.ReadLine();
						break;
					}
					else
					{
						Console.SetCursorPosition(leftPosition, upPosition);
						Console.Write("*");
						leftPosition = leftPosition + 2;
						Console.SetCursorPosition(leftPosition, upPosition);
						Console.Write("@");
					}
				}

				if (key.Key == ConsoleKey.Enter)
				{
					Console.Clear();
					Console.WriteLine("Game over");
					Console.ReadLine();
					break;
				}

				//key limitations
				if (key.Key != ConsoleKey.UpArrow && key.Key != ConsoleKey.DownArrow && key.Key != ConsoleKey.LeftArrow && key.Key != ConsoleKey.RightArrow && key.Key != ConsoleKey.Enter)
				{
					Console.SetCursorPosition(leftPosition + 1, upPosition);
					Console.Write(" ");
					Console.SetCursorPosition(0, 12);
					Console.WriteLine("You can use only arrow keys to play!");
					Console.WriteLine("If you want to finish this game session press \"Enter\"");
				}
			}
		}
	}
}
