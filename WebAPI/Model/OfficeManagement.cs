namespace WebAPI.Model
{
    public class OfficeManagement
    {
        public int Id { get; set; }

        public string EmployeeName { get; set; } = string.Empty;

        public string Task { get; set; } = string.Empty ;

        public string TaskCompleteBy { get; set; } = string .Empty ;

        public string IsTaskComplete { get; set; } = string.Empty;

    }
}
