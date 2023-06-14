using Moq;
using NPOI.SS.Formula.Functions;
using SW.DistributedSystems.Controllers;
using SW.Domain.CustomExceptions;
using SW.Domain.DTOs;
using SW.Domain.ServicesImplementations;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;
using Xunit;

namespace ControllerUnitTest
{
    public class RebelControllerTestSuite
    {
        private readonly RebelsController _controllerRebels;
        private readonly Mock<IServicesRebels> _serviceRebelsMock = new Mock<IServicesRebels>();

        public RebelControllerTestSuite()
        {
            _controllerRebels = new RebelsController(_serviceRebelsMock.Object);
        }

        [Fact]
        public void AddRebel_InputMissingField_ReturnsBadRequest()
        {
            // Arrange
            List<string> invalidPayload = new List<string> { "RebelName" };
            _serviceRebelsMock.Setup(x => x.AddRebel(It.IsAny<RebelDTO>()))
                .Throws(new ParsingReqPayloadException());

            // Act
            IHttpActionResult response = _controllerRebels.Post(invalidPayload);

            // Assert
            Assert.IsType<BadRequestErrorMessageResult>(response);
        }

        [Fact]
        public void AddRebel_InputEmptyField_ReturnsBadRequest()
        {
            // Arrange
            List<string> invalidPayload = new List<string> { "RebelName", "" };
            _serviceRebelsMock.Setup(x => x.AddRebel(It.IsAny<RebelDTO>()))
                .Throws(new ParsingReqPayloadException());

            // Act
            IHttpActionResult response = _controllerRebels.Post(invalidPayload);

            // Assert
            Assert.IsType<BadRequestErrorMessageResult>(response);
        }

        [Fact]
        public void AddRebel_InputValidInfo_ReturnsOkStatus()
        {
            // Arrange
            List<string> payload = new List<string> { "RebelName", "PlanetName" };
            var rebelDTO = new RebelDTO
            {
                Name = payload[0],
                PlanetName = payload[1],
            };

            _serviceRebelsMock.Setup(x => x.AddRebel(It.IsAny<RebelDTO>())).Returns(rebelDTO);

            // Act
            IHttpActionResult response = _controllerRebels.Post(payload);

            // Assert
            Assert.IsType<OkNegotiatedContentResult<bool>>(response);
        }

    }
}
