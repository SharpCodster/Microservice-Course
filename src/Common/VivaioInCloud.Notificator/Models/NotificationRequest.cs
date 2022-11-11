namespace VivaioInCloud.Notificator.Models
{
    public class NotificationRequest
    {
        public string Action { get; set; }
        public string CorrelationId { get; set; }
        public string UserId { get; set; }
    }
}
