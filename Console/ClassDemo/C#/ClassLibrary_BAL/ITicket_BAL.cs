using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClassLibrary_BAL
{
    public interface ITicket_BAL
    {
        int RaiseRequest_BAL(int req_id, int emp_id, DateTime req_date, string fromLocation, string toLocation, ApprovedStatus approve, BookingStatus bookingStatus);

        int EditRequest_BAL(TravelRequest travelRequest);
        int DeleteRequest_BAL(int reqId);

        int ApproveRequest_BAL(int travel_id, ApprovedStatus appStatus);
        int ConfirmRequest_BAL(int travel_id, BookingStatus bookStatus);
        void ViewAllRequest_BAL();

        void ViewPendingApproveRequest_BAL();

        bool CheckPendingRequest_BAL();

        bool CheckPendingBooking_BAL();

        void ViewOpenApprovedRequestForBooking_BAL();
        TravelRequest GetRequestById_BAL(int req_id);
    }
}
