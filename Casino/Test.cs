using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino
{
	internal class Test
	{
		static void TestGuy(string[] args)
		{
			Player joe = new Player() { Name = "Joe", Cash = 50 };
			Player bob = new Player() { Name = "Bob", Cash = 100 };

			while (true)
			{
				joe.WriteMyInfo();
				bob.WriteMyInfo();

				Console.Write("Enter an amount: ");
				string howMuch = Console.ReadLine();

				if (howMuch == "") return;
				if (int.TryParse(howMuch, out int amountToGive))
				{
					Console.Write("Who should give the cash: ");
					string whichGuy = Console.ReadLine();
					if (whichGuy == "Joe")
					{
						int amountGiven = joe.GiveCash(amountToGive);
						bob.ReceiveCash(amountGiven);
					}
					else if (whichGuy == "Bob")
					{
						int amountGiven = bob.GiveCash(amountToGive);
						joe.ReceiveCash(amountGiven);
					}
					else
						Console.WriteLine("Please enter 'Joe' or 'Bob'");
				}
				else
					Console.WriteLine("Please enter an amount (or a black line to exit).");

				Console.WriteLine();
			}
		}
	}
}
