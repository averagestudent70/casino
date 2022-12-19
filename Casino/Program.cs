namespace Casino
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Random random = new Random();
			double odds = 0.75;
			
			Player player = new Player() { Cash = 100, Name = "The Player" };
			int previousBalance = player.Cash;

			Console.WriteLine($"Welcome to the casino. The odds are {odds}.");

			while (player.Cash > 0)
			{
				player.WriteMyInfo();
				
				Console.Write("How much do you want to bet: ");
				string input = Console.ReadLine();

				if (input == "")
					break;

				if (int.TryParse(input, out int amount))
				{
					int pot = player.GiveCash(amount) * 2;  // the player makes a double-or-nothing bet every round.
					if (pot > 0)
					{
						if (random.NextDouble() > odds)
						{
							player.ReceiveCash(pot);
							Console.WriteLine($"You win {pot}.");
						}
						else
							Console.WriteLine($"Bad luck, you lose {amount}.");
					}
				}
				else
				{
					Console.WriteLine("Please enter a valid amount (press enter to exit.)");
				}

				Console.WriteLine();
			}
			int currentBalance = player.Cash;

			Console.WriteLine();
			Console.WriteLine("Previous Balance: " + previousBalance);
			Console.WriteLine("Current Balance: " + currentBalance);
			Console.WriteLine("You " + (currentBalance >= previousBalance ? "won: " : "lost: ") 
								+ Math.Abs(previousBalance - currentBalance));
			Console.WriteLine("Thank you for playing!");
		}
	}
}