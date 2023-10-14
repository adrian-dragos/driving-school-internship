using Application.DTOs.EntityDtos.Review;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BookingSessions.Queries.GetBookingSessionListWithoutReview
{
    public class GetBookingSessionListWithoutReviewQuery : IRequest<IEnumerable<ReviewDto>>
    {
        public int StudentId { get; set; }
    }
}
