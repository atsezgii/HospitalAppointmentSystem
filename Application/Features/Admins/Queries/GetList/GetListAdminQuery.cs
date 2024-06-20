using Application.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Admins.Queries.GetList
{
    public class GetListAdminQuery : IRequest<GetListResponse<GetListAdminResponse>>
    {
        public PageRequest PageRequest { get; set; }
        public class GetListAdminQueryHandler : IRequestHandler<GetListAdminQuery, GetListResponse<GetListAdminResponse>>
        {
            private readonly IAdminRepository _adminRepository;
            private readonly IMapper _mapper;

            public GetListAdminQueryHandler(IAdminRepository adminRepository, IMapper mapper)
            {
                _adminRepository = adminRepository;
                _mapper = mapper;
            }
            public async Task<GetListResponse<GetListAdminResponse>> Handle(GetListAdminQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Admin> admins = await _adminRepository.GetListAsync(
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize);
                var response = _mapper.Map<GetListResponse<GetListAdminResponse>>(admins);
                return response;
            }
        }
    }
}
