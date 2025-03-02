namespace IdealWeightCalculator.Tests
{
	[TestClass]
	public class TestInitializer
	{
		[AssemblyInitialize]
		public static void AssemblyInitialize(TestContext testContext)
		{
			testContext.WriteLine("In Assembly Initialize");
		}

		[AssemblyCleanup]
		public static void AssemblyCleanup(TestContext testContext)
		{

		}
	}
}
