using Application.Repositories;
using Application.Services.AdminService;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AdminActions.Commands.Update
{
    public class UpdateAdminActionCommand  : IRequest<UpdateAdminActionResponse>
    {
        public int Id { get; set; } 
        public int AdminId { get; set; }
        public ActionType ActionType { get; set; }
        public string Details { get; set; }

        public class UpdateAdminActionCommandHandler : IRequestHandler<UpdateAdminActionCommand, UpdateAdminActionResponse>
        {
            private readonly IAdminActionRepository _adminActionRepository;
            private readonly IMapper _mapper;
            private readonly IAdminService _adminService;

            public UpdateAdminActionCommandHandler(IAdminActionRepository adminActionRepository, IMapper mapper, IAdminService adminService)
            {
                _adminActionRepository = adminActionRepository;
                _mapper = mapper;
                _adminService = adminService;
            }

            public async Task<UpdateAdminActionResponse> Handle(UpdateAdminActionCommand request, CancellationToken cancellationToken)
            {
                Admin? admin = await _adminService.GetByIdAsync(request.AdminId);
                if (admin == null)
                {
                    throw new Exception("No such admin data");
                }
                AdminAction? adminAction = await _adminActionRepository.GetAsync(aa => aa.Id == request.Id);
                if (adminAction == null)
                {
                    throw new Exception("No such adminAction data");
                }

                // AdminAction mapAdminAction = _mapper.Map<AdminAction>(request);
                _mapper.Map(request, adminAction);
                await _adminActionRepository.UpdateAsync(adminAction);

                UpdateAdminActionResponse response = _mapper.Map<UpdateAdminActionResponse>(adminAction);
                return response;
            }
        }
    }
}
