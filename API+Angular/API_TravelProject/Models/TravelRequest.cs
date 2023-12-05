using System.ComponentModel.DataAnnotations;

namespace API_TravelProject.Models
{
   public class TravelRequest
   {
       [Key]
       public int RequestId { get; set; }
        public int? EmployeeId { get; set; }
       public DateTime? Date1 { get; set; }
       public string? FromDestination { get; set; }
        public string? ToDestination { get; set; }
        public string? Approve { get; set; }
       public string? BookingStatus { get; set; }
        public string? CurrentStatus { get; set; }

      public virtual Employee? Employee { get; set; }
    }
}
