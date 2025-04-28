namespace PriorAuthPrototype.Dtos
{
    public class PriorAuthorizationRequestDto
    {
        public int Id { get; set; } 
        public string PatientName { get; set; }
        public string ProcedureCode { get; set; }
        public bool IsUrgent { get; set; }
        public string Status { get; set; }
    }
}
