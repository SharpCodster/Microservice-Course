using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using VivaioInCloud.Common;
using VivaioInCloud.Notificator.Abstraction;
using VivaioInCloud.Notificator.Models;
using VivaioInCloud.Notificator.Options;

namespace VivaioInCloud.Notificator.Service
{
    public class Notify : INotify
    {
        private readonly NotificationOptions _options;

        public Notify(IOptions<NotificationOptions> options)
        {
            _options = options.Value;
        }

        public async Task SendEmail(SendEmailRequest mail, CancellationToken cancellationToken = default)
        {
            string output = JsonConvert.SerializeObject(mail);
            
            await Task.CompletedTask;
        }
    }
}
