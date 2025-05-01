using Xunit;
using Microsoft.EntityFrameworkCore;
using PriorAuthPrototype.Data;
using PriorAuthPrototype.Models;

public class PriorAuthorizationServiceTests
{
    private AppDbContext GetInMemoryDbContext()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // ensure unique DB for each test
            .Options;

        return new AppDbContext(options);
    }

    [Fact]
    public async Task GetAllRequestsAsync_ReturnsAllFields()
    {
        //Arrange-Act-Assert
        var context = GetInMemoryDbContext();
        var service = new PriorAuthorizationService(context);

        context.PriorAuthorizationRequests.Add(new PriorAuthorizationRequest
        {
            PatientName = "Abhinav Srinivasan",
            ProviderName = "Dr. Koli",
            RequestDate = DateTime.Now,
            ProcedureCode = "PROC321",
            Status = "Approved",
            IsUrgent = true
        });
        await context.SaveChangesAsync();

        //Act
        var result = await service.GetAllRequestsAsync();

        //Assert
        var request = result.First();

        Assert.NotNull(request.PatientName);
        Assert.NotNull(request.ProcedureCode);
        Assert.NotNull(request.Status);
        Assert.True(request.IsUrgent);
    }


    [Fact]
    public async Task UpdateRequestAsync_AppealDeniedRequest()
    {
    // Arrange
    var context = GetInMemoryDbContext();
    var service = new PriorAuthorizationService(context);

    var deniedRequest = new PriorAuthorizationRequest
    {
        PatientName = "John Doe",
        ProviderName = "Dr. Smith",
        RequestDate = DateTime.Now,
        ProcedureCode = "PROC123",
        Status = "Denied",
        IsUrgent = false
    };
    context.PriorAuthorizationRequests.Add(deniedRequest);
    await context.SaveChangesAsync();

    var updatedRequest = new PriorAuthorizationRequest
    {
        PatientName = "Jane Doe",
        ProviderName = "Dr. Smith",
        RequestDate = DateTime.Now,
        ProcedureCode = "PROC123",
        Status = "Approved", 
        IsUrgent = true
    };

    // Act
    var result = await service.UpdateRequestAsync(deniedRequest.Id, updatedRequest);

    // Assert
    Assert.Null(result); 
}




    [Fact]
    public async Task GetRequestByIdAsync_testNull()
{
    var context = GetInMemoryDbContext();
    var service = new PriorAuthorizationService(context);

    var result = await service.GetRequestByIdAsync(999); //fake id

    Assert.Null(result);
}

}