using Application.Repositories;
using Domain.Entities;
using MediatR;

namespace Application.Features.Departments.Commands.Delete
{
    public class DeleteDepartmentCommand : IRequest
    {
        public int Id { get; set; }

        public class DeleteDepartmentCommandHandler : IRequestHandler<DeleteDepartmentCommand>
        {
            private readonly IDepartmentRepository _departmentRepository;

            public DeleteDepartmentCommandHandler(IDepartmentRepository departmentRepository)
            {
                _departmentRepository = departmentRepository;
            }

            public async Task Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
            {
                Department department = await _departmentRepository.GetAsync(d=>d.Id == request.Id);    
                if (department == null) 
                {
                    throw new Exception("Data not found");
                }
                department.isActive = false;
                await _departmentRepository.UpdateAsync(department);
            }
        }
    }
}
