using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Instructors.Quieries.GetInstructorsList
{
    public class GetInstructorsListQueryHandler : IRequestHandler<GetInstructorsListQuery, IEnumerable<InstructorViewModel>>
    {
        //private readonly IInstructorRepository _repository;
        private readonly IGenericRepository<Instructor> _repository;  
        private readonly IMapper _mapper;

        public GetInstructorsListQueryHandler(IGenericRepository<Instructor> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

       
        public async Task<IEnumerable<InstructorViewModel>> Handle(GetInstructorsListQuery query, CancellationToken cancellationToken)
        {
            //var result = _repository.GetInstructors().Select(instructor => new InstructorViewModel
            //{
            //    BookingSessionId = instructor.BookingSessionId,
            //    Name = instructor.Name
            //});

            //return Task.FromResult(result);

            var instructor = await _repository.GetAll();
            return _mapper.Map<List<InstructorViewModel>>(instructor);
        }
    }
}
