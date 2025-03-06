using FluentAssertions;

namespace IdealWeightCalculator.Tests
{
    [TestClass]
    public class IntegrationTests
    {
        [TestMethod]
        public void AddUser_WithGoodUser_Should_Save()
        {
            User user = new User
            {
                Name = "Abdullah",
                BirthDate = DateTime.Now,
                Email = "Abdullah@Test.com",
            };

            DataAccessLayer dataAccessLayer = new DataAccessLayer(new WeightContext());
            dataAccessLayer.AddUser(user);

            User userToFind = dataAccessLayer.GetUser("Abdullah");
            userToFind.Should().BeEquivalentTo(user);
        }
    }
}
