using Moq;
using SW.DataAccess;
using SW.Domain;
using SW.Domain.CustomExceptions;
using SW.Domain.DTOs;
using SW.Domain.ServicesImplementations;
using Xunit;

namespace ServicesRebelsUnitTest
{
    public class ServicesRebelsTestSuite
    {
        private readonly ServicesRebels _servicesRebels;
        private readonly Mock<IRepositoryRebels> _repositoryRebelsMock = new Mock<IRepositoryRebels>();

        public ServicesRebelsTestSuite()
        {
            _servicesRebels = new ServicesRebels(_repositoryRebelsMock.Object);
        }

        [Fact]
        public void AddRebel_ValidInputButNoResponseFromRepo_ThrowsException()
        {
            // Arrange
            RebelDTO validInput = new RebelDTO { Name = "RebelName", PlanetName = "PlanetName" };
            _repositoryRebelsMock.Setup(x => x.Create(It.IsAny<Rebel>())).Returns(() => { return null; });

            // Act
            var exception = Record.Exception(() => { _servicesRebels.AddRebel(validInput); });

            // Assert
            Assert.IsType<SavingToFileException>(exception);
        }

    }
}
