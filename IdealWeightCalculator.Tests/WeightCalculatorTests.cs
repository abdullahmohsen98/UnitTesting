using FakeItEasy;
using FluentAssertions;
using Moq;

namespace IdealWeightCalculator.Tests
{
    [TestClass]
    public class WeightCalculatorTests
    {
        public TestContext TestContext { get; set; }

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            testContext.WriteLine("In Class Initializer");
        }

        [ClassCleanup]
        public static void ClassCleanup(TestContext testContext)
        {
            testContext.WriteLine("In Class Cleanup");
        }

        [TestInitialize]
        public void TestInitialize(TestContext testContext)
        {
            testContext.WriteLine("In Class Initialize");
        }

        [TestCleanup]
        public void TestCleanup(TestContext testContext)
        {

        }

        // Naming: Given_When_Then
        [TestMethod]

        // Grouping attributes
        [Description("This test is about checking if the ideal body weight " +
            "of a man with 172 CM in Height is equal to 66.5")]
        [Owner("Abdullah")]
        [Priority(1)]
        [TestCategory("WeightCategory")]
        public void GetIdealBodyWeight_WithSex_M_And_Height_172_Return_66_5()
        {
            // Structure: AAA
            //Arrange
            WeightCalculator sut = new WeightCalculator
            {
                Sex = 'm',
                Height = 172
            };

            //Act
            double actual = sut.GetIdealBodyWeight();
            double expected = 66.5;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetIdealBodyWeight_WithSex_F_And_Height_172_Return_61()
        {
            // Structure: AAA
            //Arrange
            WeightCalculator sut = new WeightCalculator
            {
                Sex = 'f',
                Height = 172
            };

            //Act
            double actual = sut.GetIdealBodyWeight();
            double expected = 61;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetIdealBodyWeight_WithBadSex_And_Height_172_Throw_Exception()
        {
            // Structure: AAA
            //Arrange
            WeightCalculator sut = new WeightCalculator
            {
                Sex = 'b',
                Height = 172
            };

            //Act
            double actual = sut.GetIdealBodyWeight();
            double expected = 0;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Assert_Tests()
        {
            //Assert class involved functionalities:

            Assert.AreEqual(100, 90 + 10);
            Assert.AreEqual(100, 90);
            Assert.AreNotEqual(100, 90);
            Assert.IsTrue(100 == 90 + 10);
            Assert.IsFalse(100 == 90);

            WeightCalculator weight1 = new WeightCalculator();
            WeightCalculator weight2 = weight1;
            Assert.AreSame(weight1, weight2);

            /*WeightCalculator weight1 = new WeightCalculator();
			WeightCalculator weight2 = new WeightCalculator();
			Assert.AreNotSame(weight1, weight2);*/

            WeightCalculator weight = new WeightCalculator();
            Assert.IsInstanceOfType(weight, typeof(WeightCalculator));

            Assert.IsNotNull(weight);
            weight = null;
            Assert.IsNull(weight);
        }

        [TestMethod]
        public void StringAssert_Tests()
        {
            //StringAssert class involved functionalities:

            string name = "Abdullah";

            StringAssert.Contains(name, "Abdu");

            // Check if 'name' matches the exact regex pattern "Abdullah"
            StringAssert.Matches(name, new System.Text.RegularExpressions.Regex("^Abdullah$"));

            // Check if 'name' does NOT match the regex pattern "Abdu"
            StringAssert.DoesNotMatch(name, new System.Text.RegularExpressions.Regex("^Abdu$"));

            StringAssert.EndsWith(name, "lah");

            StringAssert.StartsWith(name, "Abdu");
        }

        [TestMethod]
        public void CollectionAssert_Tests()
        {
            List<string> names = new List<string>() { "Abdullah", "Mohsen", "Ahmed", "Sayed" };

            CollectionAssert.AllItemsAreInstancesOfType(names, typeof(string));
            CollectionAssert.AllItemsAreNotNull(names);
            CollectionAssert.AllItemsAreUnique(names);
            CollectionAssert.Contains(names, "Abdullah");
        }

        [TestMethod]
        public void FluentAssertion_Tests()
        {
            //FluentAssertion Package involved Extension methods:
            string name = "Abdullah";
            name.Should().Contain("ul");
            name.Should().StartWith("Abd");
            name.Should().NotBeNull();
            name.Should().EndWith("lah");

            int number = 8;
            number.Should().Be(number);
            number.Should().BeGreaterThan(7);
            number.Should().BeLessThanOrEqualTo(8);
            number.Should().BeLessThanOrEqualTo(9);

            List<string> names = new List<string>() { "Abdullah", "Mohsen", "Ahmed", "Sayed" };
            name.Should().HaveLength(4);
        }

        [TestMethod]
        public void GetIdealBodyWeightFromDataSource_WithGoodInputs_And_Return_Correct_Results()
        {
            //Arrange
            WeightCalculator weightCalculator = new WeightCalculator(new FakeWeightRepository());

            //Act
            List<double> actual = weightCalculator.GetIdealBodyWeightFromDataSource();
            double[] expected = { 62.5, 62.75, 74 };

            //Assert
            CollectionAssert.AreEqual(expected, actual);
            actual.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void GetIdealBodyWeightFromDataSource_Using_Moq()
        {
            //Arrange
            List<WeightCalculator> weights = new List<WeightCalculator>()
            {
               new WeightCalculator {Height=175,Sex='f'}, /*62.5*/
			   new WeightCalculator {Height=167,Sex='m'}, /*62.75*/
            };

            Mock<IDataRepository> repo = new Mock<IDataRepository>();
            repo.Setup(w => w.GetWeights()).Returns(weights);

            //Act
            WeightCalculator calculator = new WeightCalculator(repo.Object);
            var actual = calculator.GetIdealBodyWeightFromDataSource();
            double[] expected = { 62.5, 62.75 };

            //Assert
            actual.Should().Equal(expected);
        }

        [TestMethod]
        public void GetIdealBodyWeightFromDataSource_Using_FakeItEasy()
        {
            //Arrange
            List<WeightCalculator> weights = new List<WeightCalculator>()
            {
               new WeightCalculator {Height=175,Sex='f'}, /*62.5*/
			   new WeightCalculator {Height=167,Sex='m'}, /*62.75*/
            };

            IDataRepository? repo = A.Fake<IDataRepository>();
            A.CallTo(() => repo.GetWeights()).Returns(weights);

            //Act
            WeightCalculator calculator = new WeightCalculator(repo);
            var actual = calculator.GetIdealBodyWeightFromDataSource();
            double[] expected = { 62.5, 62.75 };

            //Assert
            actual.Should().Equal(expected);
        }

        [DataTestMethod]
        [DataRow(175, 'f', 62.5)]
        [DataRow(167, 'm', 62.75)]
        [DataRow(182, 'm', 74)]
        public void WorkingWith_Data_Driven_Tests(double height, char sex, double expected)
        {
            //Arrange
            WeightCalculator weightCalculator = new WeightCalculator
            {
                Height = height,
                Sex = sex,
            };

            //Act
            var actual = weightCalculator.GetIdealBodyWeight();

            //Assert
            actual.Should().Be(expected);
        }

        public static List<object[]> TestCases()
        {
            return new List<object[]>
            {
                new object[]{175, 'f', 62.5},
                new object[]{167, 'm', 62.75},
                new object[]{182, 'm', 74},
            };
        }

        [DataTestMethod]
        [DynamicData(nameof(TestCases), DynamicDataSourceType.Method)]
        public void MyTestMethod_DynamicData(double height, char sex, double expected)
        {
            //Arrange
            WeightCalculator weightCalculator = new WeightCalculator
            {
                Height = height,
                Sex = sex,
            };

            //Act
            var actual = weightCalculator.GetIdealBodyWeight();

            //Assert
            actual.Should().Be(expected);
        }
    }
}