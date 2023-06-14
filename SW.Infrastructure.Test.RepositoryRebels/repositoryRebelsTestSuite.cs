using SW.Domain;
using Xunit;

namespace SW.Infrastructure.Test.RepositoryRebels
{
    public class RepositoryRebelsTestSuite
    {
        [Fact]
        public void Create_ValidInput_ReturnsDomainEntity()
        {
            // Arrange
            Rebel rebel = new Rebel { Name = "Name1", PlanetName = "PlanetName" };
            var rebelsRepo = new DataAccess.RepositoryRebels();

            // Act
            Rebel result = rebelsRepo.Create(rebel);

            // Assert
            Assert.NotNull(result);
        }
    }
}
