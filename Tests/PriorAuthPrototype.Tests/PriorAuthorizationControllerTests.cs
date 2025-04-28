using Xunit;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using PriorAuthPrototype.Controllers;
using PriorAuthPrototype.Models;
using PriorAuthPrototype.Dtos;
using Microsoft.AspNetCore.Mvc;

public class PriorAuthorizationControllerTests
{
    [Fact]
    public async Task GetAllRequests_ReturnsOkResultWithList()
    {
        // Arrange
        var mockService = new Mock<IPriorAuthorizationService>();

        mockService.Setup(service => service.GetAllRequestsAsync())
            .ReturnsAsync(new List<PriorAuthorizationRequestDto>
            {
                new PriorAuthorizationRequestDto
                {
                    Id = 1,
                    PatientName = "John Doe",
                    ProcedureCode = "PROC001",
                    Status = "Pending",
                    IsUrgent = false
                }
            });

        var controller = new PriorAuthorizationController(mockService.Object);

        // Act
        var result = await controller.GetAllRequests();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnValue = Assert.IsType<List<PriorAuthorizationRequestDto>>(okResult.Value);

        Assert.Single(returnValue); // Expect exactly 1 item
        Assert.Equal("John Doe", returnValue[0].PatientName);
    }
}
