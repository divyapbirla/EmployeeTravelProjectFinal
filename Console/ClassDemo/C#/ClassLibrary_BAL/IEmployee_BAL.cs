using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;

namespace ClassLibrary_BAL
{
    public interface IEmployee_BAL
    {
        void  ViewEmployee_BAL();

        int DeleteEmployee_BAL(int EmpId);

        int AddEmployee_BAL(int EmployeeID, string FirstName, string LastName, int Contact, string Address, string Dept, DateTime DOB);

        //int EditEmployee_BAL(Employee employee);
        Employee GetEmployeeById_BAL(int id);

        void EditEmployee_BAL(Employee emp_to_change);
    }
}
