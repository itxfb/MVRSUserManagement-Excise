using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.VisualBasic;
using Models.DatabaseModels.Authentication;
using Models.ViewModels.Identity;
using ApiResponseType = SharedLib.APIs.ApiResponseType;
using Constants = SharedLib.Common.Constants;
using Models.ViewModels.VehicleRegistration.Core;
using SharedLib.APIs;
using SharedLib.Common;
using SharedLib.Security;
using System;
using System.Data;
using UserManagement.Services;
using UserManagement.ViewModels;

namespace UserManagement.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = AuthenticationSchemes.JWT_BEARER_TOKEN_STATELESS)]
    public class UserManagementController : ControllerBase
    {
        private readonly IUserManagementService userManagementService;
        public VwUser User
        {
            get
            {
                return (VwUser)this.Request.HttpContext.Items["User"];
            }
        }

        public UserManagementController(IUserManagementService userManagementService)
        {
            this.userManagementService = userManagementService;
        }

        #region GetMethods

        [HttpGet(Name = "GetDropDownsCreateUser")]
        public async Task<ApiResponse> GetDropDownsCreateUser()
        {
            var ds = await this.userManagementService.GetDropDownsCreateUser();
            var data = new
            {
                Districts = ds.Tables[0],
                SiteOffices = ds.Tables[1],
                Roles = ds.Tables[2],
                tehsils = ds.Tables[3],
                addressArea = ds.Tables[4],
                PostOffice = ds.Tables[5]
            };

            return ApiResponse.GetApiResponse(ApiResponseType.SUCCESS, data, Constants.RECORD_FOUND_MESSAGE);
        }


        [HttpGet(Name = "GetWorkingRoleTimingsDropDown")]

        public async Task<ApiResponse> GetWorkingRoleTimingsDropDown(long? RoleId = -1)
        {
            var ds = await this.userManagementService.GetWorkingRoleTimingsDropDown(RoleId);

            var data = new
            {
                RolesIds = new List<object>(),
                RoleNames = new List<object>(),
                DayStartTimes = new List<object>(),
                DayCloseTimes = new List<object>(),
                WeekDayIds = new List<object>(),
                WeekDayNames = new List<object>()

            };

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                if (!data.RolesIds.Contains(row["RoleId"]))
                    data.RolesIds.Add(row["RoleId"]);
                if (!data.RoleNames.Contains(row["RoleName"]))
                    data.RoleNames.Add(row["RoleName"]);
                data.DayStartTimes.Add(row["DayStartTime"]);
                data.DayCloseTimes.Add(row["DayCloseTime"]);
                data.WeekDayIds.Add(row["WeekDId"]);
                data.WeekDayNames.Add(row["WeekDayName"]);
            }




            return ApiResponse.GetApiResponse(ApiResponseType.SUCCESS, data, Constants.RECORD_FOUND_MESSAGE);
        }


        [HttpGet]
        public async Task<ApiResponse> GetDropDownWorkingOffDayType()
        {
            var ds = await this.userManagementService.GetWorkingDayOffTypeDropdown();

            var data = new
            {
                WorkingOffDayType = ds.Tables[0]
            };

            return ApiResponse.GetApiResponse(ApiResponseType.SUCCESS, data, Constants.RECORD_FOUND_MESSAGE);
        }


        [HttpGet(Name = "GetAllUsersListByRole")]
        public async Task<ApiResponse> GetAllUsersListByRole(long roleId)
        {
            var ds = await this.userManagementService.GetUsersListByRoleId(roleId);
          

            return ApiResponse.GetApiResponse(ApiResponseType.SUCCESS, ds.Tables[0], Constants.RECORD_FOUND_MESSAGE);
        }

        [HttpGet(Name = "GetUserApplicationsDropDown")]
        public async Task<ApiResponse> GetUserApplicationsDropDown(long userId)
        {
            var ds = await this.userManagementService.GetUserApplicationsDropDown(userId);


            return ApiResponse.GetApiResponse(ApiResponseType.SUCCESS, ds.Tables[0], Constants.RECORD_FOUND_MESSAGE);
        }




        [HttpGet(Name = "GetLineManager")]
        public async Task<ApiResponse> GetLineManager(long DistrictId = 0, long OfficeId = 0, long userRoleId = 0)
        {
            var ds = await this.userManagementService.GetLineManager(DistrictId, OfficeId, userRoleId);
            if (ds.Tables[0].Rows.Count > 0)
            {
                var data = new
                {
                    Roles = ds.Tables[0]
                };

                return ApiResponse.GetApiResponse(ApiResponseType.SUCCESS, data, Constants.RECORD_FOUND_MESSAGE);

            }
            else
            {

                return ApiResponse.GetApiResponse(ApiResponseType.NOT_FOUND, null, Constants.NOT_FOUND_MESSAGE);
            }

        }

        [HttpGet(Name = "GetUsersList")]
        public async Task<ApiResponse> GetUsersList(int offset, int pageSize, string? searchVal = "")
        {
            var ds = await this.userManagementService.GetUserList(offset, pageSize, searchVal);
            if (ds.Tables[0] != null)
            {
                var data = new
                {
                    users = ds.Tables[0]
                };

                return ApiResponse.GetApiResponse(ApiResponseType.SUCCESS, data, Constants.RECORD_FOUND_MESSAGE);

            }
            else
            {

                return ApiResponse.GetApiResponse(ApiResponseType.NOT_FOUND, null, Constants.NOT_FOUND_MESSAGE);
            }

        }

        [HttpGet(Name= "GetRoutesList")]
        public async Task<ApiResponse> GetRoutesList()
        {
            var ds = await this.userManagementService.GetRoutesList();
            try
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    var data = ds.Tables[0];

                    return ApiResponse.GetApiResponse(ApiResponseType.SUCCESS, data, Constants.RECORD_FOUND_MESSAGE);

                }
                return ApiResponse.GetApiResponse(ApiResponseType.NOT_FOUND, null, Constants.NOT_FOUND_MESSAGE);
            }
            catch
            {

                return ApiResponse.GetApiResponse(ApiResponseType.NOT_FOUND, null, Constants.NOT_FOUND_MESSAGE);
            }
        }

        [HttpGet(Name = "GetRolesList")]
        public async Task<ApiResponse> GetRolesList()
        {
            var ds = await this.userManagementService.GetRolesList();

            return ApiResponse.GetApiResponse(ApiResponseType.SUCCESS, ds.Tables[0], Constants.RECORD_FOUND_MESSAGE);
        }

        [HttpGet(Name = "GetDistrictList")]
        public async Task<ApiResponse> GetDistrictList()
        {
            var ds = await this.userManagementService.GetDistrictList();

            return ApiResponse.GetApiResponse(ApiResponseType.SUCCESS, ds.Tables[0], Constants.RECORD_FOUND_MESSAGE);
        }


        [HttpGet(Name = "GetUserRoutes")]
        public async Task<ApiResponse> GetUserRoutes(long userId)
        {
            var ds = await this.userManagementService.GetUserRoutesList(userId);
            try
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    var data = ds.Tables[0];

                    return ApiResponse.GetApiResponse(ApiResponseType.SUCCESS, data, Constants.RECORD_FOUND_MESSAGE);

                }
                return ApiResponse.GetApiResponse(ApiResponseType.NOT_FOUND, null, Constants.NOT_FOUND_MESSAGE);
            }
            catch
            {

                return ApiResponse.GetApiResponse(ApiResponseType.NOT_FOUND, null, Constants.NOT_FOUND_MESSAGE);
            }
        }


        [HttpGet(Name = "GetRoleRoutes")]
        public async Task<ApiResponse> GetRoleRoutes(long roleId)
        {
            var ds = await this.userManagementService.GetRoleRoutesList(roleId);
            try
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    var data = ds.Tables[0];

                    return ApiResponse.GetApiResponse(ApiResponseType.SUCCESS, data, Constants.RECORD_FOUND_MESSAGE);

                }
                return ApiResponse.GetApiResponse(ApiResponseType.NOT_FOUND, null, Constants.NOT_FOUND_MESSAGE);
            }
            catch
            {

                return ApiResponse.GetApiResponse(ApiResponseType.NOT_FOUND, null, Constants.NOT_FOUND_MESSAGE);
            }
        }

        [HttpGet(Name = "GetRolesHistory")]
        public async Task<ApiResponse> GetRolesHistory(long userId)
        {
            var ds = await this.userManagementService.GetRolesHistory(userId);

            try
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    var data = ds.Tables[0];

                    return ApiResponse.GetApiResponse(ApiResponseType.SUCCESS, data, Constants.RECORD_FOUND_MESSAGE);

                }
                return ApiResponse.GetApiResponse(ApiResponseType.NOT_FOUND, null, Constants.NOT_FOUND_MESSAGE);
            }
            catch
            {

                return ApiResponse.GetApiResponse(ApiResponseType.NOT_FOUND, null, Constants.NOT_FOUND_MESSAGE);
            }
        }

        [HttpGet(Name = "GetSiteOfficesList")]
        public async Task<ApiResponse> GetSiteOfficesDropdown()
        {
            var ds = await this.userManagementService.GetSiteOfficesList();
            try
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    var data = new
                    {
                        SiteOffices = ds.Tables[0]
                    };

                    return ApiResponse.GetApiResponse(ApiResponseType.SUCCESS, data, Constants.RECORD_FOUND_MESSAGE);

                }
                return ApiResponse.GetApiResponse(ApiResponseType.NOT_FOUND, null, Constants.NOT_FOUND_MESSAGE);
            }
            catch
            {

                return ApiResponse.GetApiResponse(ApiResponseType.NOT_FOUND, null, Constants.NOT_FOUND_MESSAGE);
            }
        }

        [HttpGet(Name = "GetAssignedSeriesCategories")]
        public async Task<ApiResponse> GetAssignedSeriesCategories(long userId, long RoleId)
        {
            var ds = await this.userManagementService.GetAssignedSeriesCategories(userId, RoleId);
            if (ds.Tables[0].Rows.Count > 0)
            {
                var data = new
                {
                    SeriesCategories = ds.Tables[0]
                };

                return ApiResponse.GetApiResponse(ApiResponseType.SUCCESS, data, Constants.RECORD_FOUND_MESSAGE);

            }
            else
            {

                return ApiResponse.GetApiResponse(ApiResponseType.NOT_FOUND, null, Constants.NOT_FOUND_MESSAGE);
            }

        }


        [HttpGet(Name = "GetUserByUserId")]
        public async Task<ApiResponse> GetUserByUserId(long userId)
        {
            var ds = await this.userManagementService.GetUserByUserId(userId);
            if (ds.Tables[0].Rows.Count > 0)
            {
                var data = new
                {
                    users = SharedLib.Common.Extentions.ToList<VwUserInfo>(ds.Tables[0]).FirstOrDefault()
                };

                return ApiResponse.GetApiResponse(ApiResponseType.SUCCESS, data, Constants.RECORD_FOUND_MESSAGE);

            }
            else
            {

                return ApiResponse.GetApiResponse(ApiResponseType.NOT_FOUND, null, Constants.NOT_FOUND_MESSAGE);
            }

        }



        [HttpGet(Name = "GetPersonByCNIC")]
        public async Task<ApiResponse> GetPersonByCNIC(string cnic)
        {

            var ds = await this.userManagementService.GetPersonByCNIC(cnic);

            var person = SharedLib.Common.Extentions.ToList<UserManagement.ViewModels.VwPerson>(ds.Tables[0]).FirstOrDefault();

            if (person is not null)
            {
                person.Addresses = SharedLib.Common.Extentions.ToList<UserManagement.ViewModels.VwAddress>(ds.Tables[1]).ToList();
                person.PhoneNumbers = SharedLib.Common.Extentions.ToList<UserManagement.ViewModels.VwPhoneNumber>(ds.Tables[2]).ToList();
            }

            var data = new { person };

            var status = person is not null ? Constants.RECORD_FOUND_MESSAGE : Constants.NOT_FOUND_MESSAGE;

            return ApiResponse.GetApiResponse(ApiResponseType.SUCCESS, data, status);
        }

        [HttpGet(Name = "GetUserPermission")]
        public async Task<ApiResponse> GetUserPermission(long userId, long RoleId)
        {

            var ds = await this.userManagementService.GetUserPermission(userId, RoleId);
            if (ds.Tables[0].Rows.Count > 0)
            {
                var data = new
                {
                    userPersmissions = ds.Tables[0]
                };

                return ApiResponse.GetApiResponse(ApiResponseType.SUCCESS, data, Constants.RECORD_FOUND_MESSAGE);

            }
            else
            {

                return ApiResponse.GetApiResponse(ApiResponseType.NOT_FOUND, null, Constants.NOT_FOUND_MESSAGE);
            }
        }

        [HttpGet(Name = "GetWorkingOffDayList")]
        public async Task<ApiResponse> GetWorkingOffDayList()
        {

            var ds = await this.userManagementService.GetWorkingOffDayList();
            if (ds.Tables[0].Rows.Count > 0)
            {
                var data = new
                {
                    WorkingOffDaysList = ds.Tables[0]
                };

                return ApiResponse.GetApiResponse(ApiResponseType.SUCCESS, data, Constants.RECORD_FOUND_MESSAGE);

            }
            else
            {

                return ApiResponse.GetApiResponse(ApiResponseType.NOT_FOUND, null, Constants.NOT_FOUND_MESSAGE);
            }
        }


        #endregion

        #region PostMethods

        [HttpPost]
        public async Task<ApiResponse> CreateUser(VwCreateUser userObj)
        {
            this.userManagementService.VwUser = this.User;
            userObj.UserTypeId = 1;

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            userObj.Password = new string(Enumerable.Repeat(chars, 7)
                .Select(s => s[new Random().Next(s.Length)]).ToArray());



            var sendPasswordToUser = await this.userManagementService.SendEmailAndSMSNotification( userObj.Person.Email, userObj.Person.PhoneNumbers.First().PhoneNumberValue, userObj.Password);


            if (sendPasswordToUser == false)
            {
                return ApiResponse.GetApiResponse(ApiResponseType.FAILED, null, Constants.DATA_NOT_SAVED_MESSAGE + " Something went wrong ! Please try again.");

            }

            var passwordHasher = new PasswordHasher<User>();
            userObj.Password = passwordHasher.HashPassword(new Models.DatabaseModels.Authentication.User(), userObj.Password);

            
            //format IP Address
            string input = userObj.ClientIP;
            
            string output = "";

            for (int i = 0; i < input.Length; i += 3)
            {
                int length = Math.Min(3, input.Length - i);
                output += input.Substring(i, length) + ".";
            }

            // Remove the last dot // formatted IP
            userObj.ClientIP = output.TrimEnd('.');

            var ds = await this.userManagementService.CreateUser(userObj);



            if (ds.Tables.Count > 0 && ds.Tables[0].Rows[0][0].ToString() == "0")
            {
                return ApiResponse.GetApiResponse(ApiResponseType.SUCCESS, null, ds.Tables[0].Rows[0][1].ToString());
            }
            else
            {
                return ApiResponse.GetApiResponse(ApiResponseType.FAILED, null, Constants.DATA_NOT_SAVED_MESSAGE + " : "+ ds.Tables[0].Rows[0][1].ToString());
            }
        }


        [HttpPost]
        public async Task<ApiResponse> AssignUserApplications(string appIds, long userId)
        {
            var ds = await this.userManagementService.AssignUserApplications(appIds, userId);
            
            var result = ds.Tables[0].ToList<ApiResponse>().First();

            return result;

        }

        [HttpPost]
        public async Task<ApiResponse> UpdateUserRole(VwUserRole userObj)
        {
            this.userManagementService.VwUser = this.User;
            var ds = await this.userManagementService.UpdateUserRole(userObj);

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows[0][0].ToString() == "0")
            {
                return ApiResponse.GetApiResponse(ApiResponseType.SUCCESS, null, Constants.DATA_SAVED_MESSAGE);
            }
            else
            {
                return ApiResponse.GetApiResponse(ApiResponseType.FAILED, null, Constants.DATA_NOT_SAVED_MESSAGE + ds.Tables[0].Rows[0][1].ToString());
            }

        }

        [HttpPost]
        public async Task<ApiResponse> SaveUserPermission(VwUserPermissions PermisionObj)
        {
            this.userManagementService.VwUser = this.User;
            var ds = await this.userManagementService.SaveUserPermission(PermisionObj);

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows[0][0].ToString() == "0")
            {
                return ApiResponse.GetApiResponse(ApiResponseType.SUCCESS, null, Constants.DATA_SAVED_MESSAGE);
            }
            else
            {
                return ApiResponse.GetApiResponse(ApiResponseType.FAILED, null, Constants.DATA_NOT_SAVED_MESSAGE + ds.Tables[0].Rows[0][1].ToString());
            }

        }

        [HttpPost]
        public async Task<ApiResponse> CancellUserPermission(VwUserPermissionId obj)
        {
            this.userManagementService.VwUser = this.User;
            var ds = await this.userManagementService.CancellUserPermission(obj.UserId, obj.PermissionId);

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows[0][0].ToString() == "0")
            {
                return ApiResponse.GetApiResponse(ApiResponseType.SUCCESS, null, Constants.DATA_SAVED_MESSAGE);
            }
            else
            {
                return ApiResponse.GetApiResponse(ApiResponseType.FAILED, null, Constants.DATA_NOT_SAVED_MESSAGE + ds.Tables[0].Rows[0][1].ToString());
            }

        }


        [HttpPost]
        public async Task<ApiResponse> SaveAssignedSeriesCategories(VwUserSeriesCategory obj)
        {
            this.userManagementService.VwUser = this.User;
            var ds = await this.userManagementService.SaveAssignedSeriesCategories(obj);

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows[0][0].ToString() == "0")
            {
                return ApiResponse.GetApiResponse(ApiResponseType.SUCCESS, null, Constants.DATA_SAVED_MESSAGE);
            }
            else
            {
                return ApiResponse.GetApiResponse(ApiResponseType.FAILED, null, Constants.DATA_NOT_SAVED_MESSAGE + ds.Tables[0].Rows[0][1].ToString());
            }

        }



        [HttpPost(Name = "SaveRoleTimings")]

        public async Task<ApiResponse> InsertOrUpdateRoleTimings(vwUserRoleTimings timings)
        {
            timings.userId = this.User.UserId.ToString();
            var insOrUpdate = await this.userManagementService.SaveWorkingRoleTimings(timings.RoleId, timings.DayStartTime, timings.DayCloseTime, timings.WeekDayId, timings.userId, timings.InsOrUpd);

            if (insOrUpdate)
            {
                return ApiResponse.GetApiResponse(ApiResponseType.SUCCESS, null, Constants.DATA_SAVED_MESSAGE);
            }

            return ApiResponse.GetApiResponse(ApiResponseType.FAILED, null, Constants.DATA_NOT_SAVED_MESSAGE);

        }


        [HttpPost(Name = "SaveWorkingOffDays")]

        public async Task<ApiResponse> SaveWorkingOffDays(long districtId,long? roleId ,long? OfficeId, string workingOffDate, string offDayTypeId)
        {
            
            var insOrUpdate = await this.userManagementService.InsertOrUpdateWorkingOffDay(districtId, roleId, OfficeId, workingOffDate, offDayTypeId, this.User.UserId.ToString());

            var result = insOrUpdate.Tables[0].ToList<ApiResponse>().FirstOrDefault();

            return result;
        }


        [HttpPost(Name = "SaveUserRoute")]
        public async Task<ApiResponse> SaveUserRoute(long userId, long routeId)
        {
            var result = await this.userManagementService.SaveRoute(userId, routeId,this.User.UserId);

            if (result)
            {
                return ApiResponse.GetApiResponse(ApiResponseType.SUCCESS, null, Constants.DATA_SAVED_MESSAGE);
            }

            return ApiResponse.GetApiResponse(ApiResponseType.FAILED, null, Constants.DATA_NOT_SAVED_MESSAGE);
        }


        [HttpPost(Name = "SaveRoleRoute")]
        public async Task<ApiResponse> SaveRoleRoute(long roleId, long routeId)
        {
            var result = await this.userManagementService.SaveRoleRoute(roleId, routeId, this.User.UserId);

            if (result)
            {
                return ApiResponse.GetApiResponse(ApiResponseType.SUCCESS, null, Constants.DATA_SAVED_MESSAGE);
            }

            return ApiResponse.GetApiResponse(ApiResponseType.FAILED, null, Constants.DATA_NOT_SAVED_MESSAGE);
        }

        [HttpPost(Name = "DeleteUserRoute")]

        public async Task<ApiResponse> DeleteUserRoute(long userRouteId)
        {
            var ds = await this.userManagementService.DeleteRoute(userRouteId);
            
            var result = ds.Tables[0].ToList<ApiResponse>().First();

            if (result.status == ApiResponseType.FAILED)
            {
                return ApiResponse.GetApiResponse(ApiResponseType.FAILED, null, result.message);
            }

            return ApiResponse.GetApiResponse(ApiResponseType.SUCCESS, result, Constants.DATA_SAVED_MESSAGE);
        }


        [HttpPost(Name = "DeleteRoleRoute")]

        public async Task<ApiResponse> DeleteRoleRoute(long roleRouteId)
        {
            var ds = await this.userManagementService.DeleteRoleRoute(roleRouteId);

            var result = ds.Tables[0].ToList<ApiResponse>().First();

            if (result.status == ApiResponseType.FAILED)
            {
                return ApiResponse.GetApiResponse(ApiResponseType.FAILED, null, result.message);
            }

            return ApiResponse.GetApiResponse(ApiResponseType.SUCCESS, result, Constants.DATA_SAVED_MESSAGE);
        }


        [HttpPost(Name = "DeleteWorkingOffDay")]
        public async Task<ApiResponse> DeleteWorkingOffDay(long Id)
        {
            var ds = await this.userManagementService.DeleteWorkingOffDay(Id);

            var result = ds.Tables[0].ToList<ApiResponse>().First();

            if (result.status == ApiResponseType.FAILED)
            {
                return ApiResponse.GetApiResponse(ApiResponseType.FAILED, null, result.message);
            }

            return ApiResponse.GetApiResponse(ApiResponseType.SUCCESS, result, Constants.DATA_SAVED_MESSAGE);
        }




        #endregion

        #region Validators
       
        [HttpPost(Name = "ValidateNTN")]

        public async Task<ApiResponse> ValidateNTN(string NTN)
        {
            this.userManagementService.VwUser = this.User;
            var ds = await this.userManagementService.ValidateNTN(NTN);

            if (ds.Tables[0].Rows.Count == 0)
            {
                return ApiResponse.GetApiResponse(ApiResponseType.SUCCESS, null, Constants.NOT_FOUND_MESSAGE);
            }
            else
            {
                return ApiResponse.GetApiResponse(ApiResponseType.FAILED, null, Constants.RECORD_FOUND_MESSAGE + ds.Tables[0].Rows[0][1].ToString());
            }
        }

        [HttpPost(Name = "ValidateEmail")]

        public async Task<ApiResponse> ValidateEmail(string email)
        {
            this.userManagementService.VwUser = this.User;
            var ds = await this.userManagementService.ValidateEmail(email);

            return ds.Tables[0].ToList<ApiResponse>().FirstOrDefault();

            
        }

        [HttpPost(Name = "ValidatePhone")]

        public async Task<ApiResponse> ValidatePhone(string phone)
        {
            this.userManagementService.VwUser = this.User;
            var ds = await this.userManagementService.ValidatePhone(phone);

            return ds.Tables[0].ToList<ApiResponse>().FirstOrDefault();
        }


        [HttpPost(Name = "ValidateIP")]

        public async Task<ApiResponse> ValidateIP(string IPAddress)
        {

            var ds = await this.userManagementService.ValidateIP(IPAddress);

            return ds.Tables[0].ToList<ApiResponse>().FirstOrDefault();
        }

        #endregion

    }
}
