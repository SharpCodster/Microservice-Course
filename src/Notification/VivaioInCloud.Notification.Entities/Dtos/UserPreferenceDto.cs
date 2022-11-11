using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VivaioInCloud.Common.Entities.Dtos;
using VivaioInCloud.Notification.Entities.Models;

namespace VivaioInCloud.Notification.Entities.Dtos
{
    public class UserPreferenceDtoRead : BaseDto
    {
        public string TypeId { get; set; }
        public ContactDtoRead User { get; set; }
    }

    public class UserPreferenceDtoWrite
    {
        public string TypeId { get; set; }
    }
}
