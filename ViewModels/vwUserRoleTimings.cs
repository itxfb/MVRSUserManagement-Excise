namespace UserManagement.ViewModels
{
    public class vwUserRoleTimings
    {
        public long RoleId { get; set; }
        public string DayStartTime { get; set; }
        public string DayCloseTime { get; set; }
        public string WeekDayId { get; set; }
        public string? userId { get; set; }
        public long InsOrUpd { get; set; }
    }
}
