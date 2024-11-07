using System.Diagnostics;
using TicTacToe.Logic;

class Program
{
	static void Main()
	{
		GameLogic main = new GameLogic();

		for (int i = 0; i < 9; i++)
		{
			int userinput;
			Console.WriteLine("Enter a Number between 1 - 9. " +
				"\n|7|8|9|\n|4|5|6|\n|1|2|3|");

			while (true)
			{
				if (int.TryParse(Console.ReadLine(), out userinput) && main.TakeInput(userinput))
				{
					break;//valid input
				}

				Console.WriteLine("Invalid input or field already chosen. Please try again.");
			}

			//check for win 
			var winCheck = main.CheckForWin();
			if (winCheck.IsWin)
			{
				Console.WriteLine($"{winCheck.WinningPlayer} won!");
				main.Restart();
				break;
			}
			else
			{
				if (i == 8)
				{
					Console.WriteLine("Its a Draw.");
					main.Restart();
					break;
				}

				Console.WriteLine("No winner yet. Next player's turn.");
				main.SwitchPlayers();
				Console.WriteLine(main.Turn == Players.Player1 ? "Player 1 turn" : "Player 2 turn");
			}
		}
	}
}