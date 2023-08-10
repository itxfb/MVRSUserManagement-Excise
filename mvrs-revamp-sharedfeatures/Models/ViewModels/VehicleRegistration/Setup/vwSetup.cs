using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels.VehicleRegistration.Setup
{
    public class vwSetup
    {
        public long Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(20)]
        public string? Abbreviation { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; }

        [Required]
        public long CreatedBy { get; set; }
    }
}
