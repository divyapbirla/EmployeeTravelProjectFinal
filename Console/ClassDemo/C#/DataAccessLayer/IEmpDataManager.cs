using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;

namespace DataAccessLayer
{
    public interface IEmpDataManager
    {
        int AddEmployee_DAL(int EmployeeID, string FirstName, string LastName, int Contact, string Address, string Dept, DateTime DOB);

        void EditEmployee_DAL(Employee employee);
        int DeleteEmployee_DAL( int EmpId);

        void ViewEmployee_DAL();

        Employee GetEmployeeById_DAL(int id);
    }
}
