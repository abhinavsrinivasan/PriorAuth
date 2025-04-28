using PriorAuthPrototype.Dtos;
using PriorAuthPrototype.Models;
using Microsoft.AspNetCore.Mvc;

public interface IPriorAuthorizationService
{
    Task<List<PriorAuthorizationRequest>> GetAllRequestsAsync();
    Task<PriorAuthorizationRequestDto?> GetRequestByIdAsync(int id);
    Task<PriorAuthorizationRequestDto> CreateRequestAsync(PriorAuthorizationRequest request);
    Task<PriorAuthorizationRequest?> UpdateRequestAsync(int id, PriorAuthorizationRequest updatedRequest);
    Task<bool> DeleteRequestAsync(int id);
}
