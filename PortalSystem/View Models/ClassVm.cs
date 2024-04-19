using System.ComponentModel.DataAnnotations;

namespace PortalSystem.View_Models
{
    public class ClassVm
    {
        public int Id { get; set; }
        [Required( ErrorMessage = "Class Name is required")]
        public string ClassName { get; set; }
        [Required(ErrorMessage = "Grade Level is required")]
        public string GradeLevel { get; set; }
        [Required(ErrorMessage = "Timming is required")]
        public string Time { get; set; }
        public int RemainingSets { get; set; }
        [Required(ErrorMessage = "Max Size is required")]
        public int TotalSets { get; set; }
        public bool ChangeEnrollStatus { get; set; }
        public string? UserName { get; set; }
        public DateTime? EnrolledDate { get; set; }
        
    }
}
