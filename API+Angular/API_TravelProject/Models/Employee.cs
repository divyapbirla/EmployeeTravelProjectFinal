
using System.ComponentModel.DataAnnotations;

namespace API_TravelProject.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        public string? EmployeeName { get; set; }
        
        public int? Contact { get; set; }
        public string? Address { get; set; }
        public string? Dept { get; set; }
        public DateTime? DOB { get; set; }

        public virtual ICollection<TravelRequest>? TravelRequests { get; set; }
    }
}
