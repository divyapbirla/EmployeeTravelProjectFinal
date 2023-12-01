using ClassLibrary1;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClassLibrary_BAL
{
    public class Ticket_BAL: ITicket_BAL
    {
        private static readonly ReqDataManager ticket = new ReqDataManager();
        public int RaiseRequest_BAL(int req_id, int emp_id, DateTime req_date, string fromLocation, string toLocation, ApprovedStatus approve, BookingStatus bookingStatus)
        {
            ticket.RaiseRequest_DAL(req_id, emp_id, req_date, fromLocation, toLocation);
            return 1;
        }

        public int EditRequest_BAL(TravelRequest travelRequest)
        {
            ticket.EditRequest_DAL(travelRequest);
            return 1;
        }

        public int DeleteRequest_BAL(int reqId)
        {
            ticket.DeleteRequest_DAL(reqId);
            return 1;
        }
        public int ApproveRequest_BAL(int travel_id, ApprovedStatus appStatus)
        {
            ticket.ApproveRequest_DAL(travel_id,appStatus);


            return 1;
        }
        public int ConfirmRequest_BAL(int travel_id, BookingStatus bookStatus)
        {

            ticket.ConfirmRequest_DAL(travel_id, bookStatus,CurrentStatus.Open);

            return 1;
        }

        public TravelRequest GetRequestById_BAL(int req_id)
        {
            TravelRequest tr = ticket.GetRequestById_DAL(req_id);
            return tr;
        }
        public void ViewAllRequest_BAL()
        {
            ticket.ViewAllRequest();
        }

        public void ViewPendingApproveRequest_BAL()
        {
            ticket.ViewPendingApproveRequest_DAL();
        }

        public void ViewOpenApprovedRequestForBooking_BAL()
        {
            ticket.ViewOpenApprovedRequestForBooking_DAL();
        }
        public void JoinViewAll_BAL()
        {
            ticket.JoinViewAll_DAL();
        }

        public bool CheckPendingRequest_BAL()
        {
            return ticket.CheckPendingRequest_DAL();
            
        }

        public bool CheckPendingBooking_BAL()
        {
            return ticket.CheckPendingBooking_DAL();
        }



    }
}
