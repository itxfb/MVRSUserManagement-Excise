namespace UserManagement.ViewModels
{
    public class VwCreateUser
    {
		public string UserName { get; set; }
		public string Password { get; set; }
		public long RoleId { get; set; }
		public long? LineManagerId { get; set; }
		public long? DistrictId { get; set; }
		public long? SiteOfficeId { get; set; }
		public long UserTypeId { get; set; }
		public string ClientIP { get; set; }
		public VwPerson Person { get; set; }

	}
}
