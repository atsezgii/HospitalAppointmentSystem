using Application.Repositories;
using Domain.Entities;
using MediatR;

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
                admin.isActive = false;
                await _adminRepository.UpdateAsync(admin);
            }
        }
    }
}
