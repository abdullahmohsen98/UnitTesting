namespace IdealWeightCalculator
{
	class Program
	{
		static void Main(string[] args)
		{
			WeightCalculator weightCalculator = new WeightCalculator
			{
				Height = 172,
				Sex = 'm'
			};
			double weight = weightCalculator.GetIdealBodyWeight();
			Console.WriteLine($"The Ideal Body Weight is: {weight}");

			if (weight == 66.5)
			{
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine("Test Succeeded");
			}
			else
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Test Failed");
			}

			weightCalculator.Sex = 'f';
			weight = weightCalculator.GetIdealBodyWeight();

			if (weight == 66.5)
			{
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine("Test Succeeded");
			}
			else
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Test Failed");
			}

			Console.ReadKey();
		}
	}
}
