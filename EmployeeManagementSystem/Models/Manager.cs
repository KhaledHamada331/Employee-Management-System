using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Models
{
    public class Manager : Employee
    {
        public List<Employee> TeamMembers {get; }= new();
        
        public override string GetInfo()
        {
            return base.GetInfo() +
            $"\nManaged Team Size: {TeamMembers.Count}";
        }

    }
}
