using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SnakeLikeGame
{
	public class SnakeLikeGameProgram
	{
		//creating global variable that will contain snake movement direction
		static ConsoleKey _consoleKey;

		//creating global array (test-array) that will contain the field chars
		static string[,] _tableArray = new string[28, 28]; 

		public static void Main(string[] args)
		{
			SnakeGame();

			Thread threadForReadKey = new Thread(ReadKey);
			threadForReadKey.IsBackground = true;
			threadForReadKey.Start();

			_consoleKey = ConsoleKey.RightArrow;
			MoveSnake();
		}
		//creating a metod that will set the whole gameplay
		static void SnakeGame()
		{
			//game rules
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("Welcome to Snake-like Game");
			Console.WriteLine("Using your arrow keys move the snake (@) to leave the field full of stars");
			Console.WriteLine("You should avoid the field boundaries");
			Console.WriteLine("If you want to finish this game session press \"Enter\"");
			Console.CursorVisible = false;
			Console.ReadLine(); 
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.White; 

			//setting the table and it's broders
			for (int i = 0; i<= 29; i++)
			{
				for (int y = 0; y <= 29; y++)
				{
					if (i == 0 || i == 29)
					{
						Console.Write("--");
					}
					else
					{
						if (y == 0)
						{
							Console.Write("|");
						}
						else
						{
							if (y == 29)
							{
								Console.Write(" |");
							}
							else
							{
								Console.Write(" ."); 
							}
						}
					}
				}
				Console.WriteLine();
			}
			Console.SetCursorPosition(59, 0);
			Console.Write("  ");
			Console.SetCursorPosition(59, 29);
			Console.Write("  ");
			for (int i = 0; i < 5; i++)
			{
				Console.Beep();
			}

			//seting the dog initial place
			Console.SetCursorPosition(1, 1);
			Console.Write("@");
		}

		//creating the dog initial place markers
		static int leftPosition = 1;
		static int upPosition = 1;

		//creating a method that will set all movements of snake
		static void MoveSnake()
		{
			//creating variables to indicate test-array fields
			int tableArrayLeft = 0;
			int tableArrayUp = 0;

			//filling the initial field in test-array
			_tableArray[tableArrayLeft, tableArrayUp] = " *";

			//creating an endless cycle for a constant snake movement
			while (true)
			{
				if (leftPosition > 55 || upPosition > 28)
				{
					for (int i = 0; i < 3; i++)
					{
						Console.Beep(450, 100);
					}
					Console.Clear();
					Console.WriteLine("Game over");
					Console.WriteLine();
					Console.WriteLine("Press \"Enter\" three times to exit");
					Console.ReadLine();
					return;
				}
				else
				{
					if (_consoleKey == ConsoleKey.RightArrow)
					{
						Console.SetCursorPosition(leftPosition, upPosition);
						tableArrayLeft++;
						if (tableArrayLeft < 28)
						{
							_tableArray[tableArrayLeft, tableArrayUp] = " *";
						}
						Console.Write(" *");
						leftPosition = leftPosition + 2;
						Console.SetCursorPosition(leftPosition, upPosition);
						Console.Write(" @");
					}

					if (_consoleKey == ConsoleKey.LeftArrow)
					{
						if (leftPosition == 1)
						{
							for (int i = 0; i < 3; i++)
							{
								Console.Beep(450, 100);
							}
							Console.Clear();
							Console.WriteLine("Game over");
							Console.WriteLine();
							Console.WriteLine("Press \"Enter\" three times to exit");
							Console.ReadLine();
							return;
						}
						else
						{
							Console.SetCursorPosition(leftPosition, upPosition);
							tableArrayLeft--;
							if (tableArrayLeft > 0)
							{
								_tableArray[tableArrayLeft, tableArrayUp] = " *";
							}
							Console.Write(" *");
							leftPosition = leftPosition - 2;
							Console.SetCursorPosition(leftPosition, upPosition);
							Console.Write(" @");
						}
					}

					if (_consoleKey == ConsoleKey.UpArrow)
					{
						if (upPosition == 0)
						{
							for (int i = 0; i < 3; i++)
							{
								Console.Beep(450, 100);
							}
							Console.Clear();
							Console.WriteLine("Game over");
							Console.WriteLine();
							Console.WriteLine("Press \"Enter\" three times to exit");
							Console.ReadLine();
							break;
						}
						else
						{
							Console.SetCursorPosition(leftPosition, upPosition);
							tableArrayUp--; 
							if (tableArrayUp > 0)
							{
								_tableArray[tableArrayLeft, tableArrayUp] = " *";
							}
							Console.Write(" *");
							upPosition = upPosition - 1;
							Console.SetCursorPosition(leftPosition, upPosition);
							Console.Write(" @");
						}
					}

					if (_consoleKey == ConsoleKey.DownArrow)
					{
						Console.SetCursorPosition(leftPosition, upPosition);
						tableArrayUp++;
						if (tableArrayUp < 28)
						{
							_tableArray[tableArrayLeft, tableArrayUp] = " *"; 
						}
						Console.Write(" *");
						upPosition = upPosition + 1;
						Console.SetCursorPosition(leftPosition, upPosition);
						Console.Write(" @");
					}

					//Freezing main thread
					Thread.Sleep(150);

					//creating a bool and calling for function that will check if the user won 
					bool win = WinGame();
					if (win)
					{
						for (int i = 0; i < 3; i++)
						{
							Console.Beep();
							Console.Beep(1000, 200);
						}
						Console.Clear();
						Console.ForegroundColor = ConsoleColor.Magenta;
						Console.WriteLine("You win!");
						Console.ForegroundColor = ConsoleColor.White;
						Console.WriteLine();
						Console.WriteLine("Press \"Enter\" three times to exit");
						Console.ReadLine();
						return;
					}

					//game over by users desire
					if (_consoleKey == ConsoleKey.Enter)
					{
						for (int i = 0; i < 3; i++)
						{
							Console.Beep(450, 100);
						}
						Console.Clear();
						Console.WriteLine("Game over");
						Console.WriteLine();
						Console.WriteLine("Press \"Enter\" three more times to exit");
						Console.ReadLine();
						return;
					}
				}
			}
		}

		//creating a method that will read user input
		static void ReadKey()
		{
			while (true)
			{
				//creating a variable that contains users input
				var key = Console.ReadKey();

				//key limitations
				if (key.Key != ConsoleKey.UpArrow && key.Key != ConsoleKey.DownArrow && key.Key != ConsoleKey.LeftArrow && key.Key != ConsoleKey.RightArrow && key.Key != ConsoleKey.Enter)
				{
					Console.SetCursorPosition(leftPosition + 2, upPosition);
					Console.Write(" ");
					Console.SetCursorPosition(1, 30);
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("You can use only arrow keys to play!");
					Console.WriteLine("If you want to finish this game session press \"Enter\"");
					Console.ForegroundColor = ConsoleColor.White; 
					for (int i = 0; i < 2; i++)
					{
						Console.Beep(950, 100);
					}
				}

				//setting logic for keys
				if (key.Key == ConsoleKey.UpArrow || key.Key == ConsoleKey.DownArrow || key.Key == ConsoleKey.LeftArrow || key.Key == ConsoleKey.RightArrow || key.Key == ConsoleKey.Enter)
				{
					_consoleKey = key.Key;
				}
			}
		}

		//creating a method that will compare all elements in array
		static bool WinGame()
		{
			for (int i = 0; i < 28; i++)
			{
				for (int y = 0; y < 27; y++)
				{
					if (_tableArray[i, y] != " *")
					{
						return false;
					}
				}
			}
			return true;
		}
	}
}
