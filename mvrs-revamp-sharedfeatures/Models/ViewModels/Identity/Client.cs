using Models.DatabaseModels.Authentication;
using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels.Identity
{
    public class VwClient
    {
        [Required]
        public string ClientId { get; set; }

        [Required]
        public string ClientSecret { get; set; }
    }
}
