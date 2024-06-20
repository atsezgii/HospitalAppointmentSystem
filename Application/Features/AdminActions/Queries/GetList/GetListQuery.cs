using Application.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;

namespace Application.Features.AdminActions.Queries.GetList
{
    public class GetListQuery : IRequest<GetListResponse<GetAllAdminActionsResponse>>
    {
        public PageRequest PageRequest { get; set; }
        public class GetListQueryHandler : IRequestHandler<GetListQuery, GetListResponse<GetAllAdminActionsResponse>>
        {
            private readonly IAdminActionRepository _adminActionRepository;
            private readonly IMapper _mapper;

            public GetListQueryHandler(IAdminActionRepository adminActionRepository, IMapper mapper)
            {
                _adminActionRepository = adminActionRepository;
                _mapper = mapper;
            }

            public async Task<GetListResponse<GetAllAdminActionsResponse>> Handle(GetListQuery request, CancellationToken cancellationToken)
            {
                IPaginate<AdminAction> adminActions = await _adminActionRepository.GetListAsync(
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize);
                var response = _mapper.Map<GetListResponse<GetAllAdminActionsResponse>>(adminActions);
                return response;
            }
        }
    }
}
