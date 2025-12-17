using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.Interfaces
{
    public interface IFirebaseNotificationService
    {
        Task SendNotificatioAsync(string deviceToken, string title, string body);
    }
}
