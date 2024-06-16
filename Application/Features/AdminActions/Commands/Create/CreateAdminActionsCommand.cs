using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AdminActions.Commands.Create
{
    public class CreateAdminActionsCommand  :IRequest<CreateAdminActionsResponse>
    {
        public int AdminId { get; set; }
        public ActionType ActionType { get; set; }
        public string ActionDescription { get; set; }
        public string Details { get; set; }
        public bool isActive { get; set; }


        public class CreateAdminActionsCommandHandler : IRequestHandler<CreateAdminActionsCommand, CreateAdminActionsResponse>
        {
            private readonly IAdminActionRepository _adminActionRepository;
            private readonly IMapper _mapper;

            public CreateAdminActionsCommandHandler(IMapper mapper, IAdminActionRepository adminActionRepository)
            {
                _mapper = mapper;
                _adminActionRepository = adminActionRepository;
            }

            public async Task<CreateAdminActionsResponse> Handle(CreateAdminActionsCommand request, CancellationToken cancellationToken)
            {
                AdminAction adminAction = _mapper.Map<AdminAction>(request);
                await _adminActionRepository.AddAsync(adminAction);
                CreateAdminActionsResponse response = _mapper.Map<CreateAdminActionsResponse>(adminAction);
                return response;
            }
        }
    }
}
