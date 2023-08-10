using Database;
using Models.DatabaseModels.Authentication;
using Models.ViewModels.Identity;
using SharedLib.Common;
using SharedLib.Interfaces;
using System.Data;
using UserManagement.Services.Notification;
using UserManagement.ViewModels;
using UserManagement.ViewModels.udt;



namespace UserManagement.Services
{
    public interface IUserManagementService : ICurrentUser
    {
        Task<DataSet> GetDropDownsCreateUser();

        Task<DataSet> GetSiteOfficesList();
        Task<DataSet> GetWorkingRoleTimingsDropDown(long? RoleId);
        Task<DataSet> GetUserList(int offset, int pageSize, string searchVal);
        Task<DataSet> GetPersonByCNIC(string cnic);
        Task<DataSet> GetUserByUserId(long userId);
        Task<DataSet> GetAssignedSeriesCategories(long userId, long RoleId);
        Task<DataSet> GetUserPermission(long userId, long RoleId);
        Task<DataSet> UpdateUserRole(VwUserRole userObj);
        Task<DataSet> SaveUserPermission(VwUserPermissions PermisionObj);
        Task<DataSet> CancellUserPermission(long UserId, long PermissionId);
        Task<DataSet> GetLineManager(long DistrictId = 0, long OfficeId = 0, long userRoleId = 0);
        Task<DataSet> SaveAssignedSeriesCategories(VwUserSeriesCategory obj);
        Task<DataSet> CreateUser(VwCreateUser userObj);

        Task<DataSet> ValidateNTN(string NTN);

        Task<DataSet> ValidateEmail(string email);
        Task<DataSet> ValidateIP(string IPAddress);

        Task<DataSet> ValidatePhone(string phone);

        Task<DataSet> GetWorkingDayOffTypeDropdown();

        Task<bool> SendEmailAndSMSNotification(string email, string phone,string text);

        Task<bool> SaveWorkingRoleTimings(long RoleId, string DayStartTime, string DayCloseTime, string WeekDayId, string userId, long InsOrUpd = -1);

        Task<DataSet> InsertOrUpdateWorkingOffDay(long districtId, long? roleId, long? OfficeId, string workingOffDate, string offDayTypeId, string userId);
        Task<bool> SaveRoute(long userId,long routeId, long createdBy);
        Task<bool> SaveRoleRoute(long roleId, long routeId, long createdBy);

        Task<DataSet> AssignUserApplications(string appIds, long userId);
        Task<DataSet> DeleteRoute(long userRouteId);
        Task<DataSet> DeleteRoleRoute(long roleRouteId);

        Task<DataSet> GetWorkingOffDayList();

        Task<DataSet> DeleteWorkingOffDay(long Id);

        Task<DataSet> GetRoutesList();

        Task<DataSet> GetUserRoutesList(long userId);

        Task<DataSet> GetRoleRoutesList(long roleId);

        Task<DataSet> GetRolesHistory(long userId);

        Task<DataSet> GetRolesList();
        Task<DataSet> GetDistrictList();
        Task<DataSet> GetUserApplicationsDropDown(long userId);

        Task<DataSet> GetUsersListByRoleId(long roleId);

    }

    public class UserManagementService : IUserManagementService
    {
        readonly IDBHelper dbHelper;
        public VwUser VwUser { get; set; }
        public UserManagementService(IDBHelper dbHelper)
        {
            this.dbHelper = dbHelper;
        }

        public async Task<DataSet> GetDropDownsCreateUser()
        {
            Dictionary<string, object> paramDict = new Dictionary<string, object>();
            var ds = await this.dbHelper.GetDataSetByStoredProcedure("[Auth].[GetDropDownsCreateUser]", paramDict);
            return ds;
        }

        public async Task<DataSet> GetWorkingRoleTimingsDropDown(long? RoleId)
        {
            Dictionary<string, object> paramDict = new Dictionary<string, object>();
            paramDict.Add("@RoleId", RoleId);
            return await this.dbHelper.GetDataSetByStoredProcedure("[Auth].[GetWorkingRoleTimingsDropDown]", paramDict);

        }


        public async Task<DataSet> GetUserList(int offset, int pageSize, string searchVal)
        {
            if (string.IsNullOrEmpty(searchVal))
                searchVal = "";

            Dictionary<string, object> paramDict = new Dictionary<string, object>();
            paramDict.Add("@offset", offset);
            paramDict.Add("@rows", pageSize);
            paramDict.Add("@search", searchVal);
            var ds = await this.dbHelper.GetDataSetByStoredProcedure("[Auth].[GetUserList]", paramDict);
            return ds;
        }

        public async Task<DataSet> GetPersonByCNIC(string cnic)
        {
            //SqlParameter[] sql = new SqlParameter[2];
            //sql[0] = new SqlParameter("@PersonId", DBNull.Value);
            //sql[1] = new SqlParameter("@CNIC", cnic);

            //var ds = await this.adoNet.ExecuteUsingDataAdapter("[Core].[GetPerson]", sql);

            Dictionary<string, object> paramDict = new Dictionary<string, object>();
            paramDict.Add("@CNIC", cnic);
            var ds = await this.dbHelper.GetDataSetByStoredProcedure("[Auth].[GetPerson]", paramDict);


            return ds;
        }

        public async Task<DataSet> GetUserByUserId(long userId)
        {
            Dictionary<string, object> paramDict = new Dictionary<string, object>();
            paramDict.Add("@UserId", userId);
            var ds = await this.dbHelper.GetDataSetByStoredProcedure("[Auth].[GetUserByUserId]", paramDict);
            return ds;
        }

        public async Task<DataSet> GetAssignedSeriesCategories(long userId, long RoleId)
        {
            Dictionary<string, object> paramDict = new Dictionary<string, object>();
            paramDict.Add("@UserId", userId);
            paramDict.Add("@RoleId", RoleId);
            var ds = await this.dbHelper.GetDataSetByStoredProcedure("[Auth].[GetAssignedSeriesCategories]", paramDict);
            return ds;
        }


        public async Task<DataSet> GetUserPermission(long userId, long RoleId)
        {
            Dictionary<string, object> paramDict = new Dictionary<string, object>();
            paramDict.Add("@UserId", userId);
            paramDict.Add("@RoleId", RoleId);
            var ds = await this.dbHelper.GetDataSetByStoredProcedure("[Auth].[GetUserPermission]", paramDict);
            return ds;
        }

        public async Task<DataSet> GetLineManager(long DistrictId = 0, long OfficeId = 0, long userRoleId = 0)
        {

            Dictionary<string, object> paramDict = new Dictionary<string, object>();
            paramDict.Add("@DistrictId", DistrictId);
            paramDict.Add("@SiteOfficeId", OfficeId);
            paramDict.Add("@RoleId", userRoleId);
            var ds = await this.dbHelper.GetDataSetByStoredProcedure("[Auth].[GetLineManager]", paramDict);


            return ds;
        }

        public async Task<bool> SendEmailAndSMSNotification(string email, string phone, string text)
        {
            var sendSms = await this.SaveSMSNotification(phone, $"Your account has been created by the admin. \n Your auto generated password is : {text} \n You can change your password from your profile. ", "1");
            var sendEmail = await this.SaveEmailNotification("no-reply-excise@punjab.gov.pk", email, $"Your account has been created by the admin. \n Your auto generated password is : {text} \n You can change your password from your profile. ", "1");

            if (sendEmail.Tables[0].Rows[0][0] == "1" || sendSms.Tables[0].Rows[0][0] == "1")
            {
                return false;
            }

            return await NotificationHttpClient.SendNotificationRequest(Convert.ToInt32(sendSms.Tables[0].Rows[0][2]), Convert.ToInt32(sendEmail.Tables[0].Rows[0][2]));
        }


        public async Task<DataSet> SaveSMSNotification(string phone, string message, string userId)
        {
            Dictionary<string, object> paramDict = new Dictionary<string, object>();

            paramDict.Add("@Message", message);
            paramDict.Add("@UserId", userId);
            paramDict.Add("@Phone", phone);


            var ds = await this.dbHelper.GetDataSetByStoredProcedure("[Notification].[SaveSMSNotificationHistory]", paramDict);

            return ds;
        }


        public async Task<bool> SaveWorkingRoleTimings(long RoleId, string DayStartTime, string DayCloseTime, string WeekDayId, string userId, long InsOrUpd = -1)
        {
            try
            {
                Dictionary<string, object> paramDict = new Dictionary<string, object>();



                paramDict.Add("@UserId", userId);
                paramDict.Add("@InsOrUpd", InsOrUpd);
                paramDict.Add("@RoleId", RoleId);
                paramDict.Add("@DayStartTime", DayStartTime);
                paramDict.Add("@DayCloseTime", DayCloseTime);
                paramDict.Add("@WeekDayId", WeekDayId);


                await this.dbHelper.GetDataSetByStoredProcedure("[Auth].[InsertOrUpdateWorkingRoleTime]", paramDict);

                return true;
            }
            catch
            {
                return false;
            }

        }

        public async Task<DataSet> SaveEmailNotification(string senderEmail, string RecieverEmail, string message, string userId)
        {
            Dictionary<string, object> paramDict = new Dictionary<string, object>();


            paramDict.Add("@Message", message);
            paramDict.Add("@UserId", userId);
            paramDict.Add("@SenderEmail", senderEmail);
            paramDict.Add("@RecieverEmail", RecieverEmail);


            var ds = await this.dbHelper.GetDataSetByStoredProcedure("[Notification].[SaveEmailNotificationHistory]", paramDict);

            return ds;
        }




        public async Task<DataSet> UpdateUserRole(VwUserRole userObj)
        {
            Dictionary<string, object> paramDict = new Dictionary<string, object>();
            paramDict.Add("@UserId", userObj.UserId);
            paramDict.Add("@Roleid", userObj.RoleId);
            paramDict.Add("@Createdby", this.VwUser.UserId);
            paramDict.Add("@DistrictId", userObj.DistrictId);
            paramDict.Add("@SiteOfficeId", userObj.SiteOfficeId);
            if (userObj.LineManagerId > 0)
            {
                paramDict.Add("@LineManagerId", userObj.LineManagerId);
            }
            else
            {
                paramDict.Add("@LineManagerId", DBNull.Value);
            }

            var ds = await this.dbHelper.GetDataSetByStoredProcedure("[Auth].[UpdateUserRole]", paramDict);
            return ds;
        }


        public async Task<DataSet> SaveUserPermission(VwUserPermissions PermisionObj)
        {
            Dictionary<string, object> paramDict = new Dictionary<string, object>();
            paramDict.Add("@UserId", PermisionObj.UserId);
            paramDict.Add("@Roleid", PermisionObj.RoleId);
            paramDict.Add("@WorkingPermissionId", PermisionObj.WorkingPermissionId);
            paramDict.Add("@MinDateTime", PermisionObj.MinDateTime);
            paramDict.Add("@MaxDateTime", PermisionObj.MaxDateTime);
            paramDict.Add("@Createdby", this.VwUser.UserId);

            var ds = await this.dbHelper.GetDataSetByStoredProcedure("[Auth].[SaveUserPermission]", paramDict);
            return ds;
        }

        public async Task<DataSet> CancellUserPermission(long UserId, long PermissionId)
        {
            Dictionary<string, object> paramDict = new Dictionary<string, object>();
            paramDict.Add("@UserId", UserId);
            paramDict.Add("@UserWorkingPermissionId", PermissionId);
            paramDict.Add("@Createdby", this.VwUser.UserId);

            var ds = await this.dbHelper.GetDataSetByStoredProcedure("[Auth].[CancellUserPermission]", paramDict);
            return ds;
        }

        public async Task<DataSet> SaveAssignedSeriesCategories(VwUserSeriesCategory obj)
        {
            Dictionary<string, object> paramDict = new Dictionary<string, object>();
            long[] IdArrays = obj.SeriesCategoryId;

            VwIdOnly newId;
            var Id = new List<VwIdOnly>();
            for (int i = 0; i < IdArrays.Length; i++)
            {
                newId = new VwIdOnly();
                newId.Id = IdArrays[i];
                Id.Add(newId);

            }

            paramDict.Add("@Ids", Id.ToDataTable());
            paramDict.Add("@UserId", obj.UserId);
            paramDict.Add("@Roleid", obj.RoleId);
            paramDict.Add("@Createdby", this.VwUser.UserId);


            var ds = await this.dbHelper.GetDataSetByStoredProcedure("[Auth].[SaveAssignedSeriesCategories]", paramDict);
            return ds;
        }


        public async Task<DataSet> CreateUser(VwCreateUser userObj)
        {
            Dictionary<string, object> paramDict = new Dictionary<string, object>();


            var person = userObj.Person;
            var personDataModel = new Person();
            EntityMapper<VwPerson, Person>.CopyByPropertyNameAndType(person, personDataModel);

            var personList = new List<Person>();
            personList.Add(personDataModel);

            var addresses = new List<Address>();

            person.Addresses.ForEach(x =>
            {
                var address = new Address();
                EntityMapper<VwAddress, Address>.CopyByPropertyNameAndType(x, address);
                addresses.Add(address);
            });

            var phoneNumbers = new List<PhoneNumber>();

            person.PhoneNumbers.ForEach(x =>
            {
                var phoneNumber = new PhoneNumber();
                EntityMapper<VwPhoneNumber, PhoneNumber>.CopyByPropertyNameAndType(x, phoneNumber);
                phoneNumbers.Add(phoneNumber);
            });


            paramDict.Add("@Person", personList.ToDataTable());
            paramDict.Add("@Address", addresses.ToDataTable());
            paramDict.Add("@PhoneNumber", phoneNumbers.ToDataTable());
            paramDict.Add("@UserName", userObj.UserName);
            paramDict.Add("@Password", userObj.Password);
            paramDict.Add("@Roleid", userObj.RoleId);
            paramDict.Add("@Createdby", this.VwUser.UserId);
            paramDict.Add("@UserDistrictId", userObj.DistrictId);
            paramDict.Add("@SiteOfficeId", userObj.SiteOfficeId);
            paramDict.Add("@UserTypeId", userObj.UserTypeId);
            paramDict.Add("@ClientIP", userObj.ClientIP);
            if (userObj.LineManagerId > 0)
            {
                paramDict.Add("@LineManagerId", userObj.LineManagerId);
            }
            else
            {
                paramDict.Add("@LineManagerId", DBNull.Value);
            }

            var ds = await this.dbHelper.GetDataSetByStoredProcedure("[Auth].[CreateUserExt]", paramDict);
            return ds;
        }

        public async Task<DataSet> ValidateNTN(string NTN)
        {
            Dictionary<string, object> paramDict = new Dictionary<string, object>();
            paramDict.Add("@NTN", NTN);


            var ds = await this.dbHelper.GetDataSetByStoredProcedure("[Business].[GetBusinesCredential]", paramDict);
            return ds;
        }


        public async Task<DataSet> ValidateEmail(string email)
        {
            Dictionary<string, object> paramDict = new Dictionary<string, object>();
            paramDict.Add("@Email", email);


            var ds = await this.dbHelper.GetDataSetByStoredProcedure("[Auth].[ValidateEmail]", paramDict);
            return ds;
        }


        public async Task<DataSet> ValidatePhone(string phone)
        {
            Dictionary<string, object> paramDict = new Dictionary<string, object>();
            paramDict.Add("@Phone", phone);


            var ds = await this.dbHelper.GetDataSetByStoredProcedure("[Auth].[ValidatePhone]", paramDict);
            return ds;
        }



        public async Task<DataSet> ValidateIP(string IPAddress)
        {
            Dictionary<string, object> paramDict = new Dictionary<string, object>();
            paramDict.Add("@IPAddress", IPAddress);


            var ds = await this.dbHelper.GetDataSetByStoredProcedure("[Auth].[ValidateIPAddress]", paramDict);
            return ds;
        }

        public async Task<DataSet> GetWorkingDayOffTypeDropdown()
        {
            return await this.dbHelper.GetDataSetByStoredProcedure("[Auth].[GetWorkingOffDayTypeDropdown]", null);
        }

        public async Task<DataSet> GetSiteOfficesList()
        {
            return await this.dbHelper.GetDataSetByStoredProcedure("[Setup].[GetSiteOfficeList]", null);

        }

        public async Task<DataSet> InsertOrUpdateWorkingOffDay(long districtId,long? roleId, long? OfficeId, string workingOffDate, string offDayTypeId, string userId)
        {
            Dictionary<string, object> paramDict = new Dictionary<string, object>();


           
            paramDict.Add("@DistrictId", districtId);
            paramDict.Add("@OfficeId", OfficeId);
            paramDict.Add("@RoleId", roleId);
            paramDict.Add("@OffDate", workingOffDate);
            paramDict.Add("@OffDayTypeId", offDayTypeId);
            paramDict.Add("@UserId", userId);


            try
            {
                var save = await this.dbHelper.GetDataSetByStoredProcedure("[Auth].[InsertOrUpdateWorkingOffDay]", paramDict);
                return save;
            }
            catch
            {
                return null;
            }

        }

        public async Task<bool> SaveRoute(long userId, long routeId, long createdBy)
        {
            Dictionary<string, object> paramDict = new Dictionary<string, object>();


            paramDict.Add("@UserId", userId);
            paramDict.Add("@RouteId", routeId);
            paramDict.Add("@CreatedBy", createdBy);

            try
            {
                var save = await this.dbHelper.GetDataSetByStoredProcedure("[Auth].[SaveUserRoute]", paramDict);
                return true;
            }
            catch
            {
                return false;
            }
        }


        public async Task<bool> SaveRoleRoute(long roleId, long routeId, long createdBy)
        {
            Dictionary<string, object> paramDict = new Dictionary<string, object>();


            paramDict.Add("@RoleId", roleId);
            paramDict.Add("@RouteId", routeId);
            paramDict.Add("@CreatedBy", createdBy);

            try
            {
                var save = await this.dbHelper.GetDataSetByStoredProcedure("[Auth].[SaveRoleRoute]", paramDict);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<DataSet> AssignUserApplications(string appIds, long userId)
        {
            Dictionary<string, object> paramDict = new Dictionary<string, object>();
            paramDict.Add("@UserId", userId);
            paramDict.Add("@AppIds", appIds);
           

            var ds = await this.dbHelper.GetDataSetByStoredProcedure("[Core].[AssignUserApplications]", paramDict);
            return ds;
        }

        public async Task<DataSet> GetWorkingOffDayList()
        {
            return await this.dbHelper.GetDataSetByStoredProcedure("[Auth].[GetWorkingOffDaysList]", null);
        }

        public async Task<DataSet> DeleteWorkingOffDay(long Id)
        {
            Dictionary<string, object> paramDict = new Dictionary<string, object>();


            paramDict.Add("@WorkingOffDayId", Id);

            return await this.dbHelper.GetDataSetByStoredProcedure("[Auth].[DeleteWorkingOffDay]", paramDict);

        }

        public async Task<DataSet> DeleteRoute(long userRouteId)
        {
            Dictionary<string, object> paramDict = new Dictionary<string, object>();


            paramDict.Add("@UserRouteId", userRouteId);

            return await this.dbHelper.GetDataSetByStoredProcedure("[Auth].[DeleteUserRoute]", paramDict);
        }

        public async Task<DataSet> DeleteRoleRoute(long roleRouteId)
        {
            Dictionary<string, object> paramDict = new Dictionary<string, object>();


            paramDict.Add("@RoleRouteId", roleRouteId);

            return await this.dbHelper.GetDataSetByStoredProcedure("[Auth].[DeleteRoleRoute]", paramDict);
        }

        public async Task<DataSet> GetRoutesList()
        {
            return await this.dbHelper.GetDataSetByStoredProcedure("[Auth].[GetRoutesList]", null);
        }

        public async Task<DataSet> GetUserRoutesList(long userId)
        {

            Dictionary<string, object> paramDict = new Dictionary<string, object>();


            paramDict.Add("@userId", userId);

            return await this.dbHelper.GetDataSetByStoredProcedure("[Auth].[GetUserRoutesList]", paramDict);
        }


        public async Task<DataSet> GetRoleRoutesList(long roleId)
        {

            Dictionary<string, object> paramDict = new Dictionary<string, object>();


            paramDict.Add("@RoleId", roleId);

            return await this.dbHelper.GetDataSetByStoredProcedure("[Auth].[GetRoleRoutesList]", paramDict);
        }


        public async Task<DataSet> GetRolesList()
        {
            return await this.dbHelper.GetDataSetByStoredProcedure("[Auth].[GetRolesList]", null);
            
        }


        public async Task<DataSet> GetRolesHistory(long userId)
        {
            Dictionary<string, object> paramDict = new Dictionary<string, object>();


            paramDict.Add("@UserId", userId);

            return await this.dbHelper.GetDataSetByStoredProcedure("[Auth].[GetRolesHistory]", paramDict);
        }

        public async Task<DataSet> GetDistrictList()
        {
            return await this.dbHelper.GetDataSetByStoredProcedure("[Setup].[GetDistrictsList]", null);
        }

        public async Task<DataSet> GetUserApplicationsDropDown(long userId)
        {
            Dictionary<string, object> paramDict = new Dictionary<string, object>();


            paramDict.Add("@UserId", userId);

            return await this.dbHelper.GetDataSetByStoredProcedure("[Core].[GetUserApplications]", paramDict);

        }


        public async Task<DataSet> GetUsersListByRoleId(long roleId)
        {
            Dictionary<string, object> paramDict = new Dictionary<string, object>();


            paramDict.Add("@RoleId", roleId);

            return await this.dbHelper.GetDataSetByStoredProcedure("[Auth].[GetUserListDropdownByRoleId]", paramDict);

        }

    }
}
