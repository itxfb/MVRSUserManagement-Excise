using System.ComponentModel.DataAnnotations;

namespace UserManagement.ViewModels.udt
{
    public class Address : BaseModel
    {
        public long AddressId { get; set; }

        [StringLength(500)]
        public string AddressDescription { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(50)]
        public string AreaName { get; set; }

        [StringLength(50)]
        public string PropertyNo { get; set; }

        [StringLength(50)]
        public string Street { get; set; }

        public long DistrictId { get; set; }
        public long? TehsilId { get; set; }

        public long? AddressAreaId { get; set; }

        public long? PostOfficeId { get; set; }

        public long AddressTypeId { get; set; }

        public long? PersonId { get; set; }

        public long? BusinessId { get; set; }
    }
}
