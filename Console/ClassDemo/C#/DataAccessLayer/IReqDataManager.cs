using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;

namespace DataAccessLayer
{
    public interface IReqDataManager
    {
        int RaiseRequest_DAL(int req_id,int emp_id,DateTime req_date,string fromLocation,string toLocation);

        int EditRequest_DAL(TravelRequest travelRequest);

        int DeleteRequest_DAL(int req_id);

        int ApproveRequest_DAL(int travel_id, ApprovedStatus appstatus);

       
        int ConfirmRequest_DAL(int travel_id, BookingStatus bookstatus, CurrentStatus currentstatus);

        TravelRequest GetRequestById_DAL(int req_id);

        void ViewPendingApproveRequest_DAL();

        bool CheckPendingRequest_DAL();

        bool CheckPendingBooking_DAL();

        void ViewOpenApprovedRequestForBooking_DAL();
    }
}
