using Application.DTOs.EntityDtos.Person.Instructor;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Instructors.Commands.UpdateEmploymentStatus
{
    public class UpdateInstructorHandler : IRequestHandler<UpdateInstructorCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateInstructorHandler(
            IUnitOfWork unitOfWork,
             IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateInstructorCommand command, CancellationToken cancellationToken)
        {
            var instructor = await _unitOfWork.Instructors.GetByIdAsync(command.Id);

            if (command.ChangeInstructorEmploymentStatus != null)
            {
                _mapper.Map(command.ChangeInstructorEmploymentStatus, instructor);
            }
            
            if (command.ChangeInstructorCarDto != null)
            {
                _mapper.Map(command.ChangeInstructorCarDto, instructor);
            }

            await _unitOfWork.Instructors.Update(instructor);
            await _unitOfWork.SaveAsync();
            return Unit.Value;
        }
    }
}
