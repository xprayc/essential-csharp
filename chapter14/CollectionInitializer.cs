using System;
using System.Collections.Generic;

class Program
{
	static void Main()
	{
		List<string> sevenWorldBlunders;
		sevenWorldBlunders = new List<string>()
		{
			// Quotes from Ghandi
			"Wealth without work",
			"Pleasure without conscience",
			"Knowledge without character",
			"Commerce without morality",
			"Science without humanity",
			"Worship without sacrifice",
			"Politics without principle"
		};

		Print(sevenWorldBlunders);
	}

	static void Print<T>(IEnumerable<T> items)
	{
		foreach (T item in items)
		{
			System.Console.WriteLine(item);
		}
	}
}
