using Models.DatabaseModels.VehicleRegistration.Setup;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DatabaseModels.SeriesNumberPool
{
    public class SeriesNumberSelection : GeneralBaseModel
    {
        [ForeignKey("OwnerType")]
        public long OwnerTypeId { get; set; }
        public virtual OwnerType OwnerType { get; set; }

        [ForeignKey("OwnerTaxGroup")]
        public long OwnerTaxGroupId { get; set; }
        public virtual OwnerTaxGroup OwnerTaxGroup { get; set; }

        [ForeignKey("VehicleClass")]
        public long VehicleClassId { get; set; }
        public virtual VehicleClass VehicleClass { get; set; }

        [ForeignKey("SeriesCategory")]
        public long SeriesCategoryId { get; set; }
        public virtual SeriesCategory SeriesCategory { get; set; }
    }
}
