using Application.Features.AdminActions.Queries.GetById;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Admins.Queries.GetById
{
    public class GetByIdQuery : IRequest<GetByIdAdminResponse>
    {
        public int Id { get; set; }
        public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, GetByIdAdminResponse>
        {
            private readonly IAdminRepository _adminRepository;
            private readonly IMapper _mapper;


            public GetByIdQueryHandler(IAdminRepository adminRepository, IMapper mapper)
            {
                _adminRepository = adminRepository;
                _mapper = mapper;
            }

            public async Task<GetByIdAdminResponse> Handle(GetByIdQuery request, CancellationToken cancellationToken)
            {
                Admin? admin = await _adminRepository.GetAsync(a => a.Id == request.Id);
                if (admin == null)
                {
                    throw new Exception("Data not found");
                }

                GetByIdAdminResponse response = _mapper.Map<GetByIdAdminResponse>(admin);
                return response;
            }
        }
    }
}
