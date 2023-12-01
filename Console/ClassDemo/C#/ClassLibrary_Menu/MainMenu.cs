using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary_BAL;
using ClassLibrary1;


namespace ClassLibrary_Menu
{
    public class MainMenu
    {
        //create object on top instead od each method
        private static readonly Employee_BAL emp_BAL = new Employee_BAL();

        private static readonly Ticket_BAL ticket_BAL = new Ticket_BAL();
        // public static int incrementid = 5;
        // public static int incrementrid = 10;
        public static void ShowMain()
        {

            Console.WriteLine("--------- Main Menu ----------");
            int choices;
            Console.WriteLine("Select Choice");
            Console.WriteLine("1. Manage Employee");
            Console.WriteLine("2. Manage Travel Request");
            Console.WriteLine("3. Exit Application");
            choices = int.Parse(Console.ReadLine());
            switch (choices)
            {
                case 1:
                    ShowEmployeeMgmt();
                    break;
                case 2:
                    ShowTravelManagement();
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;



            }
        }

        public static void ShowEmployeeMgmt()
        {

            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Manage Employee");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Enter your process: ");
            Console.WriteLine("1. Add \n2. Edit \n3. Delete \n4. View \n5. Go Back to Main Menu \n6.Exit");
            Console.WriteLine("enter a Sr. No 1-6 for process");



            int choice1 = int.Parse(Console.ReadLine());
            switch (choice1)
            {
                case 1:
                    ShowAddEmployee();
                    break;



                case 2:
                    ShowEditEmployee();
                    break;



                case 3:
                    ShowDeleteEmployee();
                    break;



                case 4:
                    ShowViewEmployee();
                    ShowEmployeeMgmt();

                    break;

                case 5:
                    ShowMain();
                    break;
                case 6:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid Choice");

                    break;
            }

        }

        public static void ShowTravelManagement()
        {
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Manage Travel Request");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Enter your choice");
            Console.WriteLine("1. Raise Travel Request \n2. View Travel Request \n3. Delete Travel Request  \n4. Edit Travel Request \n5. Approve Travel Request  \n6.Confirm Booking  \n7. Go Back to Main Menu \n8.Exit ");
            int choice2;

            choice2 = int.Parse(Console.ReadLine());



            switch (choice2)
            {
                case 1:
                    ShowRaiseTravelRequest();
                    break;
                case 2:
                    ShowViewAllTravelRequest();
                    ShowTravelManagement();
                    break;
                case 3:
                    ShowDeleteTravelRequest();
                    break;
                case 4:
                    //Console.WriteLine("Approve_Travel_Request");
                    ShowEditTravelRequest();
                    break;
                case 5:
                    //Console.WriteLine("Approve_Travel_Request");
                    ShowApproveTravelRequest();
                    break;
                case 6:
                    //Console.WriteLine("Confirm Booking");
                    ShowConfirmBooking();
                    break;
                case 7:
                    // Go back to the main menu (do nothing here).
                    ShowMain();
                    break;
                case 8:
                    Console.WriteLine("Exiting the application. Goodbye!");
                    return;


            }
        }

        public static void ShowAddEmployee()
        {
            try
            {

                int EmployeeID;
                String FirstName;
                String LastName;
                int Contact;
                String Address;
                String Dept;
                DateTime DOB;
                Console.WriteLine("Add Employee details");
                Console.WriteLine("Enter Employee Id");
                EmployeeID = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Employee FirstName");
                FirstName = Console.ReadLine();
                Console.WriteLine("Enter Employee LastName");
                LastName = Console.ReadLine();
                Console.WriteLine("Enter Employee Contact");
                Contact = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Employee Address");
                Address = (Console.ReadLine());
                Console.WriteLine("Enter Employee Department");
                Dept = Console.ReadLine();
                Console.WriteLine("Enter Employee DOB");
                DOB = DateTime.Parse(Console.ReadLine());


                emp_BAL.AddEmployee_BAL(EmployeeID, FirstName, LastName, Contact, Address, Dept, DOB);
                emp_BAL.ViewEmployee_BAL();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
            }
            ShowEmployeeMgmt();
        }


        public static void ShowEditEmployee()
        {
            try
            {
                int editEmployeeID;
                String editFirstName;
                String editLastName;
                int editContact;
                String editAddress;
                String editDept;
                DateTime editDOB;
                Console.WriteLine("----------------------------");
                Console.WriteLine("Edit Employee");
                Console.WriteLine("----------------------------");

                Console.WriteLine("Display all Employees");
                emp_BAL.ViewEmployee_BAL();
                Console.WriteLine("Enter Employee Id to Edit");
                editEmployeeID = int.Parse(Console.ReadLine());

                //Employee_BAL employee_BAL = new Employee_BAL();

                Employee emp_to_Change = emp_BAL.GetEmployeeById_BAL(editEmployeeID);

                emp_BAL.EditEmployee_BAL(emp_to_Change);

                while (true)
                {
                    Console.WriteLine("Enter Field no. to Edit");
                    Console.WriteLine("1. First Name \n2. Last Name \n3. Contact \n4. Address \n5. Department \n6. DOB \n7.Go back to Employee Management \n8.Go back to main Menu \n9. Exit");
                    int choice;
                    choice = int.Parse(Console.ReadLine());


                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Enter Employee FirstName");
                            editFirstName = Console.ReadLine();
                            emp_to_Change.FirstName = editFirstName;
                            break;
                        case 2:
                            Console.WriteLine("Enter Employee LastName");
                            editLastName = Console.ReadLine();
                            emp_to_Change.LastName = editLastName;
                            break;
                        case 3:
                            Console.WriteLine("Enter Employee Contact");
                            editContact = int.Parse(Console.ReadLine());
                            emp_to_Change.Contact = editContact;
                            break;
                        case 4:
                            Console.WriteLine("Enter Employee Address");
                            editAddress = (Console.ReadLine());
                            emp_to_Change.Address = editAddress;
                            break;
                        case 5:
                            Console.WriteLine("Enter Employee Department");
                            editDept = Console.ReadLine();
                            emp_to_Change.Dept = editDept;
                            break;
                        case 6:
                            Console.WriteLine("Enter Employee DOB");
                            editDOB = DateTime.Parse(Console.ReadLine());
                            emp_to_Change.DOB = editDOB;
                            break;
                        case 7:
                            ShowEmployeeMgmt();
                            break;
                        case 8:
                            ShowMain();
                            break;
                        default:
                            Console.WriteLine("Invalid Choice");
                            break;

                    }
                    emp_BAL.ViewEmployee_BAL();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Enter valid Employee Id");
            }
            ShowEmployeeMgmt();

        }

        public static void ShowDeleteEmployee()
        {
            try
            {
                Employee_BAL employee_BAL = new Employee_BAL();
                employee_BAL.ViewEmployee_BAL();
                int EmployeeID;
                Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("Enter Employee Id");
                EmployeeID = int.Parse(Console.ReadLine());
                employee_BAL.DeleteEmployee_BAL(EmployeeID);
                //Console.WriteLine("Data deleted successfully");
                ShowEmployeeMgmt();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Enter valid Employee Id" + ex.Message);
            }
            ShowEmployeeMgmt();

        }

        public static void ShowViewEmployee()
        {
            Console.WriteLine("List of all Employees");
            Employee_BAL employee_BAL = new Employee_BAL();
            employee_BAL.ViewEmployee_BAL();
            // ShowEmployeeMgmt();
        }

        public static void ShowRaiseTravelRequest()
        {
            //try
            //{
            //    int req_id;
            //    int emp_id;
            //    DateTime req_date;
            //    String fromLocation;
            //    String toLocation;
            //    ApprovedStatus approve;
            //    BookingStatus bookingStatus;

            //    Console.WriteLine("--------  Raise a Ticket  ----------");
            //    // Console.WriteLine("Enter Employee Id");
            //    // emp_id = int.Parse(Console.ReadLine());
            //    Console.WriteLine("Request ID");
                //    req_id = int.Parse(Console.ReadLine());

                //    Console.WriteLine("Enter Request Date");
                //    req_date = DateTime.Parse(Console.ReadLine());
                //    Console.WriteLine("Enter pickup Location");
                //    fromLocation = Console.ReadLine();
                //    Console.WriteLine("Enter Destination Location");
                //    toLocation = (Console.ReadLine());

                //    ticket_BAL.RaiseRequest_BAL(req_id, emp_id, req_date, fromLocation, toLocation, approve = ApprovedStatus.Approved, bookingStatus = BookingStatus.Available);
                //    ticket_BAL.ViewAllRequest_BAL();
                //    ShowTravelManagement();
                //} catch(Exception ex)
                //{
                //    Console.WriteLine("Error" + ex.Message);
                //}

                // new codeeee startsss

                try
                {
                    int emp_id;
                    int req_id;
                    string fromLocation;
                    string toLocation;
                    DateTime date;
                    ApprovedStatus approve;
                    BookingStatus booking;

                    Console.WriteLine("--------  Raise a Ticket  ----------");

                    Console.WriteLine("Request ID:");
                    if (int.TryParse(Console.ReadLine(), out req_id))
                    {
                        Console.WriteLine("Enter Employee Id:");
                        if (int.TryParse(Console.ReadLine(), out emp_id))
                        {
                            Console.WriteLine("Enter Origin Location:");
                            fromLocation = Console.ReadLine();
                            Console.WriteLine("Enter Destination Location:");
                            toLocation = Console.ReadLine();
                            Console.WriteLine("Enter Date (YYYY-MM-DD):");
                            if (DateTime.TryParse(Console.ReadLine(), out date))
                            {
                                ticket_BAL.RaiseRequest_BAL(req_id, emp_id, date, fromLocation, toLocation, approve = ApprovedStatus.Pending, booking = BookingStatus.Pending);
                                ticket_BAL.ViewAllRequest_BAL();
                                ShowTravelManagement();
                            }
                            else
                            {
                                Console.WriteLine("Invalid date format. Please enter a valid date (YYYY-MM-DD).");
                                ShowRaiseTravelRequest();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid Employee ID. Please enter a number.");
                            ShowRaiseTravelRequest();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid Request ID. Please enter a number.");
                        ShowRaiseTravelRequest();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }

                // new code endsss

            }


        public static void ShowEditTravelRequest()
        {
            try
            {
                //int req_id;
                int emp_id;
                DateTime req_date;
                String fromLocation;
                String toLocation;
                Console.WriteLine("----------------------------");
                Console.WriteLine("Edit Travel Request");
                Console.WriteLine("----------------------------");
                Console.WriteLine("Display all travel request");
                ticket_BAL.ViewAllRequest_BAL();
                Console.WriteLine("Enter RequestID to Edit");
                // req_id = int.Parse(Console.ReadLine());

                //TravelRequest travel_to_change = ticket_BAL.GetRequestById_BAL(req_id);
                //ticket_BAL.EditRequest_BAL(travel_to_change);
                //while (true)
                //{
                //    Console.WriteLine("\n1.Enter From Location \n 2.Enter To Location \n 3.Date \n 4.Exit \n 5.Go Back to Travel Management");
                //    Console.WriteLine("Enter field no. to Edit");
                //    int choice;
                //    choice = int.Parse(Console.ReadLine());

                //        switch (choice)
                //        {
                //            case 1:
                //                Console.WriteLine("Enter From Location");
                //                fromLocation = Console.ReadLine();
                //                travel_to_change.fromLocation = fromLocation;
                //                break;
                //            case 2:
                //                Console.WriteLine("Enter To Location");
                //                toLocation = Console.ReadLine();
                //                travel_to_change.toLocation = toLocation;
                //                break;
                //            case 3:
                //                Console.WriteLine("Enter Date");
                //                req_date = DateTime.Parse(Console.ReadLine());
                //                travel_to_change.Date = req_date;
                //                break;
                //            case 4:
                //                Console.WriteLine("Exit");
                //                return;
                //            case 5:
                //                Console.WriteLine("Go Back to Travel Management");
                //                ShowTravelManagement();
                //                break;

                //            default:
                //               Console.WriteLine("Invalid Choice");
                //                break;
                //        }

                //        ticket_BAL.ViewAllRequest_BAL();
                //        //ShowEditTravelRequest();
                //    }
                //}
                ///neww codeeee start
                if (int.TryParse(Console.ReadLine(), out int req_id))
                {
                    if (req_id == 0)
                    {
                        Console.WriteLine("Going back to Travel Management.");
                        ShowTravelManagement(); // Go back to the Travel Management menu
                    }
                    else
                    {
                        TravelRequest req_to_change = ticket_BAL.GetRequestById_BAL(req_id);
                        if (req_to_change != null)
                        {
                            // Console.WriteLine("Request found. Editing Request ID: " + req_id + " Enter another request ID.");
                            while (true)
                            {
                                Console.WriteLine("1. From Location\n2. To Location\n3. Date\n4. Go Back\n5. Exit");
                                Console.WriteLine("Enter field number:");

                                if (int.TryParse(Console.ReadLine(), out int choice))
                                {
                                    switch (choice)
                                    {
                                        // Editing options
                                        case 1:
                                            Console.WriteLine("Enter From Location:");
                                            req_to_change.fromLocation = Console.ReadLine();
                                            break;
                                        case 2:
                                            Console.WriteLine("Enter To Location:");
                                            req_to_change.toLocation = Console.ReadLine();
                                            break;
                                        case 3:
                                            Console.WriteLine("Enter Date:");
                                            if (DateTime.TryParse(Console.ReadLine(), out DateTime date))
                                            {
                                                req_to_change.Date = date;
                                            }
                                            else
                                            {
                                                Console.WriteLine("Invalid date format.");
                                            }
                                            break;
                                        // Navigation options
                                        case 4:
                                            Console.WriteLine("Go Back");
                                            ShowTravelManagement();
                                            return; // Return to the previous menu
                                        case 5:
                                            Console.WriteLine("Exit");
                                            return; // Exit the Edit Travel Request menu
                                        default:
                                            Console.WriteLine("Invalid Choice");
                                            break;
                                    }

                                    ticket_BAL.ViewAllRequest_BAL();
                                }
                                else
                                {
                                    Console.WriteLine("Invalid choice. Please enter a number.");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Request not found with Request ID: " + req_id);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Request ID. Please enter a number.");
                }
            }


            // new code endsss


            catch (Exception ex)
            {
                Console.WriteLine("Request Id Not Found, Please enter valid Request Id");
            }
            ShowTravelManagement();

        }


        public static void ShowDeleteTravelRequest()
        {

            try
            {
                ticket_BAL.ViewAllRequest_BAL();
                Console.WriteLine("Delete Travel Request");
                Console.Write("Enter the Request ID to delete: ");
                int requestID = int.Parse(Console.ReadLine());

                ticket_BAL.DeleteRequest_BAL(requestID);
                // Console.WriteLine("Data deleted");
                ShowTravelManagement();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
            }

        }


        public static void ShowViewAllTravelRequest()
        {
            Console.WriteLine("Viewing All Travel Requests");
            //Ticket_BAL ticket_BAL = new Ticket_BAL();
            ticket_BAL.JoinViewAll_BAL();
            //ticket_BAL.ViewAllRequest_BAL();
            //ShowTravelManagement();
        }


        public static void ShowApproveTravelRequest()
        {
            //try
            //{
            //    ticket_BAL.ViewPendingApproveRequest_BAL();

            //    //check if there are any pendng requests
            //    if (!ticket_BAL.CheckPendingRequest_BAL())
            //    {
            //        Console.WriteLine("No pending requests to approve.");
            //        ShowTravelManagement();
            //        return;
            //    }


            //    Console.WriteLine("Enter Request ID");
            //    int req_id = int.Parse(Console.ReadLine());
            //    Console.WriteLine("1.Approve\n2.Not_Approved");
            //    int choice1;
            //    choice1 = int.Parse(Console.ReadLine());
            //    ApprovedStatus app = ApprovedStatus.Pending;

            //    switch (choice1)
            //    {
            //        case 1:
            //            app = ApprovedStatus.Approved;
            //            break;
            //        case 2:
            //            app = ApprovedStatus.Not_Approved;
            //            break;
            //    }

            //    ticket_BAL.ApproveRequest_BAL(req_id, app);
            //    ticket_BAL.ViewAllRequest_BAL();
            //    ShowTravelManagement();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("Error" + ex.Message);
            //}

            //new codee stratss hereee

            try
            {
                ticket_BAL.ViewPendingApproveRequest_BAL();

                // Check if there are any pending requests
                if (!ticket_BAL.CheckPendingRequest_BAL())
                {
                    Console.WriteLine("No pending requests to approve.");
                    ShowTravelManagement();
                    return;
                }

                Console.WriteLine("Enter request id to change status:");
                if (int.TryParse(Console.ReadLine(), out int reqID))
                {
                    TravelRequest req_to_approve = ticket_BAL.GetRequestById_BAL(reqID);
                    if (req_to_approve != null)
                    {
                        Console.WriteLine("1. Approved\n2. Not Approved\n3. Go Back");

                        int choice;
                        if (int.TryParse(Console.ReadLine(), out choice))
                        {
                            ApprovedStatus approve = ApprovedStatus.Pending;

                            switch (choice)
                            {
                                case 1:
                                    approve = ApprovedStatus.Approved;
                                    break;
                                case 2:
                                    approve = ApprovedStatus.Not_Approved;
                                    break;
                                case 3:
                                    Console.WriteLine("Go Back");
                                    ShowTravelManagement();
                                    return;
                            }
                            ticket_BAL.ApproveRequest_BAL(reqID, approve);
                            ticket_BAL.ViewAllRequest_BAL();
                            ShowTravelManagement();
                        }
                        else
                        {
                            Console.WriteLine("Invalid Request ID. Please enter a number.");
                            ShowApproveTravelRequest();
                        }


                    }
                    else
                    {
                        Console.WriteLine("Request not found with Request ID: " + reqID);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Request ID. Please enter a number.");
                    ShowApproveTravelRequest();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            ShowTravelManagement();

            // new code ends heree
        }


        public static void ShowConfirmBooking()
        {
            //        try
            //        {

            //            ticket_BAL.ViewOpenApprovedRequestForBooking_BAL();

            //            if (!ticket_BAL.CheckPendingBooking_BAL())
            //            {
            //                Console.WriteLine("No pending requests to approve.");
            //                ShowTravelManagement();
            //                return;
            //            }

            //            Console.WriteLine("Enter Request ID to Confirm Booking");
            //            int req_id = int.Parse(Console.ReadLine());
            //            Console.WriteLine("1.Available\n2.Not_Available");
            //            int choice1;
            //            choice1 = int.Parse(Console.ReadLine());
            //            BookingStatus Book = BookingStatus.Not_Available;
            //            switch (choice1)
            //            {
            //                case 1:
            //                    Book = BookingStatus.Available;
            //                    break;
            //                case 2:
            //                    Book = BookingStatus.Not_Available;
            //                    break;


            //            }
            //            //Console.WriteLine("Enter Req Id To Change Status:");
            //            //int r_id = int.Parse(Console.ReadLine());
            //            ticket_BAL.ConfirmRequest_BAL(req_id, Book);
            //            ticket_BAL.ViewAllRequest_BAL();
            //            ShowTravelManagement();

            //        }
            //        catch (Exception ex)
            //        {
            //            Console.WriteLine("Error" + ex.Message);
            //        }


            //    }

            //neww codee startss heree

            try
            {
                ticket_BAL.ViewOpenApprovedRequestForBooking_BAL();
                Console.WriteLine("Enter request id to change status:");
                if (int.TryParse(Console.ReadLine(), out int reqID))
                {
                    if (reqID == 0)
                    {
                        Console.WriteLine("Going back to Travel Management.");
                        ShowTravelManagement(); // Go back to the Travel Management menu
                        return;
                    }

                    // Check if the request ID exists
                    TravelRequest req_to_change = ticket_BAL.GetRequestById_BAL(reqID);
                    if (req_to_change == null)
                    {
                        Console.WriteLine("Request not found with Request ID: " + reqID);
                        ShowTravelManagement();
                        return;
                    }

                    Console.WriteLine("1. Available\n2. Not Available\n3. Go Back");
                    if (int.TryParse(Console.ReadLine(), out int choice))
                    {
                        BookingStatus book = BookingStatus.Not_Available;
                        switch (choice)
                        {
                            case 1:
                                book = BookingStatus.Available;
                                break;
                            case 2:
                                book = BookingStatus.Not_Available;
                                break;
                            case 3:
                                Console.WriteLine("Go Back");
                                ShowTravelManagement();
                                return;
                            default:
                                Console.WriteLine("Invalid choice. Please enter 1, 2, or 3.");
                                return;
                        }
                       ticket_BAL.ConfirmRequest_BAL(reqID, book);
                       ticket_BAL.ViewAllRequest_BAL();
                        ShowTravelManagement();
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice. Please enter a number");
                        ShowConfirmBooking();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Request ID. Please enter a valid number.");
                    ShowConfirmBooking();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }


            //neww codee ends heree


           


        }
    }
}



