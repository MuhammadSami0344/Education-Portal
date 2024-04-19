namespace PortalSystem.View_Models
{
    public class EnrollVm
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int ClassId { get; set; }
        public DateTime? UserEnrolledDate { get; set; }
        public bool EnrollStatus { get; set; }
    }
}
