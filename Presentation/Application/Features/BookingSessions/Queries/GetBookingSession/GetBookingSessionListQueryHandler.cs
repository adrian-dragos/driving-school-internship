using Application.Dtos.BookingSession;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Features.Application.BookingSessions.Queries.GetBookingSession
{
    public class GetBookingSessionListQueryHandler : IRequestHandler<GetBookingSessionListQuery, IEnumerable<BookingSessionDto>>
    {
        private readonly IBookingSessionRepository _repository;
        private readonly IMapper _mapper;

        public GetBookingSessionListQueryHandler(IBookingSessionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookingSessionDto>> Handle(GetBookingSessionListQuery query, CancellationToken cancellationToken)
        {
            var bookingSession = await _repository.GetAll();
            return _mapper.Map<List<BookingSessionDto>>(bookingSession);            
        }
    }
}
