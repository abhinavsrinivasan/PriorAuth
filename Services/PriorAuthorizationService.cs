using Microsoft.EntityFrameworkCore;
using PriorAuthPrototype.Data;
using PriorAuthPrototype.Models;
using PriorAuthPrototype.Dtos; 

public class PriorAuthorizationService : IPriorAuthorizationService
{
    private readonly AppDbContext _context;

    //Dependency Injection
    public PriorAuthorizationService(AppDbContext context)
    {
        _context = context;
    }

    //GET ALL
    public async Task<List<PriorAuthorizationRequestDto>> GetAllRequestsAsync()
    {
        return await _context.PriorAuthorizationRequests
            .Select(r => new PriorAuthorizationRequestDto
            {
                Id = r.Id,
                PatientName = r.PatientName,
                ProcedureCode = r.ProcedureCode,
                IsUrgent = r.IsUrgent,
                Status = r.Status
            })
            .ToListAsync();
    }

    // GET BY ID
    public async Task<PriorAuthorizationRequestDto?> GetRequestByIdAsync(int id)
    {
        var request = await _context.PriorAuthorizationRequests.FindAsync(id);
        if (request == null) return null;

        return new PriorAuthorizationRequestDto
        {
            Id = request.Id,
            PatientName = request.PatientName,
            ProcedureCode = request.ProcedureCode,
            IsUrgent = request.IsUrgent,
            Status = request.Status
        };
    }

    // CREATE (POST)
    public async Task<PriorAuthorizationRequestDto> CreateRequestAsync(PriorAuthorizationRequest request)
    {
        _context.PriorAuthorizationRequests.Add(request);
        await _context.SaveChangesAsync();

        return new PriorAuthorizationRequestDto
        {
            Id = request.Id,
            PatientName = request.PatientName,
            ProcedureCode = request.ProcedureCode,
            IsUrgent = request.IsUrgent,
            Status = request.Status
        };
    }

    // UPDATE (PUT)
    public async Task<PriorAuthorizationRequestDto?> UpdateRequestAsync(int id, PriorAuthorizationRequest updatedRequest)
    {
        var existing = await _context.PriorAuthorizationRequests.FindAsync(id);
        if (existing == null) return null;

        //real-world case (must appeal)
        if (existing.Status == "Denied")
        {
            return null; 
        }

        
        existing.PatientName = updatedRequest.PatientName;
        existing.ProviderName = updatedRequest.ProviderName;
        existing.RequestDate = updatedRequest.RequestDate;
        existing.ProcedureCode = updatedRequest.ProcedureCode;
        existing.IsUrgent = updatedRequest.IsUrgent;
        existing.Status = updatedRequest.Status;

        await _context.SaveChangesAsync();

        return new PriorAuthorizationRequestDto
        {
            Id = existing.Id,
            PatientName = existing.PatientName,
            ProcedureCode = existing.ProcedureCode,
            IsUrgent = existing.IsUrgent,
            Status = existing.Status
        };
    }

    // DELETE
    public async Task<bool> DeleteRequestAsync(int id)
    {
        var request = await _context.PriorAuthorizationRequests.FindAsync(id);
        if (request == null) return false;

        _context.PriorAuthorizationRequests.Remove(request);
        await _context.SaveChangesAsync();
        return true;
    }
}
