using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels.Payment
{
    public class VwPayeeInfo
    {
        public long ApplicationId { get; set; }
        public long ChallanId { get; set; }
        public long TotalAmount { get; set; }
        public string PayeeName { get; set; }
        public string NTN { get; set; }

        [StringLength(50)]
        public string PSId { get; set; }
    }
}
