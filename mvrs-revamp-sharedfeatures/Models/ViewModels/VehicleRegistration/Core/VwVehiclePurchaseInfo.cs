using System;
using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels.VehicleRegistration.Core
{
    public class VwVehiclePurchaseInfo
    {
        [Required]
        public long? ApplicationId { get; set; }

        [Required]
        public long? VehicleId { get; set; }

        [Required]
        public long? VehiclePurchaseTypeId { get; set; }

        public VwVehicleLocalPurchaseInfo LocalPurchaseInfo { get; set; }
        public VwVehicleImportInfo ImportInfo { get; set; }
        public VwVehicleAuctionInfo AuctionInfo { get; set; }
    }
}
