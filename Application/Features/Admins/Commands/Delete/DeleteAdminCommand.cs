using Application.Repositories;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Admins.Commands.Delete
{
    public class DeleteAdminCommand : IRequest
    {
        public int Id { get; set; }
        public class DeleteAdminCommandHandler : IRequestHandler<DeleteAdminCommand>
        {
            IAdminRepository _adminRepository;

            public DeleteAdminCommandHandler(IAdminRepository adminRepository)
            {
                _adminRepository = adminRepository;
            }

            public async Task Handle(DeleteAdminCommand request, CancellationToken cancellationToken)
            {
                Admin admin = await _adminRepository.GetAsync(a=>a.Id == request.Id); 
                if (admin == null)
                {
                    throw new Exception("Data not found");
                }
                await _adminRepository.DeleteAsync(admin);
            }
        }
    }
}
