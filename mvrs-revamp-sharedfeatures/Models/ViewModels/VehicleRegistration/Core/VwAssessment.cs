namespace Models.ViewModels.VehicleRegistration.Core
{
    public class VwAssessment
    {
        public long AssessmentBaseId { get; set; }
        public long TaxTypeId { get; set; }
        public string TaxType { get; set; }
        public decimal PayableAmount { get; set; }
    }
}