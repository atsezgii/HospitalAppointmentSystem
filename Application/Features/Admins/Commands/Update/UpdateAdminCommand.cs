using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.Features.Admins.Commands.Update
{
    public class UpdateAdminCommand : IRequest<UpdateAdminResponse>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
        public string PhotoUrl { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string Password { get; set; }

        public class UpdateAdminCommandHandler : IRequestHandler<UpdateAdminCommand, UpdateAdminResponse>
        {
            private readonly IAdminRepository _adminRepository;
            private readonly IMapper _mapper;

            public UpdateAdminCommandHandler(IAdminRepository adminRepository, IMapper mapper)
            {
                _adminRepository = adminRepository;
                _mapper = mapper;
            }

            public async Task<UpdateAdminResponse> Handle(UpdateAdminCommand request, CancellationToken cancellationToken)
            {
                Admin? admin = await _adminRepository.GetAsync(a => a.Id == request.Id);
                if (admin == null)
                {
                    throw new Exception("No such admin data");
                }
                _mapper.Map(request, admin);
                await _adminRepository.UpdateAsync(admin);
                UpdateAdminResponse response = _mapper.Map<UpdateAdminResponse>(admin); 
                return response;    
            }
        }
    }
}
