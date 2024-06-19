using Application.Repositories;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AdminActions.Commands.Delete
{
    public class DeleteAdminActionsCommand : IRequest
    {
        public int Id { get; set; }

        public class DeleteAdminActionsCommandHandler : IRequestHandler<DeleteAdminActionsCommand>
        {
            IAdminActionRepository _adminActionRepository;
            public DeleteAdminActionsCommandHandler(IAdminActionRepository adminActionRepository)
            {
                _adminActionRepository = adminActionRepository;             
            }
            public async Task Handle(DeleteAdminActionsCommand request, CancellationToken cancellationToken)
            {
                AdminAction? adminAction = await _adminActionRepository.GetAsync(a => a.Id == request.Id);
                if (adminAction == null)
                {
                    throw new Exception("Data not found");

                }
                adminAction.isActive = false;
                await _adminActionRepository.UpdateAsync(adminAction);
            }
        }
    }
}
