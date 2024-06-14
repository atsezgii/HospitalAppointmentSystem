using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AdminActions.Queries.GetById
{
    public class GetByIdQuery : IRequest<GetByIdAdminActionResponse>
    {
        public int Id { get; set; }

        public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, GetByIdAdminActionResponse>
        {
            private readonly IAdminActionRepository _adminActionRepository;
            private readonly IMapper _mapper;


            public GetByIdQueryHandler(IAdminActionRepository adminActionRepository, IMapper mapper)
            {
                _adminActionRepository = adminActionRepository;
                _mapper = mapper;
            }

            public async Task<GetByIdAdminActionResponse> Handle(GetByIdQuery request, CancellationToken cancellationToken)
            {
                AdminAction? adminAction = await _adminActionRepository.GetAsync(a => a.Id == request.Id);
                if (adminAction == null)
                {
                    throw new Exception("Data not found");
                }

                GetByIdAdminActionResponse response = _mapper.Map<GetByIdAdminActionResponse>(adminAction);
                return response;
            }
        }
    }
}
