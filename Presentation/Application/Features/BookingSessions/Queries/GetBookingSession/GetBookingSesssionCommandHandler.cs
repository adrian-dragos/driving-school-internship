using Application.DTOs.EntityDto.BookingSession;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BookingSessions.Queries.GetBookingSession
{
    public class GetBookingSessionQueryHandler : IRequestHandler<GetBookingSessionQuery, BookingSessionDto>
    {
        private readonly IBookingSessionRepository _repostitory;
        private readonly IMapper _mapper;

        public GetBookingSessionQueryHandler(IBookingSessionRepository repostitory, IMapper mapper)
        {
            _repostitory = repostitory;
            _mapper = mapper;
        }

        public async Task<BookingSessionDto> Handle(GetBookingSessionQuery query, CancellationToken cancellationToken)
        {
            var bookingSession = await _repostitory.GetByIdAsync(query.Id);
            return _mapper.Map<BookingSessionDto>(bookingSession);
        }
    }
}
