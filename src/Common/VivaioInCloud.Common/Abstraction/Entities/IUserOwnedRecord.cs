using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VivaioInCloud.Common.Abstraction.Entities
{
    public interface IUserOwnedRecord
    {
        string UserId { get; set; }
    }
}
