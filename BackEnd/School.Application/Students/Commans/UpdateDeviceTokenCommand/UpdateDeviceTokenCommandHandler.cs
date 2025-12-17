using MediatR;
using School.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.Students.Commans.UpdateDeviceTokenCommand
{
    public class UpdateDeviceTokenCommandHandler : IRequestHandler<UpdateDeviceTokenCommand, bool>
    {
        private readonly IStudentRepository _studentrepo;

        public UpdateDeviceTokenCommandHandler(IStudentRepository studentrepo)
        {
            _studentrepo = studentrepo;
        }
        public async Task<bool> Handle(UpdateDeviceTokenCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _studentrepo.GetByIdAsync(request.StudentId);

                if (entity == null)
                    return false;

                entity.FirebaseDeviceToken = request.DeviceToken;
                await _studentrepo.UpdateAsync(entity);

                return true;
            }
            catch 
            {
                return false;
            }
            
        }
    }
}
