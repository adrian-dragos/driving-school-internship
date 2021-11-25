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
        private readonly IInstructorRepository _repository;
        private readonly IMapper _mapper;

        public GetInstructorsListQueryHandler(IInstructorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

       
        public async Task<IEnumerable<InstructorViewModel>> Handle(GetInstructorsListQuery query, CancellationToken cancellationToken)
        {
            var instructor = await _repository.GetAll();
            return _mapper.Map<List<InstructorViewModel>>(instructor);
        }
    }
}
