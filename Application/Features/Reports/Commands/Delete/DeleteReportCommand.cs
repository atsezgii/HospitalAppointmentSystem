using Application.Repositories;
using Domain.Entities;
using MediatR;

namespace Application.Features.Reports.Commands.Delete
{
    public class DeleteReportCommand : IRequest
    {
        public int Id { get; set; }
        public class DeleteReportCommandHandler : IRequestHandler<DeleteReportCommand>
        {
            private readonly IReportRepository _reportRepository;

            public DeleteReportCommandHandler(IReportRepository reportRepository)
            {
                _reportRepository = reportRepository;
            }

            public async Task Handle(DeleteReportCommand request, CancellationToken cancellationToken)
            {
                Report? report = await _reportRepository.GetAsync(r => r.Id == request.Id);
                if (report == null)
                {
                    throw new Exception("Data not found");
                }
                report.isActive = false;
                await _reportRepository.UpdateAsync(report);
            }
        }
    }
}
