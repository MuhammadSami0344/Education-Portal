namespace PortalSystem.Models
{
    public class TblClass : BaseModel
    {
        public string ClassName { get; set; }
        public string GradeLevel { get; set; }
        public string Time { get; set; }
        public int RemainingSets { get; set; }
        public int TotalSets { get; set; }
    }
}
