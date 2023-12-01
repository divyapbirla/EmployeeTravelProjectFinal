using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Security.Cryptography;
using System.Xml.Linq;

namespace DataAccessLayer
{
    public class EmpDataManager: IEmpDataManager
    {

        public List<Employee> lstEmployees = new List<Employee>()
        {
            new Employee(){EmployeeID = 1,FirstName="Kalyani",LastName="gadge",Contact=857644,Address="Mumbai",Dept="IT",DOB=DateTime.Parse("03-07-2001")},
            new Employee(){EmployeeID = 2,FirstName="Divya",LastName="patil",Contact=5863785,Address="karad",Dept="CSE",DOB=DateTime.Parse("08-04-2005")},
            new Employee(){EmployeeID = 3,FirstName="shruthi",LastName="pathi",Contact=12334,Address="pune",Dept="Mech",DOB=DateTime.Parse("10-05-2002")},
            new Employee(){EmployeeID = 4,FirstName="ririka",LastName="rang",Contact=12334,Address="borivali",Dept="Elec",DOB=DateTime.Parse("11-06-2002")},

        };
        
        public int AddEmployee_DAL(int EmployeeID, string FirstName, string LastName, int Contact, string Address, string Dept, DateTime DOB)
        {
            foreach(Employee emp in lstEmployees)
            {
                if(emp.EmployeeID == EmployeeID )
                {
                    Console.WriteLine("Employee Id Already Exist,Add New Employee.");
                    return 0;
                }
            }
            lstEmployees.Add(new Employee() { EmployeeID = EmployeeID, FirstName = FirstName, LastName = LastName, Contact = Contact, Address = Address, Dept = Dept, DOB = DOB });
            //ViewEmployee_DAL();
            Console.WriteLine("Employee Added Successfully");
            return 1;
        }

        public void EditEmployee_DAL(Employee employee)
        {
            Employee emp_Main = lstEmployees.FirstOrDefault(x=>x.EmployeeID == employee.EmployeeID);
            int index = lstEmployees.IndexOf(emp_Main);
            lstEmployees[index].FirstName = employee.FirstName;
            lstEmployees[index].LastName = employee.LastName;
            lstEmployees[index].Contact = employee.Contact;
            lstEmployees[index].Address = employee.Address;
            lstEmployees[index].Dept = employee.Dept;
            lstEmployees[index].DOB = employee.DOB;
            //ViewEmployee_DAL();
        }

        public int DeleteEmployee_DAL( int EmpId)
        {
            Employee emp = lstEmployees.FirstOrDefault(e => e.EmployeeID == EmpId);
            if (emp != null)
            {
                lstEmployees.Remove(emp);
                Console.WriteLine("Employee Data deleted successfully");
            }
            else
            {
                Console.WriteLine("Employee ID not found For Deletion");
            }
            ViewEmployee_DAL();
            return 1;
            
            
        }
        public void ViewEmployee_DAL()
        {
            Console.WriteLine("{0,75}","View All Employees");
            Console.WriteLine("**************************************************************************************************************************************************");

            Console.WriteLine("{0,-20}{1,-20}{2,-20}{3,-20}{4,-20}{5,-20}{6,-20}", "EmployeeID","FirstName","LastName","Contact","Address","Dept","DOB");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------------");
            foreach (Employee emp in lstEmployees)
            {
                Console.WriteLine("{0,-20}{1,-20}{2,-20}{3,-20}{4,-20}{5,-20}{6,-20}", emp.EmployeeID,emp.FirstName,emp.LastName,emp.Contact,emp.Address,emp.Dept,emp.DOB);
            }
        }

       public Employee GetEmployeeById_DAL(int id)
        {
            Employee emp = lstEmployees.FirstOrDefault(e=>e.EmployeeID == id);
            if (emp != null)
            {
                return emp;
            }
            return null;
        }

    }


   
}


    