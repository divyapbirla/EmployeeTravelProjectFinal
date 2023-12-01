using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{

    public enum ApprovedStatus {Approved,Not_Approved, Pending };
    public enum BookingStatus { Available, Not_Available,Pending };
    public enum CurrentStatus { Open,Close };
    public class TravelRequest
    {
        public int empID {  get; set; }
        public int reqID {  get; set; }
        public string fromLocation { get; set; }
        public string toLocation { get; set; }
       public  DateTime Date {  get; set; }
        public ApprovedStatus approve {  get; set; }
        public BookingStatus bookingStatus {  get; set; }
        public CurrentStatus currentStatus { get; set; }

        public override string ToString()
        {
            return string.Format("EmployeeID:{0}, RequestID:{1},Date:{2},FromLocation:{3},ToLocation:{4}, ApproveStatus:{5},BookinStatus:{6},CurrentStatus:{7}", empID,reqID,Date,fromLocation,toLocation,approve,bookingStatus,currentStatus);
        }
    }
}
