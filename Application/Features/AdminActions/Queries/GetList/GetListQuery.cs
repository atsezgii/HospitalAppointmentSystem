using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AdminActions.Queries.GetList
{
    public class GetListQuery : IRequest<List<GetAllAdminActionsResponse>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public class GetListQueryHandler : IRequestHandler<GetListQuery, List<GetAllAdminActionsResponse>>
        {
            private readonly IAdminActionRepository _adminActionRepository;
            private readonly IMapper _mapper;

            public GetListQueryHandler(IAdminActionRepository adminActionRepository, IMapper mapper)
            {
                _adminActionRepository = adminActionRepository;
                _mapper = mapper;
            }

            public async Task<List<GetAllAdminActionsResponse>> Handle(GetListQuery request, CancellationToken cancellationToken)
            {
                List<AdminAction> adminActions = await _adminActionRepository.GetListAsync();
                List<GetAllAdminActionsResponse> response = _mapper.Map<List<GetAllAdminActionsResponse>>(adminActions);
                return response.Where(a => a.isActive).ToList();
            }
        }
    }
}
