using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using ClassLibrary1;

namespace ClassLibrary_BAL
{
    public class Employee_BAL:IEmployee_BAL
    {
        private  static readonly EmpDataManager edm = new EmpDataManager();
        public void ViewEmployee_BAL()
        {
            
            edm.ViewEmployee_DAL();
        }

        public int DeleteEmployee_BAL(int EmpId)
        {
            //EmpDataManager edm = new EmpDataManager();
            edm.DeleteEmployee_DAL( EmpId);
            return 1;
        }

        public int AddEmployee_BAL(int EmployeeID, string FirstName, string LastName, int Contact, string Address, string Dept, DateTime DOB)
        {
            //EmpDataManager edm = new EmpDataManager();
            edm.AddEmployee_DAL(EmployeeID,FirstName,LastName,Contact,Address,Dept,DOB);
            return 1;
        }

        public Employee GetEmployeeById_BAL(int id)
        {
            Employee emp = edm.GetEmployeeById_DAL(id);
            return emp;
        }

        public void EditEmployee_BAL(Employee emp_to_Change)
        {
            //EmpDataManager edm = new EmpDataManager();
            edm.EditEmployee_DAL(emp_to_Change);
        }
    }
}
