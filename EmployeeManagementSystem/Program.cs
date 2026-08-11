using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Services;

namespace EmployeeManagementSystem
{
    public class Program
    {
        static void Main(string[] args)
        {
            int choice = -1;
            Company company = new Company();
            do
            {

                DisplayMenu();
                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > 10)
                {
                    Console.WriteLine("Invalid input. Please enter a number between 0 and 10.");
                }
                switch (choice)
                {
                    case 1:
                        // Add Employee
                        Employee employee = new Employee();
                        Console.Write("Enter Employee Name: ");
                        employee.Name = Console.ReadLine();
                        Console.Write("Enter Employee Salary: ");
                        decimal salary;
                        while (!decimal.TryParse(Console.ReadLine(), out salary))
                        {
                            Console.WriteLine("Invalid input. Please enter a valid salary.");
                        }
                        employee.Salary = salary;
                        Console.Write("Enter Employee Department ID: ");
                        int deptId = -1;
                        while (!int.TryParse(Console.ReadLine(), out deptId) || deptId <= 0)
                        {
                            Console.WriteLine("Invalid input. Please enter a valid department ID.");
                        }
                        employee.DepartmentId = deptId;
                        Console.WriteLine(company.AddEmployee(employee));

                        break;
                    case 2:
                        // Complete Onboarding
                        Console.WriteLine(company.CompleteOnboarding());
                        break;
                    case 3:
                        // Add Department
                        Department department = new Department();
                        Console.Write("Enter Department Name: ");
                        department.Name = Console.ReadLine();
                        Console.WriteLine(company.AddDepartment(department));
                        break;
                    case 4:
                        // Get Employee Details
                        try
                        {
                            Console.Write("Enter Employee ID or Name to get details: ");
                            string input = Console.ReadLine();
                            Employee foundEmployee = company.GetEmployee(input);
                            Console.WriteLine(foundEmployee.GetInfo());
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        catch (InvalidOperationException ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }

                        break;
                    case 5:
                        // Get Employees Salary Average
                        decimal averageSalary = company.CalculateAverageSalary();
                        Console.WriteLine($"Average Salary of Employees: {averageSalary:C}");
                        break;
                    case 6:
                        // Get Employees Count by Department
                        Console.WriteLine(company.GetEmployeeCountByDepartment());
                        break;
                    case 7:
                        // Get Employees by Department
                        try
                        {
                            Console.Write("Enter Department ID to get employees: ");
                            int deptIdForEmployees;
                            while (!int.TryParse(Console.ReadLine(), out deptIdForEmployees) || deptIdForEmployees <= 0)
                            {
                                Console.WriteLine("Invalid input. Please enter a valid department ID.");
                            }
                            List<Employee> employeesInDepartment = company.GetEmployeesByDepartment(deptIdForEmployees);
                            if (employeesInDepartment.Count == 0)
                            {
                                Console.WriteLine("No employees found in this department.");
                            }
                            else
                            {
                                Console.WriteLine($"Employees in Department ID {deptIdForEmployees}:");
                                foreach (var emp in employeesInDepartment)
                                {
                                    Console.WriteLine(emp.GetInfo());
                                }
                            }

                        }
                        catch (InvalidOperationException ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        catch (KeyNotFoundException ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }

                        break;
                    case 8:
                        // Add New Skill
                        Console.Write("Enter Skill Name: ");
                        string skillName = Console.ReadLine();
                        Console.WriteLine(company.AddSkill(skillName));
                        break;
                    case 9:
                        // Get Company Skills
                        Console.WriteLine(company.GetCompanySkills());
                        break;
                    case 10:
                        // Get Action History
                        Console.WriteLine(company.GetActionHistory());
                        break;
                    case 0:
                        Console.WriteLine("Exiting the program.");
                        break;
                }
            } while (choice != 0);



        }
        public static void DisplayMenu()
        {
            Console.WriteLine("Employee Management System");
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Complete Onboarding");
            Console.WriteLine("3. Add Department");
            Console.WriteLine("4. Get Employee Details");
            Console.WriteLine("5. Get Employees Salary Average");
            Console.WriteLine("6. Get Employees Count by Department");
            Console.WriteLine("7. Get Employees by Department");
            Console.WriteLine("8. Add New Skill");
            Console.WriteLine("9. Get Company Skills");
            Console.WriteLine("10. Get Action History");
            Console.WriteLine("0. Exit");
            Console.Write("Enter your choice: ");
        }

 
    }
}
