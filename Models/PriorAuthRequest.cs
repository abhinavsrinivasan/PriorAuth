namespace PriorAuthPrototype.Models
{
    //Model - Data Structure for application
    public class PriorAuthorizationRequest
    {
        public int Id { get; set; }
        public string PatientName { get; set; }
        public string ProviderName { get; set; }
        public DateTime RequestDate { get; set; }
        public string ProcedureCode { get; set; } 
        public string Status { get; set; }
        public bool IsUrgent { get; set; }
    }
}
