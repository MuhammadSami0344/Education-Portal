namespace PortalSystem.Models
{
    public class EnrolledUsers : BaseModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int ClassId { get; set; }
        public DateTime? UserEnrolledDate { get; set; }
        public bool EnrollStatus { get; set; }

    }
}
