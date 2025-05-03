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
public async Task GetAllRequests_ReturnsOkResultWithModelList()
{
    // Arrange
    var mockService = new Mock<IPriorAuthorizationService>();
    var modelData = new List<PriorAuthorizationRequest>
    {
        new PriorAuthorizationRequest
        {
            Id = 1,
            PatientName = "John Doe",
            ProviderName = "Aetna",
            ProcedureCode = "PROC001",
            Status = "Pending",
            IsUrgent = false
        }
    };

    mockService.Setup(service => service.GetAllRequestsAsync())
               .ReturnsAsync(modelData);

    var controller = new PriorAuthorizationController(mockService.Object);

    // Act
    var result = await controller.GetAllRequests();

    // Assert
    var okResult = Assert.IsType<OkObjectResult>(result.Result);
    var returnValue = Assert.IsType<List<PriorAuthorizationRequest>>(okResult.Value);

    Assert.Single(returnValue);
    Assert.Equal("John Doe", returnValue[0].PatientName);
}
}
