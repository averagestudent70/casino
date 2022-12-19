namespace Casino
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Random random = new Random();
			double odds = 0.75;
			
			Player player = new Player() { Cash = 100, Name = "The Player" };

			Console.WriteLine($"Welcome to the casino. The odds are {odds}.");

			while (player.Cash > 0)
			{
				player.WriteMyInfo();
				
				Console.Write("How much do you want to bet: ");
				string howMuch = Console.ReadLine();

				if (int.TryParse(howMuch, out int amount))
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
					Console.WriteLine("Please enter a valid amount.");
				}

				Console.WriteLine();
			}

			Console.WriteLine("Thank you for playing. Better luck next time.");
		}
	}
}