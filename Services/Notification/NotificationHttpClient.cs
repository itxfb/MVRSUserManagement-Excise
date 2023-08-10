namespace UserManagement.Services.Notification
{
    public class NotificationHttpClient
    {
        static readonly HttpClient httpClient;

        static NotificationHttpClient()
        {
            httpClient = new();
        }

        public static async Task<bool> SendNotificationRequest(long smsId, long emailId)
        {
            try
            {
                var httpResponseMessage = await httpClient.GetAsync($"http://10.50.126.65:6090/api/Notification/EnqueueNotificationTask?smsId={smsId}&emailId={emailId}");
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}
