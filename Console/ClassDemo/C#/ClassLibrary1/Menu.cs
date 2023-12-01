/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Menu
    {
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
            Console.WriteLine("enter your process: ");
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
            Console.WriteLine("1. Raise_Travel_Request \n2. View_Travel_Request \n3. Delete_Travel_Request  \n4. Approve_Travel_Request  \n5.Confirm_Booking  \n6. Go_Back \n7. Exit");
            int choice2;

            choice2 = int.Parse(Console.ReadLine());



            switch (choice2)
            {
                case 1:
                    ShowRaiseTravelRequest();
                    break;
                case 2:
                    ShowViewAllTravelRequest();
                    break;
                case 3:
                   ShowDeleteTravelRequest();
                    break;
                case 4:
                    //Console.WriteLine("Approve_Travel_Request");
                    ShowApproveTravelRequest();
                    break;
                case 5:
                    //Console.WriteLine("Confirm Booking");
                    ShowConfirmBooking();
                    break;
                case 6:
                    // Go back to the main menu (do nothing here).
                    ShowMain();
                    break;
                case 7:
                    Console.WriteLine("Exiting the application. Goodbye!");
                    return;


            }
        }

        public static void ShowAddEmployee()
        {

            int EmployeeID;
            String FirstName;
            String LastName;
            int Contact;
            String Address;
            String Dept;
            String DOB;
            Console.WriteLine("add employee details");
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
            DOB = Console.ReadLine();
        }


        public static void ShowEditEmployee()
        {
            int editEmployeeID;
            String editFirstName;
            String editLastName;
            int editContact;
            String editAddress;
            String editDept;
            String editDOB;
            Console.WriteLine("----------------------------");
            Console.WriteLine("Edit Employee");
            Console.WriteLine("----------------------------");
            Console.WriteLine("Display all Employees");
            Console.WriteLine("Enter Employee Id");
            editEmployeeID = int.Parse(Console.ReadLine());



            while (true)
            {
                Console.WriteLine("Enter field no. to edit");
                Console.WriteLine("1. First Name \n2. Last Name \n3. Contact \n4. Address \n5. Department \n6. DOB \n7. Exit");
                int choice;
                choice = int.Parse(Console.ReadLine());



                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter Employee FirstName");
                        editFirstName = Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine("Enter Employee LastName");
                        editLastName = Console.ReadLine();
                        break;
                    case 3:
                        Console.WriteLine("Enter Employee Contact");
                        editContact = int.Parse(Console.ReadLine());
                        break;
                    case 4:
                        Console.WriteLine("Enter Employee Address");
                        editAddress = (Console.ReadLine());
                        break;
                    case 5:
                        Console.WriteLine("Enter Employee Department");
                        editDept = Console.ReadLine();
                        break;
                    case 6:
                        Console.WriteLine("Enter Employee DOB");
                        editDOB = Console.ReadLine();
                        break;
                    case 7:
                        Console.WriteLine("Exit");
                        return;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;

                }



            }

        }

        public static void ShowDeleteEmployee()
        {
            int EmployeeID;
            Console.WriteLine("Enter Employee Id");
            EmployeeID = int.Parse(Console.ReadLine());
            Console.WriteLine("Data deleted successfully");
        }

        public static void ShowViewEmployee()
        {
            Console.WriteLine("List of all Employees");
            ViewEmployee_DAL();
        }

        public static void ShowRaiseTravelRequest()
        {
            int empID;
            String fromLocation;
            String toLocation;
            String date;
            String approve;
            String bookingStatus;


            Console.WriteLine("--------  Raise a Ticket  ----------");
            Console.WriteLine("Request ID");
            Console.WriteLine("Enter Employee Id");
            empID = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter a Origin Location");
            fromLocation = Console.ReadLine();
            Console.WriteLine("Enter Destination Location");
            toLocation = (Console.ReadLine());
            Console.WriteLine("Enter Date");
            date = Console.ReadLine();

        }


        public static void ShowEditTravelRequest()
        {
            string editFromLocation;
            string editToLocation;
            string date;
            Console.WriteLine("----------------------------");
            Console.WriteLine("Edit Travel Request");
            Console.WriteLine("----------------------------");
            Console.WriteLine("Display all travel request");



            while (true)
            {
                Console.WriteLine("Enter field no. to edit");
                Console.WriteLine("1. Origin Location \n.2.Enter Destination Location \n.3. Date \n4. Exit");
                int choice;
                choice = int.Parse(Console.ReadLine());



                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter Origin Location");
                        editFromLocation = Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine("Enter Destination Location");
                        editToLocation = Console.ReadLine();
                        break;
                    case 3:
                        Console.WriteLine("Enter Date");
                        date = Console.ReadLine();
                        break;
                    case 4:
                        Console.WriteLine("Exit");
                        return;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;



                }
            }

        }


        public static void ShowDeleteTravelRequest()
        {
            Console.WriteLine("Delete Travel Request");
            Console.Write("Enter the Request ID to delete: ");
            int requestID = int.Parse(Console.ReadLine());
            Console.WriteLine("Data deleted");
        }

        public static void ShowViewAllTravelRequest()
        {
            Console.WriteLine("Viewing All Travel Requests");
        }


        public static void ShowApproveTravelRequest()
        {
            Console.WriteLine("Viewing Approved Travel Requests");

        }


        public static void ShowConfirmBooking()
        {
            Console.WriteLine("Confirm Booking");
            Console.Write("Enter the Request ID to confirm booking: ");
            int requestID = int.Parse(Console.ReadLine());


        }


    }
}
*/


