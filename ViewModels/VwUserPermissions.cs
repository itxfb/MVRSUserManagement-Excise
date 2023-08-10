namespace UserManagement.ViewModels
{
    public class VwUserPermissions
    {
        public long UserWorkingPermissionId { get; set; }
        public long UserId { get; set; }
        public long RoleId { get; set; }
        public long WorkingPermissionId { get; set; }
        public DateTime MinDateTime { get; set; }
        public DateTime MaxDateTime { get; set; }
    }
}
