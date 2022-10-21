using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VivaioInCloud.Notificator.Models;

namespace VivaioInCloud.Notificator.Abstraction
{
    public interface INotify
    {
        Task SendEmail(SendEmailRequest mail, CancellationToken cancellationToken = default);
    }
}
