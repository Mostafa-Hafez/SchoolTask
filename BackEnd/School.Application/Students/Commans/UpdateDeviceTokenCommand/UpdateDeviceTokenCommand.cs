using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.Students.Commans.UpdateDeviceTokenCommand
{
    public record UpdateDeviceTokenCommand(int StudentId, string DeviceToken) : IRequest<bool> { }
    
}
