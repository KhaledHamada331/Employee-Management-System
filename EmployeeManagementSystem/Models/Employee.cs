using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Models
{
    public class Employee
    {
        public int Id {get; set;}
        public string Name {get; set;}
        public DateTime HireDate {get; set;}
        public int DepartmentId {get; set;}
        public decimal Salary {get; set;}

        public Employee()
        {
            Name = string.Empty;
            HireDate = DateTime.Now;
            Salary = 0.0m;
        }
        public virtual string GetInfo()
        {
            return $"Name : {Name}" +
            $"\nHire Date : {HireDate:d}" +
            $"\nSalary : {Salary:C}" ;
        }
    }
}
