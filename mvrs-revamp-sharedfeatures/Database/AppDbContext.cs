using Microsoft.EntityFrameworkCore;
using Models.DatabaseModels;
using Models.DatabaseModels.Authentication;
using Models.DatabaseModels.Biometric;
using Models.DatabaseModels.Logging;
using Models.DatabaseModels.SeriesNumberPool;
using Models.DatabaseModels.VehicleRegistration.Core;
using Models.DatabaseModels.VehicleRegistration.Setup;
using System.Linq;

namespace Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Profiling

            //modelBuilder.Entity<MicroService>().ToTable("MicroService", "Profiling");
            modelBuilder.Entity<Address>().ToTable("Address", "Core");
            modelBuilder.Entity<AddressLog>().ToTable("AddressLog", "Core");
            modelBuilder.Entity<PhoneNumber>().ToTable("PhoneNumber", "Core");
            modelBuilder.Entity<PhoneNumberLog>().ToTable("PhoneNumberLog", "Core");
            modelBuilder.Entity<Person>().ToTable("Person", "Core");
            modelBuilder.Entity<PersonLog>().ToTable("PersonLog", "Core");
            modelBuilder.Entity<Business>().ToTable("Business", "Core");
            modelBuilder.Entity<BusinessLog>().ToTable("BusinessLog", "Core");

            #endregion

            #region Authentication

            modelBuilder.Entity<User>().HasIndex(x => new { x.UserName }).IsUnique();
            modelBuilder.Entity<UserRole>().HasIndex(x => new { x.UserId, x.RoleId }).IsUnique();
            modelBuilder.Entity<RoleResource>().HasIndex(x => new { x.RoleId, x.ResourceId }).IsUnique();
            modelBuilder.Entity<RoleResourceRight>().HasIndex(x => new { x.RoleResourceId, x.RTRightId }).IsUnique();
            modelBuilder.Entity<RoleAppProcessFlow>().HasIndex(x => new { x.RoleId, x.AppProcessFlowId }).IsUnique();

            modelBuilder.Entity<GlobalRight>().ToTable("GlobalRight", "Auth");
            modelBuilder.Entity<Resource>().ToTable("Resource", "Auth");
            modelBuilder.Entity<ResourceAction>().ToTable("ResourceAction", "Auth");
            modelBuilder.Entity<ResourceController>().ToTable("ResourceController", "Auth");
            modelBuilder.Entity<ResourceType>().ToTable("ResourceType", "Auth");
            modelBuilder.Entity<ResourceTypeDefaultRight>().ToTable("ResourceTypeDefaultRight", "Auth");
            modelBuilder.Entity<ResourceTypeRight>().ToTable("ResourceTypeRight", "Auth");
            modelBuilder.Entity<Role>().ToTable("Role", "Auth");
            modelBuilder.Entity<RoleAppProcessFlow>().ToTable("RoleAppProcessFlow", "Auth");
            modelBuilder.Entity<RoleResource>().ToTable("RoleResource", "Auth");
            modelBuilder.Entity<RoleResourceRight>().ToTable("RoleResourceRight", "Auth");
            modelBuilder.Entity<RoleResourceRightsHistory>().ToTable("RoleResourceRightsHistory", "Auth");
            modelBuilder.Entity<User>().ToTable("User", "Auth");
            modelBuilder.Entity<UserRole>().ToTable("UserRole", "Auth");
            modelBuilder.Entity<UserRoleHistory>().ToTable("UserRoleHistory", "Auth");
            modelBuilder.Entity<UserStatus>().ToTable("UserStatus", "Auth");
            modelBuilder.Entity<UserType>().ToTable("UserType", "Auth");
            modelBuilder.Entity<WhitelistedClient>().ToTable("WhitelistedClient", "Auth");
            modelBuilder.Entity<WhitelistedClientLog>().ToTable("WhitelistedClientLog", "Auth");

            #endregion

            #region Logs

            modelBuilder.Entity<HttpRequestLog>().ToTable("HttpRequestLog", "Logs");
            modelBuilder.Entity<SqlExceptionLog>().ToTable("SqlExceptionLog", "Logs");
            //modelBuilder.Entity<Log>().ToTable("Logs", "Logs");
            //modelBuilder.Entity<RequestLog>().ToTable("RequestLog", "Logs");

            #endregion

            #region Setup

            modelBuilder.Entity<ApplicationProcessFlow>().HasIndex(x => new
            {
                x.CurrentApplicationStatusId,
                x.CurrentBusinessPhaseId,
                x.CurrentBusinessPhaseStatusId,
                x.BusinessProcessId,
                x.RoleId,
                x.BusinessEventId,
                x.NextApplicationStatusId,
                x.NextBusinessPhaseId,
                x.NextBusinessPhaseStatusId
            }).IsUnique();

            modelBuilder.Entity<BusinessTableAccessLevel>().HasIndex(x => new
            {
                x.ApplicationStatusId,
                x.BusinessPhaseId,
                x.BusinessPhaseStatusId,
                x.BusinessProcessId,
                x.BusinessTableId,
                x.RoleId,
                x.BusinessTableAccessId
            }).IsUnique();


            modelBuilder.Entity<AccountHead>().ToTable("AccountHead", "Setup");
            modelBuilder.Entity<ApplicationProcessFlow>().ToTable("ApplicationProcessFlow", "Setup");
            modelBuilder.Entity<BusinessEvent>().ToTable("BusinessEvent", "Setup");
            modelBuilder.Entity<BusinessPhase>().ToTable("BusinessPhase", "Setup");
            modelBuilder.Entity<BusinessPhaseStatus>().ToTable("BusinessPhaseStatus", "Setup");
            modelBuilder.Entity<BusinessProcess>().ToTable("BusinessProcess", "Setup");
            modelBuilder.Entity<BusinessTable>().ToTable("BusinessTable", "Setup");
            modelBuilder.Entity<BusinessTableAccessLevel>().ToTable("BusinessTableAccessLevel", "Setup");
            modelBuilder.Entity<BusinessTableAccess>().ToTable("BusinessTableAccess", "Setup");
            modelBuilder.Entity<Country>().ToTable("Country", "Setup");
            modelBuilder.Entity<District>().ToTable("District", "Setup");
            modelBuilder.Entity<Tehsil>().ToTable("Tehsil", "Setup");
            modelBuilder.Entity<OrganizationCategory>().ToTable("OrganizationCategory", "Setup");
            modelBuilder.Entity<OwnerStatus>().ToTable("OwnerStatus", "Setup");
            modelBuilder.Entity<OwnerTaxGroup>().ToTable("OwnerTaxGroup", "Setup");
            modelBuilder.Entity<OwnerTaxGroupFees>().ToTable("OwnerTaxGroupFees", "Setup");
            modelBuilder.Entity<OwnerType>().ToTable("OwnerType", "Setup");
            modelBuilder.Entity<VehicleBodyConvention>().ToTable("VehicleBodyConvention", "Setup");
            modelBuilder.Entity<VehicleBodyType>().ToTable("VehicleBodyType", "Setup");
            modelBuilder.Entity<VehicleCategory>().ToTable("VehicleCategory", "Setup");
            modelBuilder.Entity<VehicleClass>().ToTable("VehicleClass", "Setup");
            modelBuilder.Entity<VehicleClassDetail>().ToTable("VehicleClassDetail", "Setup");
            modelBuilder.Entity<VehicleClassGroup>().ToTable("VehicleClassGroup", "Setup");
            modelBuilder.Entity<VehicleClassification>().ToTable("VehicleClassification", "Setup");
            modelBuilder.Entity<VehicleColor>().ToTable("VehicleColor", "Setup");
            modelBuilder.Entity<VehicleDocumentRequirement>().ToTable("VehicleDocumentRequirement", "Setup");
            modelBuilder.Entity<VehicleDocumentType>().ToTable("VehicleDocumentType", "Setup");
            modelBuilder.Entity<VehicleEngineType>().ToTable("VehicleEngineType", "Setup");
            modelBuilder.Entity<VehicleFuelType>().ToTable("VehicleFuelType", "Setup");
            modelBuilder.Entity<VehicleMake>().ToTable("VehicleMake", "Setup");
            modelBuilder.Entity<VehicleMaker>().ToTable("VehicleMaker", "Setup");
            modelBuilder.Entity<VehiclePurchaseType>().ToTable("VehiclePurchaseType", "Setup");
            modelBuilder.Entity<VehicleRouteType>().ToTable("VehicleRouteType", "Setup");
            modelBuilder.Entity<VehicleRCStatus>().ToTable("VehicleRCStatus", "Setup");
            modelBuilder.Entity<VehicleStatus>().ToTable("VehicleStatus", "Setup");
            modelBuilder.Entity<VehicleType>().ToTable("VehicleType", "Setup");
            modelBuilder.Entity<VehicleUsage>().ToTable("VehicleUsage", "Setup");
            modelBuilder.Entity<VehicleArticle>().ToTable("VehicleArticle", "Setup");
            modelBuilder.Entity<HPAStatus>().ToTable("HPAStatus", "Setup");

            modelBuilder.Entity<AddressType>().ToTable("AddressType", "Setup");
            modelBuilder.Entity<ApplicationStatus>().ToTable("ApplicationStatus", "Setup");
            //modelBuilder.Entity<ApplicationType>().ToTable("ApplicationType", "Setup");
            //modelBuilder.Entity<ApplicationPhase>().ToTable("ApplicationPhase", "Setup");
            modelBuilder.Entity<PhoneNumberType>().ToTable("PhoneNumberType", "Setup");

            modelBuilder.Entity<Bank>().ToTable("Bank", "Setup");
            modelBuilder.Entity<ClearingAgent>().ToTable("ClearingAgent", "Setup");
            modelBuilder.Entity<CustomCollectorate>().ToTable("CustomCollectorate", "Setup");
            modelBuilder.Entity<Port>().ToTable("Port", "Setup");
            modelBuilder.Entity<VehicleScheme>().ToTable("VehicleScheme", "Setup");

            modelBuilder.Entity<TaxBase>().ToTable("TaxBase", "Setup");
            modelBuilder.Entity<BusinessProFeeTax>().ToTable("BusinessProFeeTax", "Setup");
            modelBuilder.Entity<TaxRate>().ToTable("TaxRate", "Setup");
            modelBuilder.Entity<TaxRate>().Property(x => x.TaxValue).HasPrecision(18, 3);
            modelBuilder.Entity<TaxRule>().ToTable("TaxRule", "Setup");
            modelBuilder.Entity<TaxType>().ToTable("TaxType", "Setup");
            modelBuilder.Entity<RegFeePenaltyRate>().ToTable("RegFeePenaltyRate", "Setup");

            modelBuilder.Entity<AssessmentStatus>().ToTable("AssessmentStatus", "Setup");
            modelBuilder.Entity<ChallanStatus>().ToTable("ChallanStatus", "Setup");
            modelBuilder.Entity<ChallanType>().ToTable("ChallanType", "Setup");
            modelBuilder.Entity<PaymentMode>().ToTable("PaymentMode", "Setup");
            modelBuilder.Entity<PaymentStatus>().ToTable("PaymentStatus", "Setup");

            modelBuilder.Entity<BusinessRepStatus>().ToTable("BusinessRepStatus", "Setup");
            modelBuilder.Entity<BusinessSector>().ToTable("BusinessSector", "Setup");
            modelBuilder.Entity<BusinessStatus>().ToTable("BusinessStatus", "Setup");
            modelBuilder.Entity<BusinessType>().ToTable("BusinessType", "Setup");

            #endregion

            #region Core

            //modelBuilder.Entity<Application>().HasIndex(x => new { x.ApplicationPhaseId, x.ApplicationStatusId, x.ApplicationTypeId }).IsUnique();
            modelBuilder.Entity<OwnerGroup>().HasIndex(x => new { x.OwnerId, x.PersonId }).IsUnique();
            modelBuilder.Entity<OwnerGroup>().HasIndex(x => new { x.OwnerId, x.BusinessId }).IsUnique();
            modelBuilder.Entity<Person>().HasIndex(x => new { x.CNIC }).IsUnique();
            modelBuilder.Entity<Business>().HasIndex(x => new { x.NTN }).IsUnique();
            modelBuilder.Entity<Address>().HasIndex(x => new { x.AddressTypeId, x.PersonId }).IsUnique();
            modelBuilder.Entity<Address>().HasIndex(x => new { x.AddressTypeId, x.BusinessId }).IsUnique();
            modelBuilder.Entity<PhoneNumber>().HasIndex(x => new { x.PhoneNumberTypeId, x.PersonId }).IsUnique();
            modelBuilder.Entity<PhoneNumber>().HasIndex(x => new { x.PhoneNumberTypeId, x.BusinessId }).IsUnique();
            modelBuilder.Entity<Vehicle>().HasIndex(x => new { x.VehicleMakeId, x.VehicleMakerId, x.ChasisNo }).IsUnique();
            modelBuilder.Entity<Vehicle>().HasIndex(x => new { x.ChasisNo, x.RegistrationNo }).IsUnique();
            modelBuilder.Entity<VehicleAuctionInfo>().HasIndex(x => new { x.ApplicationId, x.VehicleAuctionInfoId }).IsUnique();
            modelBuilder.Entity<VehicleImportInfo>().HasIndex(x => new { x.ApplicationId, x.VehicleImportInfoId }).IsUnique();
            modelBuilder.Entity<VehiclePurchaseInfo>().HasIndex(x => new { x.ApplicationId, x.VehiclePurchaseInfoId }).IsUnique();

            modelBuilder.Entity<Application>().ToTable("Application", "Core");
            modelBuilder.Entity<ApplicationLog>().ToTable("ApplicationLog", "Core");
            modelBuilder.Entity<Owner>().ToTable("Owner", "Core");
            modelBuilder.Entity<OwnerLog>().ToTable("OwnerLog", "Core");
            modelBuilder.Entity<OwnerGroup>().ToTable("OwnerGroup", "Core");
            modelBuilder.Entity<Vehicle>().ToTable("Vehicle", "Core");
            modelBuilder.Entity<VehicleLog>().ToTable("VehicleLog", "Core");
            modelBuilder.Entity<VehicleAdditionalInfo>().ToTable("VehicleAdditionalInfo", "Core");
            modelBuilder.Entity<VehicleAdditionalInfoLog>().ToTable("VehicleAdditionalInfoLog", "Core");
            modelBuilder.Entity<VehicleOwnershipHistory>().ToTable("VehicleOwnershipHistory", "Core");
            modelBuilder.Entity<Dealer>().ToTable("Dealer", "Core");
            modelBuilder.Entity<Remarks>().ToTable("Remarks", "Core");
            modelBuilder.Entity<VehicleDocument>().ToTable("VehicleDocument", "Core");
            modelBuilder.Entity<VehiclePurchaseInfo>().ToTable("VehiclePurchaseInfo", "Core");
            modelBuilder.Entity<VehiclePurchaseInfoLog>().ToTable("VehiclePurchaseInfoLog", "Core");
            modelBuilder.Entity<VehicleImportInfo>().ToTable("VehicleImportInfo", "Core");
            modelBuilder.Entity<VehicleImportInfoLog>().ToTable("VehicleImportInfoLog", "Core");
            modelBuilder.Entity<VehicleAuctionInfo>().ToTable("VehicleAuctionInfo", "Core");
            modelBuilder.Entity<VehicleAuctionInfoLog>().ToTable("VehicleAuctionInfoLog", "Core");
            modelBuilder.Entity<VehicleBusinessProcessHistory>().ToTable("VehicleBusinessProcessHistory", "Core");
            modelBuilder.Entity<VehicleRegistrationHistory>().ToTable("VehicleRegistrationHistory", "Core");
            modelBuilder.Entity<VehicleFileUpload>().ToTable("VehicleFileUpload", "Core");
            modelBuilder.Entity<VehicleArticleDelivery>().ToTable("VehicleArticleDelivery", "Core");
            modelBuilder.Entity<BusinessRep>().ToTable("BusinessRep", "Core");
            modelBuilder.Entity<Models.DatabaseModels.VehicleRegistration.Core.HPA>().ToTable("HPA", "Core");
            modelBuilder.Entity<HPALog>().ToTable("HPALog", "Core");
            modelBuilder.Entity<HPAStatusHistory>().ToTable("HPAStatusHistory", "Core");
            modelBuilder.Entity<Keeper>().ToTable("Keeper", "Core");
            modelBuilder.Entity<KeeperLog>().ToTable("KeeperLog", "Core");

            modelBuilder.Entity<AssessmentBase>().ToTable("AssessmentBase", "Core");
            modelBuilder.Entity<AssessmentDetail>().ToTable("AssessmentDetail", "Core");
            modelBuilder.Entity<AssessmentDetail>().Property(x => x.PayableAmount).HasPrecision(18, 3);
            modelBuilder.Entity<Challan>().ToTable("Challan", "Payments");
            modelBuilder.Entity<PaymentInfo>().ToTable("PaymentInfo", "Payments");


            #endregion

            #region e-Pay

            modelBuilder.Entity<Models.DatabaseModels.epay.Address>().HasIndex(x => new { x.AddressTypeId, x.PersonId }).IsUnique();
            modelBuilder.Entity<Models.DatabaseModels.epay.Address>().HasIndex(x => new { x.AddressTypeId, x.BusinessId }).IsUnique();
            modelBuilder.Entity<Models.DatabaseModels.epay.PhoneNumber>().HasIndex(x => new { x.PhoneNumberTypeId, x.PersonId }).IsUnique();
            modelBuilder.Entity<Models.DatabaseModels.epay.PhoneNumber>().HasIndex(x => new { x.PhoneNumberTypeId, x.BusinessId }).IsUnique();

            modelBuilder.Entity<Models.DatabaseModels.epay.Address>().ToTable("Address", "epay");
            modelBuilder.Entity<Models.DatabaseModels.epay.Application>().ToTable("Application", "epay");
            modelBuilder.Entity<Models.DatabaseModels.epay.Business>().ToTable("Business", "epay");
            modelBuilder.Entity<Models.DatabaseModels.epay.Owner>().ToTable("Owner", "epay");
            modelBuilder.Entity<Models.DatabaseModels.epay.Person>().ToTable("Person", "epay");
            modelBuilder.Entity<Models.DatabaseModels.epay.PhoneNumber>().ToTable("PhoneNumber", "epay");
            modelBuilder.Entity<Models.DatabaseModels.epay.Vehicle>().ToTable("Vehicle", "epay");
            modelBuilder.Entity<Models.DatabaseModels.epay.AssessmentBase>().ToTable("AssessmentBase", "epay");
            modelBuilder.Entity<Models.DatabaseModels.epay.HPA>().ToTable("HPA", "epay");
            modelBuilder.Entity<Models.DatabaseModels.epay.AssessmentDetail>().ToTable("AssessmentDetail", "epay");
            modelBuilder.Entity<Models.DatabaseModels.epay.VehicleAdditionalInfo>().ToTable("VehicleAdditionalInfo", "epay");
            modelBuilder.Entity<Models.DatabaseModels.epay.OwnerGroup>().ToTable("OwnerGroup", "epay");




            #endregion

            #region Series-Number-Pool

            modelBuilder.Entity<Series>().HasIndex(x => new { x.SeriesCategoryId, x.SeriesName }).IsUnique();
            modelBuilder.Entity<SeriesAssignment>().HasIndex(x => new { x.SeriesId, x.SeriesConsumerId }).IsUnique();
            modelBuilder.Entity<SeriesNumber>().HasIndex(x => new { x.SeriesNumberName }).IsUnique();
            modelBuilder.Entity<SeriesNumberDetail>().HasIndex(x => new { x.SeriesCategoryId, x.SeriesNumberId }).IsUnique();
            modelBuilder.Entity<SeriesNumberPool>().HasIndex(x => new { x.SeriesCategoryId, x.SeriesId, x.SeriesNumberId }).IsUnique();
            modelBuilder.Entity<AuctionResult>().HasIndex(x => new { x.SeriesCategoryId, x.SeriesId, x.SeriesNumberId }).IsUnique();
            modelBuilder.Entity<AuctionResult>().HasIndex(x => new { x.WinnerAIN }).IsUnique();

            modelBuilder.Entity<Series>().ToTable("Series", "SRNRPL");
            modelBuilder.Entity<SeriesAssignment>().ToTable("SeriesAssignment", "SRNRPL");
            modelBuilder.Entity<SeriesCategory>().ToTable("SeriesCategory", "SRNRPL");
            modelBuilder.Entity<SeriesNumber>().ToTable("SeriesNumber", "SRNRPL");
            modelBuilder.Entity<SeriesNumberDetail>().ToTable("SeriesNumberDetail", "SRNRPL");
            modelBuilder.Entity<SeriesNumberSelection>().ToTable("SeriesNumberSelection", "SRNRPL");
            modelBuilder.Entity<SeriesNumberStatus>().ToTable("SeriesNumberStatus", "SRNRPL");
            modelBuilder.Entity<SeriesNumberPool>().ToTable("SeriesNumberPool", "SRNRPL");
            modelBuilder.Entity<SeriesStatus>().ToTable("SeriesStatus", "SRNRPL");
            modelBuilder.Entity<SeriesType>().ToTable("SeriesType", "SRNRPL");
            modelBuilder.Entity<AuctionResult>().ToTable("AuctionResult", "SRNRPL");
            modelBuilder.Entity<AuctionSchedule>().ToTable("AuctionSchedule", "SRNRPL");
            modelBuilder.Entity<AuctionStatus>().ToTable("AuctionStatus", "SRNRPL");
            modelBuilder.Entity<Series>().ToTable("Series", "SRNRPL");

            #endregion

            #region Biometric

            modelBuilder.Entity<BiometricVerification>().HasIndex(x => new { x.ApplicationId, x.PersonId, x.VehicleId }).IsUnique();

            modelBuilder.Entity<NadraFranchise>().ToTable("NadraFranchise", "Biometric");
            modelBuilder.Entity<BiometricVerification>().ToTable("BiometricVerification", "Biometric");

            #endregion


            #region General

            var entityTypes = modelBuilder.Model.GetEntityTypes();

            foreach (var relationship in entityTypes.SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.NoAction;
            }

            foreach (var entity in entityTypes)
            {
                entity.FindProperty("CreatedAt")?.SetDefaultValueSql("GETDATE()");
                entity.FindProperty("IsDeleted")?.SetDefaultValueSql("0");
            }

            #endregion
        }

        #region Profiling

        public DbSet<Address> Address { get; set; }
        public DbSet<PhoneNumber> PhoneNumber { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<Business> Business { get; set; }

        #endregion

        #region Authentication

        public DbSet<GlobalRight> GlobalRight { get; set; }
        public DbSet<Resource> Resource { get; set; }
        public DbSet<ResourceAction> ResourceAction { get; set; }
        public DbSet<ResourceController> ResourceController { get; set; }
        public DbSet<ResourceType> ResourceType { get; set; }
        public DbSet<ResourceTypeDefaultRight> ResourceTypeDefaultRight { get; set; }
        public DbSet<ResourceTypeRight> ResourceTypeRight { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<RoleAppProcessFlow> RoleAppProcessFlow { get; set; }
        public DbSet<RoleResource> RoleResource { get; set; }
        public DbSet<RoleResourceRight> RoleResourceRight { get; set; }
        public DbSet<RoleResourceRightsHistory> RoleResourceRightsHistory { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<UserRoleHistory> UserRoleHistory { get; set; }
        public DbSet<UserStatus> UserStatus { get; set; }
        public DbSet<UserType> UserType { get; set; }

        #endregion

        #region Logs

        public DbSet<HttpRequestLog> HttpRequestLog { get; set; }
        public DbSet<SqlExceptionLog> SqlExceptionLog { get; set; }
        //public DbSet<RequestLog> RequestLogs { get; set; }
        //public DbSet<Log> Logs { get; set; }

        #endregion

        #region Setup

        public DbSet<ApplicationProcessFlow> ApplicationProcessFlow { get; set; }
        public DbSet<AccountHead> AccountHead { get; set; }
        public DbSet<BusinessEvent> BusinessEvent { get; set; }
        public DbSet<BusinessPhase> BusinessPhase { get; set; }
        public DbSet<BusinessPhaseStatus> BusinessPhaseStatus { get; set; }
        public DbSet<BusinessProcess> BusinessProcess { get; set; }
        public DbSet<BusinessTable> BusinessTable { get; set; }
        public DbSet<BusinessTableAccessLevel> BusinessTableAccessLevel { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<District> District { get; set; }
        public DbSet<OrganizationCategory> OrganizationCategory { get; set; }
        public DbSet<OwnerStatus> OwnerStatus { get; set; }
        public DbSet<OwnerTaxGroup> OwnerTaxGroup { get; set; }
        public DbSet<OwnerTaxGroupFees> OwnerTaxGroupFees { get; set; }
        public DbSet<OwnerType> OwnerType { get; set; }
        public DbSet<VehicleBodyConvention> VehicleBodyConvention { get; set; }
        public DbSet<VehicleBodyType> VehicleBodyType { get; set; }
        public DbSet<VehicleCategory> VehicleCategory { get; set; }
        public DbSet<VehicleClass> VehicleClass { get; set; }
        public DbSet<VehicleClassDetail> VehicleClassDetail { get; set; }
        public DbSet<VehicleClassification> VehicleClassification { get; set; }
        public DbSet<VehicleColor> VehicleColor { get; set; }
        public DbSet<VehicleDocumentType> VehicleDocumentType { get; set; }
        public DbSet<VehicleDocumentRequirement> VehicleDocumentRequirement { get; set; }
        public DbSet<VehicleEngineType> VehicleEngineType { get; set; }
        public DbSet<VehicleFuelType> VehicleFuelType { get; set; }
        public DbSet<VehicleMake> VehicleMake { get; set; }
        public DbSet<VehicleMaker> VehicleMaker { get; set; }
        public DbSet<VehiclePurchaseType> VehiclePurchaseType { get; set; }
        public DbSet<VehicleRouteType> VehicleRouteType { get; set; }
        public DbSet<VehicleRCStatus> VehicleRCStatus { get; set; }
        public DbSet<VehicleStatus> VehicleStatus { get; set; }
        public DbSet<VehicleType> VehicleType { get; set; }
        public DbSet<VehicleUsage> VehicleUsage { get; set; }
        public DbSet<VehicleScheme> VehicleScheme { get; set; }

        public DbSet<Bank> Bank { get; set; }
        public DbSet<ClearingAgent> ClearingAgent { get; set; }
        public DbSet<CustomCollectorate> CustomCollectorate { get; set; }
        public DbSet<Port> Port { get; set; }

        public DbSet<BusinessRepStatus> BusinessRepStatus { get; set; }
        public DbSet<BusinessSector> BusinessSector { get; set; }
        public DbSet<BusinessStatus> BusinessStatus { get; set; }
        public DbSet<BusinessType> BusinessType { get; set; }


        public DbSet<TaxBase> TaxBase { get; set; }
        public DbSet<BusinessProFeeTax> BusinessProFeeTax { get; set; }
        public DbSet<TaxRate> TaxRate { get; set; }
        public DbSet<TaxRule> TaxRule { get; set; }
        public DbSet<TaxType> TaxType { get; set; }
        public DbSet<RegFeePenaltyRate> RegFeePenaltyRate { get; set; }

        public DbSet<AssessmentStatus> AssessmentStatus { get; set; }
        public DbSet<ChallanStatus> ChallanStatus { get; set; }
        public DbSet<ChallanType> ChallanType { get; set; }
        public DbSet<PaymentMode> PaymentMode { get; set; }
        public DbSet<PaymentStatus> PaymentStatus { get; set; }

        #endregion

        #region Core

        public DbSet<Application> Application { get; set; }
        public DbSet<Owner> Owner { get; set; }
        public DbSet<OwnerGroup> OwnerGroup { get; set; }
        public DbSet<Dealer> Dealer { get; set; }
        public DbSet<Remarks> Remarks { get; set; }
        public DbSet<Vehicle> Vehicle { get; set; }
        public DbSet<VehicleOwnershipHistory> VehicleOwnershipHistory { get; set; }
        public DbSet<VehicleAdditionalInfo> VehicleAdditionalInfo { get; set; }
        public DbSet<VehicleDocument> VehicleDocument { get; set; }
        public DbSet<VehiclePurchaseInfo> VehiclePurchaseInfo { get; set; }
        public DbSet<VehicleImportInfo> VehicleImportInfo { get; set; }
        public DbSet<VehicleAuctionInfo> VehicleAuctionInfo { get; set; }
        public DbSet<VehicleBusinessProcessHistory> VehicleBusinessProcessHistory { get; set; }
        public DbSet<VehicleRegistrationHistory> VehicleRegistrationHistory { get; set; }
        public DbSet<BusinessRep> BusinessRep { get; set; }
        public DbSet<Models.DatabaseModels.VehicleRegistration.Core.HPA> HPA { get; set; }
        public DbSet<HPAStatusHistory> HPAStatusHistory { get; set; }
        public DbSet<Keeper> Keeper { get; set; }

        public DbSet<AssessmentBase> AssessmentBase { get; set; }
        public DbSet<AssessmentDetail> AssessmentDetail { get; set; }
        public DbSet<Challan> Challan { get; set; }
        public DbSet<PaymentInfo> Payment { get; set; }

        #endregion

        //#region Series-Number-Pool

        //public DbSet<Series> Series { get; set; }
        //public DbSet<SeriesCategory> SeriesCategory { get; set; }
        //public DbSet<SeriesNumber> SeriesNumber { get; set; }
        //public DbSet<SeriesNumberPool> SeriesNumberPool { get; set; }
        //public DbSet<SeriesStatus> SeriesStatus { get; set; }
        //public DbSet<SeriesType> SeriesType { get; set; }
        public DbSet<AuctionResult> AuctionResult { get; set; }

        //#endregion

        #region Biometric

        public DbSet<NadraFranchise> NadraFranchise { get; set; }
        public DbSet<BiometricVerification> BiometricVerification { get; set; }

        #endregion
    }
}
