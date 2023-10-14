using Application.DTOs.EntityDtos.Review;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BookingSessions.Queries.GetBookingSessionListWithoutReview
{
    public class GetBookingSessionListWithoutReviewQueryHandler : IRequestHandler<GetBookingSessionListWithoutReviewQuery, IEnumerable<ReviewDto>>
    {
        public Task<IEnumerable<ReviewDto>> Handle(GetBookingSessionListWithoutReviewQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
