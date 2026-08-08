using System;
using System.Collections.Generic;
using System.Linq;
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


    }
}
