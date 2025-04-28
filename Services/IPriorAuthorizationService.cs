using PriorAuthPrototype.Dtos;
using PriorAuthPrototype.Models;

public interface IPriorAuthorizationService
{
    Task<List<PriorAuthorizationRequestDto>> GetAllRequestsAsync();
    Task<PriorAuthorizationRequestDto?> GetRequestByIdAsync(int id);
    Task<PriorAuthorizationRequestDto> CreateRequestAsync(PriorAuthorizationRequest request);
    Task<PriorAuthorizationRequestDto?> UpdateRequestAsync(int id, PriorAuthorizationRequest updatedRequest);
    Task<bool> DeleteRequestAsync(int id);
}
