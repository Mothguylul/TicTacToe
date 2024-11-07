using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Logic
{
	public class GameLogic
	{
		public List<int> Player1Inputs = new List<int>();

		public List<int> Player2Inputs = new List<int>();

		public readonly List<int[]> winningCombinations = new List<int[]>
		{
			new int[] { 1, 2, 3 },
			new int[] { 4, 5, 6 },
			new int[] { 7, 8, 9 },
			new int[] { 1, 4, 7 },
			new int[] { 2, 5, 8 },
			new int[] { 3, 6, 9 },
			new int[] { 1, 5, 9 },
			new int[] { 3, 5, 7 }
		};

		public Players Turn { get; set; }

		public GameLogic()
		{
			Turn = Players.Player1;
		}

		public bool TakeInput(int input)
		{
			int userinput = input;

			if (userinput > 9 || userinput < 1 || FieldIsAlreadyChoosen(userinput))
			{
				return false;
			}
			else
			{
				if (Turn == Players.Player1)
				{
					Player1Inputs.Add(userinput);
				}

				else if (Turn == Players.Player2)
				{
					Player2Inputs.Add(userinput);
				}
				return true;
			}
		}

		public bool FieldIsAlreadyChoosen(int currentInput)
		{
			/*

			if (Turn == Players.Player1)
			{
				int? searchCurrentInput = Player1Inputs.FirstOrDefault(i => currentInput == currentInput);

				return searchCurrentInput == null ? false : true;

			}
			else if (Turn == Players.Player2)
			{
				int? searchCurrentInput = Player2Inputs.FirstOrDefault(i => currentInput == currentInput);

				return searchCurrentInput == null ? false : true;
			}
			return false;
			 */
			return Player1Inputs.Contains(currentInput) || Player2Inputs.Contains(currentInput);

		}

		public void SwitchPlayers()
		{
			if (Turn == Players.Player1)
			{
				Turn = Players.Player2;
			}
			else
			{
				Turn = Players.Player1;
			}
		}

		public (bool IsWin, Players? WinningPlayer) CheckForWin()
		{
			Players? winningPlayer = null;

			if (Turn == Players.Player1)
			{
				foreach (var wcombination in winningCombinations)
				{
					if (wcombination.All(p => Player1Inputs.Contains(p)))
					{			
						winningPlayer = Players.Player1;
						return (true, winningPlayer);
					}
					else
					{
						return (false, null);
					}
				}
			}

			else if (Turn == Players.Player2)
			{

				foreach (var wcombination in winningCombinations)
				{
					if (wcombination.All(p => Player2Inputs.Contains(p)))
					{
						winningPlayer = Players.Player2;
						return (true, winningPlayer);
					}
					else
					{
						return (false, null);
					}
				}
			}
			return (true, null);

		}

		public void Restart()
		{
			Player1Inputs.Clear();
			Player2Inputs.Clear();
			Turn = Players.Player1;
		}
	}
}
