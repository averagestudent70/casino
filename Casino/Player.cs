using System;

public class Player
{
	public string Name;
	public int Cash;

	/// <summary>
	/// Writes the name and the amount of cash available to the console.
	/// </summary>
	public void WriteMyInfo()
	{
		Console.WriteLine(Name + " has " + Cash + " bucks.");
	}

	/// <summary>
	/// Gives some cash, removing it from the wallet (or printing a message 
	/// to the console if not enough cash is available).
	/// </summary>
	/// <param name="amount">Amount of cash to give.</param>
	/// <returns>The amount of cash removed from the wallet.</returns>
	public int GiveCash(int amount)
	{
		if (amount < 0)
		{
			Console.WriteLine(Name + " says: " + amount + " isn't a valid amount");
			return 0;
		}
		if (amount > Cash)
		{
			Console.WriteLine(Name + " says: " +
				"I don't have enough cash to give you " + amount);
			return 0;
		}
		Cash -= amount;
		return amount;
	}

	/// <summary>
	/// Receive some cash, adding it to the wallet (or printing a message
	/// to the console if the amount is invalid).
	/// </summary>
	/// <param name="amount">Amount of cash to give.</param>
	public void ReceiveCash(int amount)
	{
		if (amount < 0)
			Console.WriteLine(Name + " says: " + amount + "isn't an amount I'll take");
		else
			Cash += amount;
	}
}
