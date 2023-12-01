using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;



namespace DataAccessLayer
{
    public class ReqDataManager : IReqDataManager
        
    {
        EmpDataManager empDataManager=new EmpDataManager();
        List<TravelRequest> lsttravel = new List<TravelRequest>()
        {
           new TravelRequest(){reqID = 10,empID=001,Date=DateTime.Parse("03-07-2001"),fromLocation ="solapur",toLocation="Mumbai",approve=ApprovedStatus.Approved,bookingStatus=BookingStatus.Pending,currentStatus=CurrentStatus.Open},
            new TravelRequest(){reqID = 20,empID=002,Date=DateTime.Parse("03-07-2001"),fromLocation ="sangali",toLocation="karad",approve=ApprovedStatus.Approved,bookingStatus=BookingStatus.Not_Available,currentStatus=CurrentStatus.Close},
            new TravelRequest(){reqID = 30,empID=003,Date=DateTime.Parse("03-07-2001"),fromLocation ="satara",toLocation="pune",approve=ApprovedStatus.Pending,bookingStatus=BookingStatus.Pending,currentStatus=CurrentStatus.Open},
            new TravelRequest(){reqID = 40,empID=004,Date=DateTime.Parse("04-05-2001"),fromLocation ="borivali",toLocation="amravati",approve=ApprovedStatus.Not_Approved,bookingStatus=BookingStatus.Pending,currentStatus=CurrentStatus.Close},

        };

       
        public int RaiseRequest_DAL(int req_ID, int emp_ID, DateTime date, string fromLocation, string toLocation)

        {
            
            // Check if the request ID already exists
            if (lsttravel.Any(req => req.reqID == req_ID))
            {
                Console.WriteLine("Request ID already exists. Please choose another.");
                return 0;
            }

            // Check if the employee ID exists
            if (!empDataManager.lstEmployees.Any(emp => emp.EmployeeID == emp_ID))
            {
                Console.WriteLine("Employee ID does not exist. Please enter a valid Employee ID.");
                return 0;
            }
            lsttravel.Add(new TravelRequest { reqID = req_ID, empID = emp_ID, fromLocation = fromLocation, toLocation = toLocation, Date = date, approve = ApprovedStatus.Pending, bookingStatus = BookingStatus.Pending, currentStatus = CurrentStatus.Open });
            return 1;

           
        }



        public int EditRequest_DAL(TravelRequest travelRequest)
        {
            //Console.WriteLine("In Edit - DAL");

            TravelRequest travelreq_Main = lsttravel.FirstOrDefault(X => X.reqID == travelRequest.reqID);
            if (travelreq_Main != null)
            { 
                int index = lsttravel.IndexOf(travelreq_Main);

                lsttravel[index].empID = travelRequest.empID;
                lsttravel[index].toLocation = travelRequest.toLocation;
                lsttravel[index].fromLocation = travelRequest.fromLocation;
                lsttravel[index].approve = travelRequest.approve;
                lsttravel[index].bookingStatus = travelRequest.bookingStatus;

                return 1;
            }
            else
            {
                Console.WriteLine("Request Id Not Found");
               
            }
            ViewAllRequest();
            return 1;
        }

        public int DeleteRequest_DAL(int req_ID)
        {
            TravelRequest tr = lsttravel.FirstOrDefault(t => t.reqID == req_ID);
            if (tr != null)
            {
                lsttravel.Remove(tr);
                Console.WriteLine("Request Data deleted successfully");
            }
            else
            {
                Console.WriteLine("Request ID not found,Enter valid request Id");
            }
           ViewAllRequest();
            return 1;
        }



       public int ApproveRequest_DAL(int travel_id, ApprovedStatus appStatus)
        {
            Console.WriteLine("Employee with request_ID{0} Booking Confirmed..", travel_id);
            TravelRequest atr = lsttravel.FirstOrDefault(x => x.reqID == travel_id);
            int index = lsttravel.IndexOf(atr);
            if (atr != null)
            {
                lsttravel[index].approve = appStatus;
                lsttravel[index].currentStatus = CurrentStatus.Open;
                if (appStatus == ApprovedStatus.Not_Approved)
                {
                    lsttravel[index].currentStatus = CurrentStatus.Close;
                }
                //ViewAllRequest();

            }
            return 1;
        }

       
       public int ConfirmRequest_DAL(int travel_id, BookingStatus bookStatus,CurrentStatus currentstatus)
        {
            Console.WriteLine("Employee with request_ID{0} Booking Confirmed..",travel_id); 
            TravelRequest ctr = lsttravel.FirstOrDefault(x => x.reqID== travel_id);
            int index = lsttravel.IndexOf(ctr);
            if(ctr != null)
            {
                lsttravel[index].bookingStatus=bookStatus;
                //lsttravel[index].currentStatus = currentstatus;
                currentstatus = CurrentStatus.Open;
                if (bookStatus == BookingStatus.Not_Available || bookStatus == BookingStatus.Available)
                {
                    lsttravel[index].currentStatus = CurrentStatus.Close;
                }

            }
            return 1;
        }
       public void ViewAllRequest()
        {

            Console.WriteLine("********************************************************************************************************************************************************************");
            Console.WriteLine("{0,75}", "View All Travel Request");
            //Console.WriteLine("********************************************************************************************************************************************************************");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("{0,-20}{1,-20}{2,-20}{3,20}{4,20}{5,20}{6,20}{7,20}", "ReqID", "EmpID", "Date", "FromLocation", "ToLocation","Approve","BookingStatus","CurrentStatus");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            
            foreach (TravelRequest lt in lsttravel)
            {
                Console.WriteLine("{0,-20}{1,-20}{2,-20}{3,20}{4,20}{5,20}{6,20}{7,20}", lt.reqID, lt.empID, lt.Date,lt.fromLocation,lt.toLocation,lt.approve,lt.bookingStatus,lt.currentStatus);
            }
            
        }

        public TravelRequest GetRequestById_DAL(int req_id)
        {
            TravelRequest TravelReq = lsttravel.FirstOrDefault(t => t.reqID == req_id);

            if (TravelReq != null)
            {
               return TravelReq;
            }
            return null;
        }

        public void JoinViewAll_DAL()
        {
            var queryMethodView = from emp in empDataManager.lstEmployees
                                  join req in lsttravel
                                  on emp.EmployeeID equals req.empID
                                  select new
                                  {
                                      EID = emp.EmployeeID,
                                      ReqID = req.reqID,
                                      EfirstName = emp.FirstName,
                                      ElastName = emp.LastName,
                                      EContact = emp.Contact,
                                      EAddress = emp.Address,
                                      EDept = emp.Dept,
                                      EDob = emp.DOB,
                                      Floc = req.fromLocation,
                                      Tloc = req.toLocation,
                                      ApprovedStatus = req.approve,
                                      BookingStatus = req.bookingStatus,
                                      CurrentStatus = req.currentStatus,
                                  };
           Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("{0,-20}{1,-20}{2,-20}{3,-20}{4,-20}{5,-20}{6,-20}{7,-20}{8,-20}", "EmployeeID", "RequestID", "FirstName", "LastName","FromLocation","ToLocation","Approve","BookingStatus","CurrentStatus");
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            foreach (var request in queryMethodView) 
            {
                
                Console.WriteLine("{0,-20}{1,-20}{2,-20}{3,-20}{4,-20}{5,-20}{6,-20}{7,-20}{8,-20}", request.EID, request.ReqID, request.EfirstName, request.ElastName,request.Floc,request.Tloc,request.ApprovedStatus,request.BookingStatus,request.CurrentStatus);
            }

        }


        public void ViewPendingApproveRequest_DAL()
        {
            Console.WriteLine("\n");
            Console.WriteLine("********************************************************* Travel Request Details  *************************************************************************************");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("{0,-20}{1,-20}{2,-20}{3,-20}{4,-20}{5,-20}{6,-20}{7,-20}", " req_id ", "emp_id", " req_date", "fromLocation", " toLocation", "approve", "bookingStatus", "currentStatus");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------");


            foreach (TravelRequest req in lsttravel)
            {
                if (req.approve == ApprovedStatus.Pending)
                    Console.WriteLine("{0,-20}{1,-20}{2,-20}{3,-20}{4,-20}{5,-20}{6,-20}{7,-20}", req.reqID, req.empID, req.Date, req.fromLocation, req.toLocation, req.approve, req.bookingStatus, req.currentStatus);
            }
        }

        public bool CheckPendingRequest_DAL()
        {
            return lsttravel.Any(req=>req.approve== ApprovedStatus.Pending);
        }

        public bool CheckPendingBooking_DAL()
        {
            return lsttravel.Any(req => req.bookingStatus == BookingStatus.Pending);
        }

        public void ViewOpenApprovedRequestForBooking_DAL()

        {

            Console.WriteLine("\n");

            Console.WriteLine("******************************************************************** Travel Request Details  **************************************************************************");

            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------");

            Console.WriteLine("{0,-20}{1,-20}{2,-20}{3,-20}{4,-20}{5,-20}{6,-20}{7,-20}", " req_id ", "emp_id", " req_date", "fromLocation", " toLocation", "approve", "bookingStatus", "currentStatus");

            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------");


            foreach (TravelRequest req in lsttravel)

            {

                if (req.approve == ApprovedStatus.Approved  && req.currentStatus == CurrentStatus.Open)

                    Console.WriteLine("{0,-20}{1,-20}{2,-20}{3,-20}{4,-20}{5,-20}{6,-20}{7,-20}", req.reqID, req.empID, req.Date, req.fromLocation, req.toLocation, req.approve, req.bookingStatus, req.currentStatus);

            }

        }
    }
}


