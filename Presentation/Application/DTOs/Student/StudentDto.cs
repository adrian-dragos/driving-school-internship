namespace Application.DTOs.Student
{
    public class StudentDto : BaseEntityDto
    {
        public string Name { get; set; }
        public int? BookingSessionId { get; set; }
    }
}
