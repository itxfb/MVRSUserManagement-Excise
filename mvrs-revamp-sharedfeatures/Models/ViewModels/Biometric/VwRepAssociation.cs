using Models.ViewModels.VehicleRegistration.Core;
using System.Collections.Generic;

namespace Models.ViewModels.Biometric
{
    //public class VwRepAssociation
    //{
    //    public long VehicleId { get; set; }
    //    public string NTN { get; set; }
    //    public string RegistrationNo { get; set; }
    //    public string CNIC { get; set; }
    //    public string PersonName { get; set; }
    //    public string FatherHusbandName { get; set; }
    //}
    //public class VwRepAssociation
    //{
    //    public VwVehicle Vehicle { get; set; }
    //    public VwBusiness Business { get; set; }
    //    public List<VwBusinessRep> BusinessRep { get; set; }
    //}
    public class VwRepAssociation
    {
        public long ApplicationId { get; set; }
        public long VehicleId { get; set; }
        public long OwnerGroupId { get; set; }
        public long BusinessId { get; set; }
        public long? PersonId { get; set; }
        public string Title { get; set; }
        public string Designation { get; set; }
        public string NTN { get; set; }
        public string RegistrationNo { get; set; }
        public string ChasisNo { get; set; }
        public string VehicleMake { get; set; }
        public string VehicleMaker { get; set; }
        public VwPerson Person { get; set; }
    }
}
