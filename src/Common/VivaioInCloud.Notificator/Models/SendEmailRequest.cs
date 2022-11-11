using VivaioInCloud.Common;

namespace VivaioInCloud.Notificator.Models
{
    public class SendEmailRequest : NotificationRequest
    {
        public SendEmailRequest()
        {
            Action = SolutionConstants.NotificationAction.EMAIL;
        }

        public string Title { get; set; }
        public string TemplateName { get; set; }
        public List<string> ToList { get; set; }
        public List<string> CcList { get; set; }
        public Dictionary<string, string> Parameters { get; set; }

    }
}
