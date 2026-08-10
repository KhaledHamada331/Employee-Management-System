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
            if (string.IsNullOrWhiteSpace(employee.Name))
            {
                return "Invalid employee name.";
            }
            if (employee.Salary <= 0)
            {
                return "Invalid Salary.";
            }
            if (!departments.ContainsKey(employee.DepartmentId))
            {
                return "Invalid department ID.";
            }
            foreach (var existingEmployee in onboarding)
            {
                if (existingEmployee.Id == employee.Id)
                {
                    return "Employee with the same ID already exists.";
                }
            }
            foreach (var existingEmployee in activeEmployees)
            {
                if (existingEmployee.Id == employee.Id)
                {
                    return "Employee with the same ID already exists.";
                }
            }
            onboarding.Enqueue(employee);
            actionHistory.Push($"Added onboarding Employee: {employee.Name}");
            return $"Employee '{employee.Name}' added to onboarding successfully.";
        }

        public string CompleteOnboarding()
        {
            if (onboarding.Count == 0)
            {
                return "No employees are currently waiting for onboarding.";
            }
            var employee = onboarding.Dequeue();
            activeEmployees.Add(employee);
            actionHistory.Push($"Completed onboarding for Employee: {employee.Name}");
            return $"Employee '{employee.Name}' completed onboarding and is now active.";
        }

        public string AddDepartment(Department department)
        {
            if (department is null)
            {
                return "Invalid department data.";
            }
            if (string.IsNullOrWhiteSpace(department.Name))
            {
                return "Invalid department name.";
            }
            if (departments.ContainsKey(department.Id))
            {
                return "Department with the same ID already exists.";
            }
            departments.Add(department.Id, department);
            actionHistory.Push($"Added Department: {department.Name}");
            return "Department added successfully.";

        }

        public Employee GetEmployee(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                throw new ArgumentException("Input cannot be null or empty.");
            }
            if (int.TryParse(query, out int employeeId))
            {
                foreach (var employee in activeEmployees)
                {
                    if (employee.Id == employeeId)
                    {
                        return employee;
                    }
                }
            }
            else
            {
                foreach (var employee in activeEmployees)
                {
                    if (employee.Name.Equals(query, StringComparison.OrdinalIgnoreCase))
                    {
                        return employee;
                    }
                }
            }
            throw new InvalidOperationException("Employee not found.");

        }

        public decimal CalculateAverageSalary()
        {
            decimal totalSalary = 0.0m;
            int employeeCount = activeEmployees.Count;
            foreach (var employee in activeEmployees)
            {
                totalSalary += employee.Salary;
            }
            return employeeCount > 0 ? totalSalary / employeeCount : 0.0m;
        }

        public string GetEmployeeCountByDepartment()
        {
            if (departments.Count == 0)
            {
                return "No departments available.";
            }
            string result = "Employee Count by Department:\n";
            foreach (var departmentID in departments.Keys)
            {
                int count = 0;
                foreach (var employee in activeEmployees)
                {
                    if (employee.DepartmentId == departmentID)
                    {
                        count++;
                    }
                }
                result += $"Department : {departments[departmentID].Name}, Employee Count: {count}\n";
            }
            return result;
        }

        public List<Employee> GetEmployeesByDepartment(int departmentId)
        {
            if (departments.Count == 0)
            {
                throw new InvalidOperationException("There are no departments available.");
            }
            if (!departments.ContainsKey(departmentId))
            {
                throw new KeyNotFoundException($"There is no department with ID {departmentId}.");
            }
            List<Employee> employees = new();
            foreach (var employee in activeEmployees)
            {
                if (employee.DepartmentId == departmentId)
                {
                    employees.Add(employee);
                }
            }
            return employees;

        }

        public string GetActionHistory()
        {
            if (actionHistory.Count == 0)
            {
                return "No actions have been performed yet.";
            }
            string result = "Action History:\n";
            foreach (var action in actionHistory)
            {
                result += $"{action}\n";
            }
            // Alternative approach using Pop() on a temporary stack.
            // This preserves the original actionHistory stack.

            // Stack<string> tempStack = new Stack<string>(actionHistory);
            // while (tempStack.Count > 0)
            // {
            //     result += $"{tempStack.Pop()}\n";
            // }
            return result;
        }
    }
}
