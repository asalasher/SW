using SW.DataAccess;
using SW.DistributedSystems.Controllers;
using SW.Domain.ServicesImplementations;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;
using Xunit;

namespace IntegrationTestSuite
{
    public class IntegrationTestSuite
    {
        [Fact]
        public void AddRebel_InputMissingField_ReturnsBadRequest()
        {
            // Arrange
            List<string> invalidPayload = new List<string> { "RebelName" };
            RebelsController controller = new RebelsController(new ServicesRebels(new RepositoryRebels()));

            // Act
            IHttpActionResult response = controller.Post(invalidPayload);

            // Assert
            Assert.IsType<BadRequestErrorMessageResult>(response);
        }

        [Fact]
        public void AddRebel_InputEmptyField_ReturnsBadRequest()
        {
            // Arrange
            List<string> invalidPayload = new List<string> { "RebelName", "" };
            RebelsController controller = new RebelsController(new ServicesRebels(new RepositoryRebels()));

            // Act
            IHttpActionResult response = controller.Post(invalidPayload);

            // Assert
            Assert.IsType<BadRequestErrorMessageResult>(response);
        }

        [Fact]
        public void AddRebel_InputValidInfo_ReturnsOkStatus()
        {
            // Arrange
            List<string> payload = new List<string> { "RebelName", "PlanetName" };
            RebelsController controller = new RebelsController(new ServicesRebels(new RepositoryRebels()));

            // Act
            IHttpActionResult response = controller.Post(payload);

            // Assert
            Assert.IsType<OkNegotiatedContentResult<bool>>(response);
        }

    }
}
