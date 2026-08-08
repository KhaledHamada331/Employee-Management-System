using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Services
{
    public class Company
    {
        List<Employee> activeEmployees = new List<Employee>();
        Dictionary<int, Department> departments = new Dictionary<int, Department>();
        Queue<Employee> onboarding = new Queue<Employee>();
        Stack<string> actionHistory = new Stack<string>();
        HashSet<string> companySkills = new HashSet<string>();


        public string AddEmployee(Employee employee)
        {
            if (employee == null)
            {
                return "Invalid employee data.";
            }
            if(string.IsNullOrWhiteSpace(employee.Name))
            {
                return "Invalid employee name.";
            }
            if(employee.Salary <= 0)
            {
                return "Invalid Salary.";            
            }
            if (!departments.ContainsKey(employee.DepartmentId))
            {
                return "Invalid department ID.";
            }
            foreach (var existingEmployee in activeEmployees)
            {
                if (existingEmployee.Id == employee.Id)
                {
                    return "Employee with the same ID already exists.";
                }
            }
            activeEmployees.Add(employee);
            actionHistory.Push($"Added Employee: {employee.Name}");
            return "Employee added successfully.";
        }

        public string AddDepartment(Department department)
        {
            if(department is null)
            {
                return "Invalid department data.";
            }
            if(string.IsNullOrWhiteSpace(department.Name))
            {
                return "Invalid department name.";
            }
            if(departments.ContainsKey(department.Id))
            {
                return "Department with the same ID already exists."; 
            }
            departments.Add(department.Id , department);
            actionHistory.Push($"Added Department: {department.Name}");
            return "Department added successfully.";
            
        }

    }
}
